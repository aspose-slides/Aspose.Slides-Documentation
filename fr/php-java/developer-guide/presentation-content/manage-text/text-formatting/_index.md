---
title: Formatage de Texte
type: docs
weight: 50
url: /php-java/text-formatting/
---


## **Surligner du Texte**
La méthode [highlightText](https://reference.aspose.com/slides/php-java/aspose.slides/ITextFrame#highlightText-java.lang.String-java.awt.Color-) a été ajoutée à l'interface [ITextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/ITextFrame) et à la classe [TextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/TextFrame).

Elle permet de surligner une partie du texte avec une couleur de fond en utilisant un échantillon de texte, similaire à l'outil de couleur de surlignage de texte dans PowerPoint 2019.

Le code ci-dessous montre comment utiliser cette fonctionnalité :

```php
  $pres = new Presentation("Presentation.pptx");
  try {
    $textHighlightingOptions = new TextHighlightingOptions();
    $textHighlightingOptions->setWholeWordsOnly(true);
    $pres->getSlides()->get_Item(0)->getShapes()->get_Item(0)->getTextFrame()->highlightText("title", java("java.awt.Color")->BLUE);// surligner tous les mots 'important'

    $pres->getSlides()->get_Item(0)->getShapes()->get_Item(0)->getTextFrame()->highlightText("to", java("java.awt.Color")->MAGENTA, $textHighlightingOptions);// surligner toutes les occurrences séparées de 'the'

    $pres->save("OutputPresentation-highlight.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

{{% alert color="primary" %}} 

Aspose propose un service simple de [modification de PowerPoint en ligne gratuit](https://products.aspose.app/slides/editor)

{{% /alert %}} 

## **Surligner du Texte en utilisant une Expression Régulière**

La méthode [highlightRegex](https://reference.aspose.com/slides/php-java/aspose.slides/ITextFrame#highlightRegex-java.lang.String-java.awt.Color-com.aspose.slides.ITextHighlightingOptions-) a été ajoutée à l'interface [ITextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/ITextFrame) et à la classe [TextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/TextFrame).

Elle permet de surligner une partie du texte avec une couleur de fond en utilisant une regex, similaire à l'outil de couleur de surlignage de texte dans PowerPoint 2019.

Le code ci-dessous montre comment utiliser cette fonctionnalité :

```php
  $pres = new Presentation("Presentation.pptx");
  try {
    $options = new TextHighlightingOptions();
    $pres->getSlides()->get_Item(0)->getShapes()->get_Item(0)->getTextFrame()->highlightRegex("\\b[^\\s]{4}\\b", java("java.awt.Color")->YELLOW, $options);// surligner tous les mots de 10 symboles ou plus

    $pres->save("OutputPresentation-highlight.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Définir la Couleur de Fond du Texte**

Aspose.Slides vous permet de spécifier votre couleur préférée pour l'arrière-plan d'un texte.

Ce code PHP vous montre comment définir la couleur de fond pour un texte entier :

```php
  $pres = new Presentation();
  try {
    $autoShape = $pres->getSlides()->get_Item(0)->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 50, 200, 100);
    $autoShape->getTextFrame()->getParagraphs()->clear();
    $para = new Paragraph();
    $portion1 = new Portion("Noir");
    $portion1->getPortionFormat()->setFontBold(NullableBool::True);
    $portion2 = new Portion(" Rouge ");
    $portion3 = new Portion("Noir");
    $portion3->getPortionFormat()->setFontBold(NullableBool::True);
    $para->getPortions()->add($portion1);
    $para->getPortions()->add($portion2);
    $para->getPortions()->add($portion3);
    $autoShape->getTextFrame()->getParagraphs()->add($para);
    $pres->save("text.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
  $presentation = new Presentation("text.pptx");
  try {
    $autoShape = $presentation->getSlides()->get_Item(0)->getShapes()->get_Item(0);
    StreamSupport->stream($autoShape->getTextFrame()->getParagraphs()->spliterator(), false)->map(( p) -> $p->getPortions())->forEach(( c) -> $c->forEach(( ic) -> $ic->getPortionFormat()->getHighlightColor()->setColor($Color.BLUE)));
    $presentation->save("text-red.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($presentation)) {
      $presentation->dispose();
    }
  }
```

Ce code PHP vous montre comment définir la couleur de fond pour seulement une partie d'un texte :

```php
  $pres = new Presentation();
  try {
    $autoShape = $pres->getSlides()->get_Item(0)->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 50, 200, 100);
    $autoShape->getTextFrame()->getParagraphs()->clear();
    $para = new Paragraph();
    $portion1 = new Portion("Noir");
    $portion1->getPortionFormat()->setFontBold(NullableBool::True);
    $portion2 = new Portion(" Rouge ");
    $portion3 = new Portion("Noir");
    $portion3->getPortionFormat()->setFontBold(NullableBool::True);
    $para->getPortions()->add($portion1);
    $para->getPortions()->add($portion2);
    $para->getPortions()->add($portion3);
    $autoShape->getTextFrame()->getParagraphs()->add($para);
    $pres->save("text.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
  $presentation = new Presentation("text.pptx");
  try {
    $autoShape = $presentation->getSlides()->get_Item(0)->getShapes()->get_Item(0);
    $redPortion = StreamSupport->stream($autoShape->getTextFrame()->getParagraphs()->get_Item(0)->getPortions()->spliterator(), false)->filter(( p) -> $p->getText()->contains("Rouge"))->findFirst();
    if ($redPortion->isPresent()) {
      $redPortion->get()->getPortionFormat()->getHighlightColor()->setColor(java("java.awt.Color")->RED);
    }
    $presentation->save("text-red.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($presentation)) {
      $presentation->dispose();
    }
  }
```

## **Aligner les Paragraphes de Texte**

Le formatage du texte est l'un des éléments clés lors de la création de tout type de documents ou de présentations. Nous savons qu'Aspose.Slides pour PHP via Java prend en charge l'ajout de texte aux diapositives, mais dans ce sujet, nous verrons comment nous pouvons contrôler l'alignement des paragraphes de texte dans une diapositive. Veuillez suivre les étapes ci-dessous pour aligner les paragraphes de texte en utilisant Aspose.Slides pour PHP via Java :

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation).
2. Obtenez la référence d'une diapositive en utilisant son index.
3. Accédez aux formes de Placeholder présentes dans la diapositive et castées-les en tant qu'[AutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/AutoShape).
4. Obtenez le paragraphe (qui doit être aligné) à partir de [TextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/IAutoShape#getTextFrame--) exposé par [AutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/AutoShape).
5. Alignez le paragraphe. Un paragraphe peut être aligné à droite, à gauche, centré et justifié.
6. Écrivez la présentation modifiée en tant que fichier PPTX.

L'implémentation des étapes ci-dessus est donnée ci-dessous.

```php
  # Instancier un objet Presentation représentant un fichier PPTX
  $pres = new Presentation("ParagraphsAlignment.pptx");
  try {
    # Accéder à la première diapositive
    $slide = $pres->getSlides()->get_Item(0);
    # Accéder au premier et au deuxième placeholder dans la diapositive et les caster en tant qu'AutoShape
    $tf1 = $slide->getShapes()->get_Item(0)->getTextFrame();
    $tf2 = $slide->getShapes()->get_Item(1)->getTextFrame();
    # Changer le texte dans les deux placeholders
    $tf1->setText("Alignement Centré par Aspose");
    $tf2->setText("Alignement Centré par Aspose");
    # Obtenir le premier paragraphe des placeholders
    $para1 = $tf1->getParagraphs()->get_Item(0);
    $para2 = $tf2->getParagraphs()->get_Item(0);
    # Aligner le paragraphe de texte au centre
    $para1->getParagraphFormat()->setAlignment(TextAlignment->Center);
    $para2->getParagraphFormat()->setAlignment(TextAlignment->Center);
    # Écrire la présentation en tant que fichier PPTX
    $pres->save("Centeralign_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Définir la Transparence pour le Texte**
Cet article démontre comment définir la propriété de transparence pour n'importe quelle forme de texte en utilisant Aspose.Slides pour PHP via Java. Pour définir la transparence sur le texte, veuillez suivre les étapes ci-dessous :

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation).
2. Obtenez la référence d'une diapositive.
3. Définissez la couleur de l'ombre.
4. Écrivez la présentation en tant que fichier PPTX.

L'implémentation des étapes ci-dessus est donnée ci-dessous.

```php
  $pres = new Presentation("transparency.pptx");
  try {
    $shape = $pres->getSlides()->get_Item(0)->getShapes()->get_Item(0);
    $effects = $shape->getTextFrame()->getParagraphs()->get_Item(0)->getPortions()->get_Item(0)->getPortionFormat()->getEffectFormat();
    $outerShadowEffect = $effects->getOuterShadowEffect();
    $shadowColor = $outerShadowEffect->getShadowColor()->getColor();
    echo($shadowColor->toString() . " - la transparence est : " . $shadowColor->getAlpha() / 255.0 * 100);
    # définir la transparence à zéro pour cent
    $outerShadowEffect->getShadowColor()->setColor(new java("java.awt.Color", $shadowColor->getRed(), $shadowColor->getGreen(), $shadowColor->getBlue(), 255));
    $pres->save("transparency-2.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Définir l'Espacement des Caractères pour le Texte**

Aspose.Slides vous permet de définir l'espace entre les lettres dans une zone de texte. De cette façon, vous pouvez ajuster la densité visuelle d'une ligne ou d'un bloc de texte en élargissant ou en condensant l'espacement entre les caractères.

Ce code PHP vous montre comment élargir l'espacement pour une ligne de texte et condenser l'espacement pour une autre ligne :

```php
  $presentation = new Presentation("in.pptx");
  $textBox1 = $presentation->getSlides()->get_Item(0)->getShapes()->get_Item(0);
  $textBox2 = $presentation->getSlides()->get_Item(0)->getShapes()->get_Item(1);
  $textBox1->getTextFrame()->getParagraphs()->get_Item(0)->getParagraphFormat()->getDefaultPortionFormat()->setSpacing(20);// élargir

  $textBox2->getTextFrame()->getParagraphs()->get_Item(0)->getParagraphFormat()->getDefaultPortionFormat()->setSpacing(-2);// condenser

  $presentation->save("out.pptx", SaveFormat::Pptx);

```

## **Gérer les Propriétés de Police des Paragraphes**

Les présentations contiennent généralement du texte et des images. Le texte peut être formaté de diverses manières, soit pour mettre en évidence des sections et des mots spécifiques, soit pour se conformer aux styles d'entreprise. Le formatage du texte aide les utilisateurs à varier l'apparence du contenu de la présentation. Cet article montre comment utiliser Aspose.Slides pour PHP via Java pour configurer les propriétés de police des paragraphes de texte sur les diapositives. Pour gérer les propriétés de police d'un paragraphe en utilisant Aspose.Slides pour PHP via Java :

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation).
1. Obtenez la référence d'une diapositive en utilisant son index.
1. Accédez aux formes de Placeholder dans la diapositive et castées-les en tant que [IAutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/IAutoShape).
1. Obtenez le [Paragraph](https://reference.aspose.com/slides/php-java/aspose.slides/ITextFrame) à partir de l'[ITextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/ITextFrame) exposé par [IAutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/IAutoShape).
1. Justifiez le paragraphe.
1. Accédez à la Portion de texte d'un paragraphe.
1. Définissez la police en utilisant FontData et définissez la police de la Portion de texte en conséquence.
   1. Définissez la police sur gras.
   1. Définissez la police sur italique.
1. Définissez la couleur de la police en utilisant le [getFillFormat](https://reference.aspose.com/slides/php-java/aspose.slides/IBasePortionFormat#getFillFormat--) exposé par l'objet [Portion](https://reference.aspose.com/slides/php-java/aspose.slides/IPortion).
1. Écrivez la présentation modifiée dans un fichier [PPTX](https://docs.fileformat.com/presentation/pptx/).

L'implémentation des étapes ci-dessus est donnée ci-dessous. Elle prend une présentation sans décoration et formate les polices sur l'une des diapositives.

```php
  # Instancier un objet Presentation représentant un fichier PPTX
  $pres = new Presentation("FontProperties.pptx");
  try {
    # Accéder à une diapositive en utilisant sa position
    $slide = $pres->getSlides()->get_Item(0);
    # Accéder au premier et au deuxième placeholder dans la diapositive et les caster en tant qu'AutoShape
    $tf1 = $slide->getShapes()->get_Item(0)->getTextFrame();
    $tf2 = $slide->getShapes()->get_Item(1)->getTextFrame();
    # Accéder au premier Paragraphe
    $para1 = $tf1->getParagraphs()->get_Item(0);
    $para2 = $tf2->getParagraphs()->get_Item(0);
    # Accéder à la première portion
    $port1 = $para1->getPortions()->get_Item(0);
    $port2 = $para2->getPortions()->get_Item(0);
    # Définir de nouvelles polices
    $fd1 = new FontData("Elephant");
    $fd2 = new FontData("Castellar");
    # Assigner de nouvelles polices à la portion
    $port1->getPortionFormat()->setLatinFont($fd1);
    $port2->getPortionFormat()->setLatinFont($fd2);
    # Définir la police sur Gras
    $port1->getPortionFormat()->setFontBold(NullableBool::True);
    $port2->getPortionFormat()->setFontBold(NullableBool::True);
    # Définir la police sur Italique
    $port1->getPortionFormat()->setFontItalic(NullableBool::True);
    $port2->getPortionFormat()->setFontItalic(NullableBool::True);
    # Définir la couleur de la police
    $port1->getPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
    $port1->getPortionFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->MAGENTA);
    $port2->getPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
    $port2->getPortionFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->ORANGE);
    # Écrire le PPTX sur le disque
    $pres->save("WelcomeFont_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Gérer la Famille de Polices de Texte**
Une portion est utilisée pour contenir du texte avec un style de formatage similaire dans un paragraphe. Cet article montre comment utiliser Aspose.Slides pour PHP via Java pour créer une zone de texte avec du texte et définir une police particulière, ainsi que diverses autres propriétés de la catégorie de famille de polices. Pour créer une zone de texte et définir les propriétés de police du texte qui y est contenu :

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation).
2. Obtenez la référence d'une diapositive en utilisant son index.
3. Ajoutez un [IAutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/IAutoShape) de type [Rectangle](https://reference.aspose.com/slides/php-java/aspose.slides/ShapeType#Rectangle) à la diapositive.
4. Supprimez le style de remplissage associé à l'[IAutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/IAutoShape).
5. Accédez au TextFrame de l'AutoShape.
6. Ajoutez du texte au TextFrame.
7. Accédez à l'objet Portion associé à l'[ITextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/IAutoShape).
8. Définissez la police à utiliser pour la [Portion](https://reference.aspose.com/slides/php-java/aspose.slides/IPortion).
9. Définissez d'autres propriétés de police comme le gras, l'italique, le soulignement, la couleur et la hauteur en utilisant les propriétés pertinentes exposées par l'objet Portion.
10. Écrivez la présentation modifiée en tant que fichier PPTX.

L'implémentation des étapes ci-dessus est donnée ci-dessous.

```php
  # Instancier Presentation
  $pres = new Presentation();
  try {
    # Obtenir la première diapositive
    $sld = $pres->getSlides()->get_Item(0);
    # Ajouter un AutoShape de type Rectangle
    $ashp = $sld->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 50, 200, 50);
    # Supprimer tout style de remplissage associé à l'AutoShape
    $ashp->getFillFormat()->setFillType(FillType::NoFill);
    # Accéder au TextFrame associé à l'AutoShape
    $tf = $ashp->getTextFrame();
    $tf->setText("Zone de texte Aspose");
    # Accéder à la Portion associée au TextFrame
    $port = $tf->getParagraphs()->get_Item(0)->getPortions()->get_Item(0);
    # Définir la police pour la Portion
    $port->getPortionFormat()->setLatinFont(new FontData("Times New Roman"));
    # Définir la propriété Gras de la police
    $port->getPortionFormat()->setFontBold(NullableBool::True);
    # Définir la propriété Italique de la police
    $port->getPortionFormat()->setFontItalic(NullableBool::True);
    # Définir la propriété Souligné de la police
    $port->getPortionFormat()->setFontUnderline(TextUnderlineType::Single);
    # Définir la Hauteur de la police
    $port->getPortionFormat()->setFontHeight(25);
    # Définir la couleur de la police
    $port->getPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
    $port->getPortionFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLUE);
    # Écrire le PPTX sur le disque
    $pres->save("SetTextFontProperties_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Définir la Taille de Police pour le Texte**

Aspose.Slides vous permet de choisir votre taille de police préférée pour le texte existant dans un paragraphe et pour d'autres textes qui pourraient être ajoutés au paragraphe ultérieurement.

Ce code PHP vous montre comment définir la taille de la police pour les textes contenus dans un paragraphe :

```php
  $presentation = new Presentation("example.pptx");
  try {
    # Obtient la première forme, par exemple.
    $shape = $presentation->getSlides()->get_Item(0)->getShapes()->get_Item(0);
    if (java_instanceof($shape, new JavaClass("com.aspose.slides.AutoShape"))) {
      $autoShape = $shape;
      # Obtient le premier paragraphe, par exemple.
      $paragraph = $autoShape->getTextFrame()->getParagraphs()->get_Item(0);
      # Définit la taille de police par défaut à 20 pt pour toutes les portions de texte dans le paragraphe.
      $paragraph->getParagraphFormat()->getDefaultPortionFormat()->setFontHeight(20);
      # Définit la taille de la police à 20 pt pour les portions de texte actuelles dans le paragraphe.
      foreach($paragraph->getPortions() as $portion) {
        $portion->getPortionFormat()->setFontHeight(20);
      }
    }
  } finally {
    if (!java_is_null($presentation)) {
      $presentation->dispose();
    }
  }
```

## **Définir la Rotation du Texte**

Aspose.Slides pour PHP via Java permet aux développeurs de faire pivoter le texte. Le texte peut être défini pour apparaître comme [Horizontal](https://reference.aspose.com/slides/php-java/aspose.slides/TextVerticalType#Horizontal), [Vertical](https://reference.aspose.com/slides/php-java/aspose.slides/TextVerticalType#Vertical), [Vertical270](https://reference.aspose.com/slides/php-java/aspose.slides/TextVerticalType#Vertical270), [WordArtVertical](https://reference.aspose.com/slides/php-java/aspose.slides/TextVerticalType#WordArtVertical), [EastAsianVertical](https://reference.aspose.com/slides/php-java/aspose.slides/TextVerticalType#EastAsianVertical), [MongolianVertical](https://reference.aspose.com/slides/php-java/aspose.slides/TextVerticalType#MongolianVertical) ou [WordArtVerticalRightToLeft](https://reference.aspose.com/slides/php-java/aspose.slides/TextVerticalType#WordArtVerticalRightToLeft). Pour faire pivoter le texte d'un TextFrame, veuillez suivre les étapes ci-dessous :

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation).
2. Accédez à la première diapositive.
3. Ajoutez n'importe quelle forme à la diapositive.
4. Accédez à l'[ITextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/IAutoShape).
5. [Faites pivoter le texte](https://reference.aspose.com/slides/php-java/aspose.slides/ITextFrameFormat#setTextVerticalType-byte-).
6. Enregistrez le fichier sur le disque.

```php
  # Créer une instance de la classe Presentation
  $pres = new Presentation();
  try {
    # Obtenez la première diapositive
    $slide = $pres->getSlides()->get_Item(0);
    # Ajoutez un AutoShape de type Rectangle
    $ashp = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 150, 75, 350, 350);
    # Ajoutez un TextFrame au Rectangle
    $ashp->addTextFrame("");
    $ashp->getFillFormat()->setFillType(FillType::NoFill);
    # Accédez au cadre de texte
    $txtFrame = $ashp->getTextFrame();
    $txtFrame->getTextFrameFormat()->setTextVerticalType(TextVerticalType::Vertical270);
    # Créez l'objet Paragraph pour le cadre de texte
    $para = $txtFrame->getParagraphs()->get_Item(0);
    # Créez l'objet Portion pour le paragraphe
    $portion = $para->getPortions()->get_Item(0);
    $portion->setText("Un renard brun rapide saute par-dessus le chien paresseux. Un renard brun rapide saute par-dessus le chien paresseux.");
    $portion->getPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
    $portion->getPortionFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLACK);
    # Enregistrez la présentation
    $pres->save("RotateText_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Définir l'Angle de Rotation Personnalisé pour le TextFrame**
Aspose.Slides pour PHP via Java prend désormais en charge, la définition d'un angle de rotation personnalisé pour le cadre de texte. Dans ce sujet, nous allons voir avec exemple comment définir la propriété RotationAngle dans Aspose.Slides. Les nouvelles méthodes [setRotationAngle](https://reference.aspose.com/slides/php-java/aspose.slides/ITextFrameFormat#setRotationAngle-float-) et [getRotationAngle](https://reference.aspose.com/slides/php-java/aspose.slides/ITextFrameFormat#getRotationAngle--) ont été ajoutées aux interfaces [IChartTextBlockFormat](https://reference.aspose.com/slides/php-java/aspose.slides/IChartTextBlockFormat) et [ITextFrameFormat](https://reference.aspose.com/slides/php-java/aspose.slides/ITextFrameFormat), permettant de définir l'angle de rotation personnalisé pour le cadre de texte. Pour définir le RotationAngle, veuillez suivre les étapes ci-dessous :

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation).
2. Ajoutez un graphique sur la diapositive.
3. [Définissez la propriété RotationAngle](https://reference.aspose.com/slides/php-java/aspose.slides/ITextFrameFormat#setRotationAngle-float-).
4. Écrivez la présentation en tant que fichier PPTX.

Dans l'exemple ci-dessous, nous définissons la propriété RotationAngle.

```php
  # Créer une instance de la classe Presentation
  $pres = new Presentation();
  try {
    # Obtenez la première diapositive
    $slide = $pres->getSlides()->get_Item(0);
    # Ajoutez un AutoShape de type Rectangle
    $ashp = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 150, 75, 350, 350);
    # Ajoutez un TextFrame au Rectangle
    $ashp->addTextFrame("");
    $ashp->getFillFormat()->setFillType(FillType::NoFill);
    # Accédez au cadre de texte
    $txtFrame = $ashp->getTextFrame();
    $txtFrame->getTextFrameFormat()->setRotationAngle(25);
    # Créez l'objet Paragraph pour le cadre de texte
    $para = $txtFrame->getParagraphs()->get_Item(0);
    # Créez l'objet Portion pour le paragraphe
    $portion = $para->getPortions()->get_Item(0);
    $portion->setText("Exemple de rotation de texte.");
    $portion->getPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
    $portion->getPortionFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLACK);
    # Enregistrez la Présentation
    $pres->save($resourcesOutputPath . "RotateText_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Espacement des Lignes de Paragraphe**
Aspose.Slides fournit des propriétés sous [`ParagraphFormat`](https://reference.aspose.com/slides/php-java/aspose.slides/IParagraphFormat) — `SpaceAfter`, `SpaceBefore` et `SpaceWithin` — qui vous permettent de gérer l'espacement des lignes pour un paragraphe. Les trois propriétés sont utilisées de cette manière :

* Pour spécifier l'espacement des lignes pour un paragraphe en pourcentage, utilisez une valeur positive. 
* Pour spécifier l'espacement des lignes pour un paragraphe en points, utilisez une valeur négative.

Par exemple, vous pouvez appliquer un espacement de ligne de 16pt pour un paragraphe en définissant la propriété `SpaceBefore` à -16.

Voici comment spécifier l'espacement des lignes pour un paragraphe spécifique :

1. Chargez une présentation contenant un AutoShape avec du texte à l'intérieur.
2. Obtenez la référence d'une diapositive par son index.
3. Accédez au TextFrame.
4. Accédez au Paragraphe.
5. Définissez les propriétés du Paragraphe.
6. Enregistrez la présentation.

Ce code PHP vous montre comment spécifier l'espacement des lignes pour un paragraphe :

```php
  # Créer une instance de la classe Presentation
  $pres = new Presentation("Fonts.pptx");
  try {
    # Obtenez la référence d'une diapositive par son index
    $sld = $pres->getSlides()->get_Item(0);
    # Accédez au TextFrame
    $tf1 = $sld->getShapes()->get_Item(0)->getTextFrame();
    # Accédez au Paragraphe
    $para = $tf1->getParagraphs()->get_Item(0);
    # Définissez les propriétés du Paragraphe
    $para->getParagraphFormat()->setSpaceWithin(80);
    $para->getParagraphFormat()->setSpaceBefore(40);
    $para->getParagraphFormat()->setSpaceAfter(40);
    # Enregistrez la Présentation
    $pres->save("LineSpacing_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Définir la Propriété AutofitType pour le TextFrame**
Dans ce sujet, nous allons explorer les différentes propriétés de formatage du cadre de texte. Cet article traite de la façon de définir la propriété AutofitType du cadre de texte, de l'ancrage du texte et de la rotation du texte dans la présentation. Aspose.Slides pour PHP via Java permet aux développeurs de définir la propriété AutofitType de tout cadre de texte. AutofitType peut être défini sur [Normal](https://reference.aspose.com/slides/php-java/aspose.slides/TextAutofitType#Normal) ou [Shape](https://reference.aspose.com/slides/php-java/aspose.slides/TextAutofitType#Shape). S'il est défini sur [Normal](https://reference.aspose.com/slides/php-java/aspose.slides/TextAutofitType#Normal), le cadre restera le même tandis que le texte sera ajusté sans que le cadre change lui-même ; tandis que si AutofitType est défini sur [Shape](https://reference.aspose.com/slides/php-java/aspose.slides/TextAutofitType#Shape), le cadre sera modifié de sorte que seul le texte requis soit contenu à l'intérieur. Pour définir la propriété AutofitType d'un cadre de texte, veuillez suivre les étapes ci-dessous :

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation).
2. Accédez à la première diapositive.
3. Ajoutez n'importe quelle forme à la diapositive.
4. Accédez à l'[ITextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/IAutoShape).
5. [Définissez l'AutofitType](https://reference.aspose.com/slides/php-java/aspose.slides/ITextFrameFormat#setAutofitType-byte-) du TextFrame.
6. Enregistrez le fichier sur le disque.

```php
  # Créer une instance de la classe Presentation
  $pres = new Presentation();
  try {
    # Accédez à la première diapositive
    $slide = $pres->getSlides()->get_Item(0);
    # Ajoutez un AutoShape de type Rectangle
    $ashp = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 150, 75, 350, 150);
    # Ajoutez un TextFrame au Rectangle
    $ashp->addTextFrame("");
    $ashp->getFillFormat()->setFillType(FillType::NoFill);
    # Accédez au cadre de texte
    $txtFrame = $ashp->getTextFrame();
    $txtFrame->getTextFrameFormat()->setAutofitType(TextAutofitType::Shape);
    # Créez l'objet Paragraph pour le cadre de texte
    $para = $txtFrame->getParagraphs()->get_Item(0);
    # Créez l'objet Portion pour le paragraphe
    $portion = $para->getPortions()->get_Item(0);
    $portion->setText("Un renard brun rapide saute par-dessus le chien paresseux. Un renard brun rapide saute par-dessus le chien paresseux.");
    $portion->getPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
    $portion->getPortionFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLACK);
    # Enregistrez la Présentation
    $pres->save($resourcesOutputPath . "formatText_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Définir l'Ancrage du TextFrame**
Aspose.Slides pour PHP via Java permet aux développeurs de définir l'ancrage de tout TextFrame. TextAnchorType précise où le texte est placé dans la forme. Le type d'ancrage peut être défini sur [Top](https://reference.aspose.com/slides/php-java/aspose.slides/TextAnchorType#Top), [Center](https://reference.aspose.com/slides/php-java/aspose.slides/TextAnchorType#Center), [Bottom](https://reference.aspose.com/slides/php-java/aspose.slides/TextAnchorType#Bottom), [Justified](https://reference.aspose.com/slides/php-java/aspose.slides/TextAnchorType#Justified) ou [Distributed](https://reference.aspose.com/slides/php-java/aspose.slides/TextAnchorType#Distributed). Pour définir l'ancrage de tout TextFrame, veuillez suivre les étapes ci-dessous :

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation).
2. Accédez à la première diapositive.
3. Ajoutez n'importe quelle forme à la diapositive.
4. Accédez à l'[ITextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/IAutoShape).
5. [Définissez le TextAnchorType](https://reference.aspose.com/slides/php-java/aspose.slides/ITextFrameFormat#setAnchoringType-byte-) du TextFrame.
6. Enregistrez le fichier sur le disque.

```php
  # Créer une instance de la classe Presentation
  $pres = new Presentation();
  try {
    # Obtenez la première diapositive
    $slide = $pres->getSlides()->get_Item(0);
    # Ajoutez un AutoShape de type Rectangle
    $ashp = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 150, 75, 350, 350);
    # Ajoutez un TextFrame au Rectangle
    $ashp->addTextFrame("");
    $ashp->getFillFormat()->setFillType(FillType::NoFill);
    # Accédez au cadre de texte
    $txtFrame = $ashp->getTextFrame();
    $txtFrame->getTextFrameFormat()->setAnchoringType(TextAnchorType::Bottom);
    # Créez l'objet Paragraph pour le cadre de texte
    $para = $txtFrame->getParagraphs()->get_Item(0);
    # Créez l'objet Portion pour le paragraphe
    $portion = $para->getPortions()->get_Item(0);
    $portion->setText("Un renard brun rapide saute par-dessus le chien paresseux. Un renard brun rapide saute par-dessus le chien paresseux.");
    $portion->getPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
    $portion->getPortionFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLACK);
    # Enregistrez la Présentation
    $pres->save("AnchorText_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Tabs et EffectiveTabs dans la Présentation**
Toutes les tabulations de texte sont données en pixels.

|![todo:image_alt_text](http://i.imgur.com/POpc1Lw.png)|
| :- |
|**Figure : 2 Tabs explicites et 2 Tabs par défaut**|
- La propriété EffectiveTabs.ExplicitTabCount (2 dans notre cas) est égale à Tabs.Count.
- La collection EffectiveTabs comprend tous les tabulations (de la collection Tabs et des tabs par défaut).
- La propriété EffectiveTabs.ExplicitTabCount (2 dans notre cas) est égale à Tabs.Count.
- La propriété EffectiveTabs.DefaultTabSize (294) montre la distance entre les tabs par défaut (3 et 4 dans notre exemple).
- EffectiveTabs.GetTabByIndex(index) avec index = 0 renverra le premier tab explicite (Position = 731), index = 1 - deuxième tab (Position = 1241). Si vous essayez d'obtenir le tab suivant avec index = 2, il renverra le premier tab par défaut (Position = 1470) et ainsi de suite.
- EffectiveTabs.GetTabAfterPosition(pos) utilisé pour obtenir la prochaine tabulation après un certain texte. Par exemple, vous avez le texte : "Bonjour le monde !". Pour rendre ce texte, vous devez savoir où commencer à dessiner "le monde !". D'abord, vous devez calculer la longueur de "Bonjour" en pixels et appeler GetTabAfterPosition avec cette valeur. Vous obtiendrez la prochaine position de tabulation pour dessiner "le monde !".