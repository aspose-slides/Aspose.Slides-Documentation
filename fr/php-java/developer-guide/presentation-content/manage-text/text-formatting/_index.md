---
title: Formater le texte PowerPoint en PHP
linktitle: Mise en forme du texte
type: docs
weight: 50
url: /fr/php-java/text-formatting/
keywords:
- surligner le texte
- expression régulière
- aligner le paragraphe
- style de texte
- arrière-plan du texte
- transparence du texte
- espacement des caractères
- propriétés de police
- famille de police
- rotation du texte
- angle de rotation
- cadre de texte
- interligne
- propriété autofit
- ancrage du cadre de texte
- tabulation du texte
- langue par défaut
- PowerPoint
- OpenDocument
- présentation
- PHP
- Aspose.Slides
description: "Formatez et stylisez le texte dans les présentations PowerPoint et OpenDocument à l'aide d'Aspose.Slides pour PHP via Java. Personnalisez les polices, les couleurs, l'alignement, etc."
---

## **Surligner le texte**
La méthode [highlightText](https://reference.aspose.com/slides/php-java/aspose.slides/ITextFrame#highlightText-java.lang.String-java.awt.Color-) a été ajoutée à l'interface [ITextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/ITextFrame) et à la classe [TextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/TextFrame).

Elle permet de mettre en surbrillance une partie du texte avec une couleur de fond en utilisant un exemple de texte, similaire à l'outil de couleur de surbrillance du texte dans PowerPoint 2019.

Le fragment de code ci‑dessous montre comment utiliser cette fonctionnalité :
```php
  $pres = new Presentation("Presentation.pptx");
  try {
    $textHighlightingOptions = new TextHighlightingOptions();
    $textHighlightingOptions->setWholeWordsOnly(true);
    $pres->getSlides()->get_Item(0)->getShapes()->get_Item(0)->getTextFrame()->highlightText("title", java("java.awt.Color")->BLUE);// mise en évidence de tous les mots 'important'

    $pres->getSlides()->get_Item(0)->getShapes()->get_Item(0)->getTextFrame()->highlightText("to", java("java.awt.Color")->MAGENTA, $textHighlightingOptions);// mise en évidence de toutes les occurrences séparées de 'the'

    $pres->save("OutputPresentation-highlight.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


{{% alert color="primary" %}} 
Aspose propose un service simple et [gratuit d'édition en ligne de PowerPoint](https://products.aspose.app/slides/editor)
{{% /alert %}} 

## **Surligner le texte à l'aide d'une expression régulière**
La méthode [highlightRegex](https://reference.aspose.com/slides/php-java/aspose.slides/ITextFrame#highlightRegex-java.lang.String-java.awt.Color-com.aspose.slides.ITextHighlightingOptions-) a été ajoutée à l'interface [ITextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/ITextFrame) et à la classe [TextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/TextFrame).

Elle permet de mettre en surbrillance une partie du texte avec une couleur de fond en utilisant une expression régulière, similaire à l'outil de couleur de surbrillance du texte dans PowerPoint 2019.

Le fragment de code ci‑dessous montre comment utiliser cette fonctionnalité :
```php
  $pres = new Presentation("Presentation.pptx");
  try {
    $options = new TextHighlightingOptions();
    $pres->getSlides()->get_Item(0)->getShapes()->get_Item(0)->getTextFrame()->highlightRegex("\\b[^\\s]{4}\\b", java("java.awt.Color")->YELLOW, $options);// mise en évidence de tous les mots de 10 symboles ou plus

    $pres->save("OutputPresentation-highlight.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **Définir la couleur d'arrière‑plan du texte**
Aspose.Slides vous permet de spécifier la couleur de votre choix pour l'arrière‑plan d'un texte.

Ce code PHP montre comment définir la couleur d'arrière‑plan pour l’ensemble du texte :
```php
  $pres = new Presentation();
  try {
    $autoShape = $pres->getSlides()->get_Item(0)->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 50, 200, 100);
    $autoShape->getTextFrame()->getParagraphs()->clear();
    $para = new Paragraph();
    $portion1 = new Portion("Black");
    $portion1->getPortionFormat()->setFontBold(NullableBool::True);
    $portion2 = new Portion(" Red ");
    $portion3 = new Portion("Black");
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


Ce code PHP montre comment définir la couleur d'arrière‑plan pour une seule partie du texte :
```php
  $pres = new Presentation();
  try {
    $autoShape = $pres->getSlides()->get_Item(0)->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 50, 200, 100);
    $autoShape->getTextFrame()->getParagraphs()->clear();
    $para = new Paragraph();
    $portion1 = new Portion("Black");
    $portion1->getPortionFormat()->setFontBold(NullableBool::True);
    $portion2 = new Portion(" Red ");
    $portion3 = new Portion("Black");
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
    $redPortion = StreamSupport->stream($autoShape->getTextFrame()->getParagraphs()->get_Item(0)->getPortions()->spliterator(), false)->filter(( p) -> $p->getText()->contains("Red"))->findFirst();
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


## **Aligner les paragraphes de texte**
Le formatage du texte est l’un des éléments clés lors de la création de documents ou de présentations. Nous savons qu’Aspose.Slides for PHP via Java prend en charge l’ajout de texte aux diapositives, mais dans ce sujet, nous verrons comment contrôler l’alignement des paragraphes de texte dans une diapositive. Veuillez suivre les étapes ci‑dessous pour aligner les paragraphes de texte avec Aspose.Slides for PHP via Java :

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation).
2. Obtenez la référence d’une diapositive en utilisant son index.
3. Accédez aux formes d’espace réservé présentes dans la diapositive et castpez‑les en tant que [AutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/AutoShape).
4. Récupérez le paragraphe (qui doit être aligné) depuis le [TextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/IAutoShape#getTextFrame--) exposé par [AutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/AutoShape).
5. Alignez le paragraphe. Un paragraphe peut être aligné à Droite, Gauche, Centre ou Justifié.
6. Enregistrez la présentation modifiée sous forme de fichier PPTX.

L’implémentation des étapes ci‑dessus est donnée ci‑dessous.
```php
  # Instancier un objet Presentation qui représente un fichier PPTX
  $pres = new Presentation("ParagraphsAlignment.pptx");
  try {
    # Accéder à la première diapositive
    $slide = $pres->getSlides()->get_Item(0);
    # Accéder au premier et au deuxième espace réservé dans la diapositive et le convertir en AutoShape
    $tf1 = $slide->getShapes()->get_Item(0)->getTextFrame();
    $tf2 = $slide->getShapes()->get_Item(1)->getTextFrame();
    # Modifier le texte dans les deux espaces réservés
    $tf1->setText("Center Align by Aspose");
    $tf2->setText("Center Align by Aspose");
    # Récupérer le premier paragraphe des espaces réservés
    $para1 = $tf1->getParagraphs()->get_Item(0);
    $para2 = $tf2->getParagraphs()->get_Item(0);
    # Aligner le paragraphe de texte au centre
    $para1->getParagraphFormat()->setAlignment(TextAlignment->Center);
    $para2->getParagraphFormat()->setAlignment(TextAlignment->Center);
    # Enregistrer la présentation en fichier PPTX
    $pres->save("Centeralign_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **Définir la transparence du texte**
Cet article montre comment définir la propriété de transparence d’une forme de texte à l’aide d’Aspose.Slides for PHP via Java. Pour définir la transparence du texte, suivez les étapes ci‑dessous :

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation).
2. Récupérez la référence d’une diapositive.
3. Définissez la couleur de l’ombre.
4. Enregistrez la présentation sous forme de fichier PPTX.

L’implémentation des étapes ci‑dessus est donnée ci‑dessous.
```php
  $pres = new Presentation("transparency.pptx");
  try {
    $shape = $pres->getSlides()->get_Item(0)->getShapes()->get_Item(0);
    $effects = $shape->getTextFrame()->getParagraphs()->get_Item(0)->getPortions()->get_Item(0)->getPortionFormat()->getEffectFormat();
    $outerShadowEffect = $effects->getOuterShadowEffect();
    $shadowColor = $outerShadowEffect->getShadowColor()->getColor();
    echo($shadowColor->toString() . " - transparency is: " . $shadowColor->getAlpha() / 255.0 * 100);
    # définir la transparence à zéro pour cent
    $outerShadowEffect->getShadowColor()->setColor(new java("java.awt.Color", $shadowColor->getRed(), $shadowColor->getGreen(), $shadowColor->getBlue(), 255));
    $pres->save("transparency-2.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **Définir l’espacement des caractères du texte**
Aspose.Slides vous permet de définir l’espace entre les lettres dans une zone de texte. Ainsi, vous pouvez ajuster la densité visuelle d’une ligne ou d’un bloc de texte en élargissant ou en contractant l’espacement entre les caractères.

Ce code PHP montre comment augmenter l’espacement pour une ligne de texte et le réduire pour une autre ligne :
```php
  $presentation = new Presentation("in.pptx");
  $textBox1 = $presentation->getSlides()->get_Item(0)->getShapes()->get_Item(0);
  $textBox2 = $presentation->getSlides()->get_Item(0)->getShapes()->get_Item(1);
  $textBox1->getTextFrame()->getParagraphs()->get_Item(0)->getParagraphFormat()->getDefaultPortionFormat()->setSpacing(20);// agrandir

  $textBox2->getTextFrame()->getParagraphs()->get_Item(0)->getParagraphFormat()->getDefaultPortionFormat()->setSpacing(-2);// réduire

  $presentation->save("out.pptx", SaveFormat::Pptx);
```


## **Gérer les propriétés de police d’un paragraphe**
Les présentations contiennent généralement du texte et des images. Le texte peut être formaté de diverses manières, que ce soit pour mettre en évidence des sections spécifiques ou pour se conformer aux styles d’entreprise. Le formatage du texte aide les utilisateurs à varier l’apparence du contenu de la présentation. Cet article montre comment utiliser Aspose.Slides for PHP via Java pour configurer les propriétés de police des paragraphes de texte sur les diapositives. Pour gérer les propriétés de police d’un paragraphe avec Aspose.Slides for PHP via Java :

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation).
1. Obtenez la référence d’une diapositive en utilisant son index.
1. Accédez aux formes d’espace réservé dans la diapositive et castpez‑les en [IAutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/IAutoShape).
1. Récupérez le [Paragraph](https://reference.aspose.com/slides/php-java/aspose.slides/ITextFrame) depuis le [ITextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/ITextFrame) exposé par [IAutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/IAutoShape).
1. Justifiez le paragraphe.
1. Accédez au Portion de texte du paragraphe.
1. Définissez la police à l’aide de FontData et appliquez‑la au Portion de texte correspondant.
   1. Mettez la police en gras.
   1. Mettez la police en italique.
1. Définissez la couleur de la police à l’aide de la méthode [getFillFormat](https://reference.aspose.com/slides/php-java/aspose.slides/IBasePortionFormat#getFillFormat--) exposée par l’objet [Portion](https://reference.aspose.com/slides/php-java/aspose.slides/IPortion).
1. Enregistrez la présentation modifiée dans un fichier [PPTX](https://docs.fileformat.com/presentation/pptx/).

L’implémentation des étapes ci‑dessus est donnée ci‑dessous. Elle prend une présentation sans mise en forme et applique les polices sur l’une des diapositives.
```php
  # Instancier un objet Presentation qui représente un fichier PPTX
  $pres = new Presentation("FontProperties.pptx");
  try {
    # Accéder à une diapositive en utilisant sa position
    $slide = $pres->getSlides()->get_Item(0);
    # Accéder au premier et au deuxième espace réservé dans la diapositive et le convertir en AutoShape
    $tf1 = $slide->getShapes()->get_Item(0)->getTextFrame();
    $tf2 = $slide->getShapes()->get_Item(1)->getTextFrame();
    # Accéder au premier paragraphe
    $para1 = $tf1->getParagraphs()->get_Item(0);
    $para2 = $tf2->getParagraphs()->get_Item(0);
    # Accéder à la première portion
    $port1 = $para1->getPortions()->get_Item(0);
    $port2 = $para2->getPortions()->get_Item(0);
    # Définir de nouvelles polices
    $fd1 = new FontData("Elephant");
    $fd2 = new FontData("Castellar");
    # Attribuer les nouvelles polices à la portion
    $port1->getPortionFormat()->setLatinFont($fd1);
    $port2->getPortionFormat()->setLatinFont($fd2);
    # Définir la police en gras
    $port1->getPortionFormat()->setFontBold(NullableBool::True);
    $port2->getPortionFormat()->setFontBold(NullableBool::True);
    # Définir la police en italique
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


## **Gérer la famille de polices du texte**
Un Portion est utilisé pour regrouper du texte possédant le même style de mise en forme dans un paragraphe. Cet article montre comment, avec Aspose.Slides for PHP via Java, créer une zone de texte contenant du texte, puis définir une police particulière ainsi que diverses propriétés de la catégorie de famille de polices. Pour créer une zone de texte et définir les propriétés de police du texte qu’elle contient :

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation).
2. Obtenez la référence d’une diapositive en utilisant son index.
3. Ajoutez à la diapositive un [IAutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/IAutoShape) de type [Rectangle](https://reference.aspose.com/slides/php-java/aspose.slides/ShapeType#Rectangle).
4. Supprimez le style de remplissage associé à l’[IAutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/IAutoShape).
5. Accédez au TextFrame de l’AutoShape.
6. Ajoutez du texte au TextFrame.
7. Accédez à l’objet Portion associé au [ITextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/IAutoShape).
8. Définissez la police à utiliser pour le [Portion](https://reference.aspose.com/slides/php-java/aspose.slides/IPortion).
9. Définissez d’autres propriétés de police telles que gras, italique, souligné, couleur et taille à l’aide des propriétés correspondantes exposées par l’objet Portion.
10. Enregistrez la présentation modifiée dans un fichier PPTX.

L’implémentation des étapes ci‑dessus est donnée ci‑dessus.
```php
  # Instancier une présentation
  $pres = new Presentation();
  try {
    # Obtenir la première diapositive
    $sld = $pres->getSlides()->get_Item(0);
    # Ajouter une AutoShape de type Rectangle
    $ashp = $sld->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 50, 200, 50);
    # Supprimer tout style de remplissage associé à l'AutoShape
    $ashp->getFillFormat()->setFillType(FillType::NoFill);
    # Accéder au TextFrame associé à l'AutoShape
    $tf = $ashp->getTextFrame();
    $tf->setText("Aspose TextBox");
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
    # Définir la hauteur de la police
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


## **Définir la taille de police du texte**
Aspose.Slides vous permet de choisir la taille de police souhaitée pour le texte existant dans un paragraphe ainsi que pour tout texte ajouté ultérieurement au paragraphe.

Ce code PHP montre comment définir la taille de police pour le texte contenu dans un paragraphe :
```php
  $presentation = new Presentation("example.pptx");
  try {
    # Obtient la première forme, par exemple.
    $shape = $presentation->getSlides()->get_Item(0)->getShapes()->get_Item(0);
    if (java_instanceof($shape, new JavaClass("com.aspose.slides.AutoShape"))) {
      $autoShape = $shape;
      # Obtient le premier paragraphe, par exemple.
      $paragraph = $autoShape->getTextFrame()->getParagraphs()->get_Item(0);
      # Définit la taille de police par défaut à 20 pt pour toutes les portions de texte du paragraphe.
      $paragraph->getParagraphFormat()->getDefaultPortionFormat()->setFontHeight(20);
      # Définit la taille de police à 20 pt pour les portions de texte actuelles du paragraphe.
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


## **Définir la rotation du texte**
Aspose.Slides for PHP via Java permet aux développeurs de faire pivoter le texte. Le texte peut être affiché en [Horizontal](https://reference.aspose.com/slides/php-java/aspose.slides/TextVerticalType#Horizontal), [Vertical](https://reference.aspose.com/slides/php-java/aspose.slides/TextVerticalType#Vertical), [Vertical270](https://reference.aspose.com/slides/php-java/aspose.slides/TextVerticalType#Vertical270), [WordArtVertical](https://reference.aspose.com/slides/php-java/aspose.slides/TextVerticalType#WordArtVertical), [EastAsianVertical](https://reference.aspose.com/slides/php-java/aspose.slides/TextVerticalType#EastAsianVertical), [MongolianVertical](https://reference.aspose.com/slides/php-java/aspose.slides/TextVerticalType#MongolianVertical) ou [WordArtVerticalRightToLeft](https://reference.aspose.com/slides/php-java/aspose.slides/TextVerticalType#WordArtVerticalRightToLeft). Pour faire pivoter le texte de n’importe quel TextFrame, suivez les étapes ci‑dessous :

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation).
2. Accédez à la première diapositive.
3. Ajoutez n’importe quelle forme à la diapositive.
4. Accédez au [ITextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/IAutoShape).
5. [Faire pivoter le texte](https://reference.aspose.com/slides/php-java/aspose.slides/ITextFrameFormat#setTextVerticalType-byte-).
6. Enregistrez le fichier sur le disque.
```php
  # Créer une instance de la classe Presentation
  $pres = new Presentation();
  try {
    # Obtenir la première diapositive
    $slide = $pres->getSlides()->get_Item(0);
    # Ajouter une AutoShape de type Rectangle
    $ashp = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 150, 75, 350, 350);
    # Ajouter un TextFrame au Rectangle
    $ashp->addTextFrame("");
    $ashp->getFillFormat()->setFillType(FillType::NoFill);
    # Accéder au TextFrame
    $txtFrame = $ashp->getTextFrame();
    $txtFrame->getTextFrameFormat()->setTextVerticalType(TextVerticalType::Vertical270);
    # Créer l'objet Paragraph pour le TextFrame
    $para = $txtFrame->getParagraphs()->get_Item(0);
    # Créer l'objet Portion pour le paragraphe
    $portion = $para->getPortions()->get_Item(0);
    $portion->setText("A quick brown fox jumps over the lazy dog. A quick brown fox jumps over the lazy dog.");
    $portion->getPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
    $portion->getPortionFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLACK);
    # Enregistrer la présentation
    $pres->save("RotateText_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **Définir un angle de rotation personnalisé pour un TextFrame**
Aspose.Slides for PHP via Java prend désormais en charge la définition d’un angle de rotation personnalisé pour un TextFrame. Dans ce sujet, nous verrons, à l’aide d’un exemple, comment définir la propriété RotationAngle dans Aspose.Slides. Les nouvelles méthodes [setRotationAngle](https://reference.aspose.com/slides/php-java/aspose.slides/ITextFrameFormat#setRotationAngle-float-) et [getRotationAngle](https://reference.aspose.com/slides/php-java/aspose.slides/ITextFrameFormat#getRotationAngle--) ont été ajoutées aux interfaces [IChartTextBlockFormat](https://reference.aspose.com/slides/php-java/aspose.slides/IChartTextBlockFormat) et [ITextFrameFormat](https://reference.aspose.com/slides/php-java/aspose.slides/ITextFrameFormat), permettant de définir l’angle de rotation personnalisé pour un TextFrame. Pour définir la propriété RotationAngle, suivez les étapes ci‑dessous :

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation).
2. Ajoutez un graphique à la diapositive.
3. [Définir la propriété RotationAngle](https://reference.aspose.com/slides/php-java/aspose.slides/ITextFrameFormat#setRotationAngle-float-).
4. Enregistrez la présentation sous forme de fichier PPTX.

Dans l’exemple ci‑dessous, nous définissons la propriété RotationAngle.
```php
  # Créer une instance de la classe Presentation
  $pres = new Presentation();
  try {
    # Obtenir la première diapositive
    $slide = $pres->getSlides()->get_Item(0);
    # Ajouter une AutoShape de type Rectangle
    $ashp = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 150, 75, 350, 350);
    # Ajouter un TextFrame au Rectangle
    $ashp->addTextFrame("");
    $ashp->getFillFormat()->setFillType(FillType::NoFill);
    # Accéder au TextFrame
    $txtFrame = $ashp->getTextFrame();
    $txtFrame->getTextFrameFormat()->setRotationAngle(25);
    # Créer l'objet Paragraph pour le TextFrame
    $para = $txtFrame->getParagraphs()->get_Item(0);
    # Créer l'objet Portion pour le paragraphe
    $portion = $para->getPortions()->get_Item(0);
    $portion->setText("Text rotation example.");
    $portion->getPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
    $portion->getPortionFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLACK);
    # Enregistrer la présentation
    $pres->save($resourcesOutputPath . "RotateText_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **Interligne d’un paragraphe**
Aspose.Slides propose des propriétés sous [`ParagraphFormat`](https://reference.aspose.com/slides/php-java/aspose.slides/IParagraphFormat)—`SpaceAfter`, `SpaceBefore` et `SpaceWithin`—qui permettent de gérer l’interligne d’un paragraphe. Les trois propriétés s’utilisent de la façon suivante :

* Pour spécifier l’interligne d’un paragraphe en pourcentage, utilisez une valeur positive.  
* Pour spécifier l’interligne d’un paragraphe en points, utilisez une valeur négative.

Par exemple, vous pouvez appliquer un interligne de 16 pt à un paragraphe en définissant la propriété `SpaceBefore` à -16.

Voici comment spécifier l’interligne d’un paragraphe particulier :

1. Chargez une présentation contenant une AutoShape avec du texte.
2. Obtenez la référence d’une diapositive via son index.
3. Accédez au TextFrame.
4. Accédez au Paragraph.
5. Définissez les propriétés du paragraphe.
6. Enregistrez la présentation.

Ce code PHP montre comment spécifier l’interligne d’un paragraphe :
```php
  # Créer une instance de la classe Presentation
  $pres = new Presentation("Fonts.pptx");
  try {
    # Obtenir la référence d'une diapositive par son index
    $sld = $pres->getSlides()->get_Item(0);
    # Accéder au TextFrame
    $tf1 = $sld->getShapes()->get_Item(0)->getTextFrame();
    # Accéder au paragraphe
    $para = $tf1->getParagraphs()->get_Item(0);
    # Définir les propriétés du paragraphe
    $para->getParagraphFormat()->setSpaceWithin(80);
    $para->getParagraphFormat()->setSpaceBefore(40);
    $para->getParagraphFormat()->setSpaceAfter(40);
    # Enregistrer la présentation
    $pres->save("LineSpacing_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **Définir la propriété AutofitType d’un TextFrame**
Dans ce sujet, nous explorerons les différentes propriétés de formatage d’un cadre de texte. Cet article explique comment définir la propriété AutofitType d’un cadre de texte, l’ancrage du texte et la rotation du texte dans une présentation. Aspose.Slides for PHP via Java permet aux développeurs de définir la propriété AutofitType de n’importe quel cadre de texte. AutofitType peut être réglé sur [Normal](https://reference.aspose.com/slides/php-java/aspose.slides/TextAutofitType#Normal) ou [Shape](https://reference.aspose.com/slides/php-java/aspose.slides/TextAutofitType#Shape). Si elle est réglée sur [Normal](https://reference.aspose.com/slides/php-java/aspose.slides/TextAutofitType#Normal), la forme reste inchangée tandis que le texte est ajusté sans modifier la forme. En revanche, si AutofitType est réglée sur [Shape](https://reference.aspose.com/slides/php-java/aspose.slides/TextAutofitType#Shape), la forme est modifiée de façon à ne contenir que le texte nécessaire. Pour définir la propriété AutofitType d’un cadre de texte, suivez les étapes ci‑dessus :

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation) .
2. Accédez à la première diapositive.
3. Ajoutez n’importe quelle forme à la diapositive.
4. Accédez au [ITextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/IAutoShape).
5. [Définir l’AutofitType](https://reference.aspose.com/slides/php-java/aspose.slides/ITextFrameFormat#setAutofitType-byte-) du TextFrame.
6. Enregistrez le fichier sur le disque.
```php
  # Créer une instance de la classe Presentation
  $pres = new Presentation();
  try {
    # Accéder à la première diapositive
    $slide = $pres->getSlides()->get_Item(0);
    # Ajouter une AutoShape de type Rectangle
    $ashp = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 150, 75, 350, 150);
    # Ajouter un TextFrame au Rectangle
    $ashp->addTextFrame("");
    $ashp->getFillFormat()->setFillType(FillType::NoFill);
    # Accéder au TextFrame
    $txtFrame = $ashp->getTextFrame();
    $txtFrame->getTextFrameFormat()->setAutofitType(TextAutofitType::Shape);
    # Créer l'objet Paragraph pour le TextFrame
    $para = $txtFrame->getParagraphs()->get_Item(0);
    # Créer l'objet Portion pour le paragraphe
    $portion = $para->getPortions()->get_Item(0);
    $portion->setText("A quick brown fox jumps over the lazy dog. A quick brown fox jumps over the lazy dog.");
    $portion->getPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
    $portion->getPortionFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLACK);
    # Enregistrer la présentation
    $pres->save($resourcesOutputPath . "formatText_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **Définir l’ancrage d’un TextFrame**
Aspose.Slides for PHP via Java permet aux développeurs de définir l’ancrage d’un TextFrame. TextAnchorType indique où le texte est placé dans la forme. AnchorType peut être réglé sur [Top](https://reference.aspose.com/slides/php-java/aspose.slides/TextAnchorType#Top), [Center](https://reference.aspose.com/slides/php-java/aspose.slides/TextAnchorType#Center), [Bottom](https://reference.aspose.com/slides/php-java/aspose.slides/TextAnchorType#Bottom), [Justified](https://reference.aspose.com/slides/php-java/aspose.slides/TextAnchorType#Justified) ou [Distributed](https://reference.aspose.com/slides/php-java/aspose.slides/TextAnchorType#Distributed). Pour définir l’ancrage d’un TextFrame, suivez les étapes ci‑dessous :

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation).
2. Accédez à la première diapositive.
3. Ajoutez n’importe quelle forme à la diapositive.
4. Accédez au [ITextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/IAutoShape).
5. [Définir TextAnchorType](https://reference.aspose.com/slides/php-java/aspose.slides/ITextFrameFormat#setAnchoringType-byte-) du TextFrame.
6. Enregistrez le fichier sur le disque.
```php
  # Créer une instance de la classe Presentation
  $pres = new Presentation();
  try {
    # Obtenir la première diapositive
    $slide = $pres->getSlides()->get_Item(0);
    # Ajouter une AutoShape de type Rectangle
    $ashp = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 150, 75, 350, 350);
    # Ajouter un TextFrame au rectangle
    $ashp->addTextFrame("");
    $ashp->getFillFormat()->setFillType(FillType::NoFill);
    # Accéder au TextFrame
    $txtFrame = $ashp->getTextFrame();
    $txtFrame->getTextFrameFormat()->setAnchoringType(TextAnchorType::Bottom);
    # Créer l'objet Paragraph pour le TextFrame
    $para = $txtFrame->getParagraphs()->get_Item(0);
    # Créer l'objet Portion pour le paragraphe
    $portion = $para->getPortions()->get_Item(0);
    $portion->setText("A quick brown fox jumps over the lazy dog. A quick brown fox jumps over the lazy dog.");
    $portion->getPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
    $portion->getPortionFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLACK);
    # Enregistrer la présentation
    $pres->save("AnchorText_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **Tabulations et EffectiveTabs dans une présentation**
Toutes les tabulations de texte sont exprimées en pixels.

|![todo:image_alt_text](http://i.imgur.com/POpc1Lw.png)|
| :- |
|**Figure : 2 Tabulations explicites et 2 Tabulations par défaut**|
- EffectiveTabs.ExplicitTabCount (2 dans notre cas) est égal à Tabs.Count.  
- La collection EffectiveTabs comprend toutes les tabulations (celles de la collection Tabs et les tabulations par défaut).  
- EffectiveTabs.ExplicitTabCount (2 dans notre cas) est égal à Tabs.Count.  
- EffectiveTabs.DefaultTabSize (294) indique la distance entre les tabulations par défaut (3 et 4 dans notre exemple).  
- EffectiveTabs.GetTabByIndex(index) avec index = 0 renvoie la première tabulation explicite (Position = 731), index = 1 la deuxième (Position = 1241). Si vous demandez la tabulation suivante avec index = 2, elle renvoie la première tabulation par défaut (Position = 1470), etc.  
- EffectiveTabs.GetTabAfterPosition(pos) permet d’obtenir la tabulation suivante après un texte donné. Par exemple, vous avez le texte : « Hello World! ». Pour rendre ce texte, vous devez savoir où commencer à dessiner « world! ». D’abord, calculez la longueur de « Hello » en pixels puis appelez GetTabAfterPosition avec cette valeur. Vous obtiendrez la position de la prochaine tabulation pour dessiner « world! ».

## **Extraire le texte avec l’effet Tout en majuscules**
Dans PowerPoint, l’application de l’effet de police **All Caps** fait apparaître le texte en majuscules sur la diapositive même s’il a été saisi en minuscules. Lorsqu’on récupère une portion de texte avec Aspose.Slides, la bibliothèque renvoie le texte exactement tel qu’il a été saisi. Pour gérer cela, vérifiez [TextCapType](https://reference.aspose.com/slides/php-java/aspose.slides/textcaptype/) — si la valeur est `All`, convertissez simplement la chaîne renvoyée en majuscules afin que votre sortie corresponde à ce que voit l’utilisateur sur la diapositive.

Imaginons que nous ayons la zone de texte suivante sur la première diapositive du fichier sample2.pptx.

![The All Caps effect](all_caps_effect.png)

Le code d’exemple ci‑dess dessous montre comment extraire le texte avec l’effet **All Caps** appliqué :
```php
$presentation = new Presentation("sample2.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $autoShape = $slide->getShapes()->get_Item(0);
    $paragraph = $autoShape->getTextFrame()->getParagraphs()->get_Item(0);
    $textPortion = $paragraph->getPortions()->get_Item(0);

    echo "Original text: ", $textPortion->getText(), "\n";

    $textFormat = $textPortion->getPortionFormat()->getEffective();
    if (java_values($textFormat->getTextCapType()) === TextCapType::All) {
        $text = $textPortion->getText()->toUpperCase();
        echo "All-Caps effect: ", $text, "\n";
    }
} finally {
    $presentation->dispose();
}
```


Sortie :
```text
Original text: Hello, Aspose!
All-Caps effect: HELLO, ASPOSE!
```


## **FAQ**

**Comment modifier le texte dans un tableau d’une diapositive ?**

Pour modifier le texte dans un tableau d’une diapositive, vous devez utiliser la classe [Table](https://reference.aspose.com/slides/php-java/aspose.slides/table/). Vous pouvez parcourir toutes les cellules du tableau et modifier le texte de chaque cellule en accédant à ses propriétés `TextFrame` et `ParagraphFormat`.

**Comment appliquer une couleur dégradée au texte d’une diapositive PowerPoint ?**

Pour appliquer une couleur dégradée au texte, utilisez la méthode `getFillFormat` de [BasePortionFormat](https://reference.aspose.com/slides/php-java/aspose.slides/baseportionformat/). Définissez le `FilFormat` sur `Gradient`, où vous pouvez spécifier les couleurs de début et de fin du dégradé, ainsi que d’autres propriétés telles que la direction et la transparence pour créer l’effet dégradé sur le texte.