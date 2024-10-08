---
title: Gérer les Polices - API Java PowerPoint
linktitle: Gérer les Polices
type: docs
weight: 10
url: /fr/php-java/manage-fonts/
description: Les présentations contiennent généralement à la fois du texte et des images. Cet article montre comment utiliser l'API Java PowerPoint pour configurer les propriétés de police des paragraphes de texte sur les diapositives.
---

## **Gérer les Propriétés Liées aux Polices**
{{% alert color="primary" %}} 

Les présentations contiennent généralement à la fois du texte et des images. Le texte peut être formaté de diverses manières, soit pour mettre en évidence des sections et des mots spécifiques, soit pour se conformer aux styles d'entreprise. Le formatage du texte aide les utilisateurs à varier l'apparence et la sensation du contenu de la présentation. Cet article montre comment utiliser Aspose.Slides pour PHP via Java pour configurer les propriétés de police des paragraphes de texte sur les diapositives.

{{% /alert %}} 

Pour gérer les propriétés de police d'un paragraphe à l'aide d'Aspose.Slides pour PHP via Java :

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation).
1. Obtenez une référence à une diapositive en utilisant son index.
1. Accédez aux formes [Placeholder](https://reference.aspose.com/slides/php-java/aspose.slides/classes/Placeholder) dans la diapositive et convertissez-les en [AutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/classes/AutoShape).
1. Obtenez le [Paragraph](https://reference.aspose.com/slides/php-java/aspose.slides/classes/Paragraph) du [TextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/classes/TextFrame) exposé par [AutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/classes/AutoShape).
1. Justifiez le paragraphe.
1. Accédez au texte [Portion](https://reference.aspose.com/slides/php-java/aspose.slides/classes/Portion) d'un [Paragraph](https://reference.aspose.com/slides/php-java/aspose.slides/classes/Paragraph).
1. Définissez la police à l'aide de [FontData](https://reference.aspose.com/slides/php-java/aspose.slides/classes/FontData) et définissez la **Police** du texte [Portion](https://reference.aspose.com/slides/php-java/aspose.slides/classes/Portion) en conséquence.
   1. Mettez la police en gras.
   1. Mettez la police en italique.
1. Définissez la couleur de la police à l'aide de [FillFormat](https://reference.aspose.com/slides/php-java/aspose.slides/classes/FillFormat) exposée par l'objet [Portion](https://reference.aspose.com/slides/php-java/aspose.slides/classes/Portion).
1. Enregistrez la présentation modifiée dans un fichier PPTX.

L'implémentation des étapes ci-dessus est donnée ci-dessous. Elle prend une présentation non retravaillée et formate les polices sur une des diapositives. Les captures d'écran suivantes montrent le fichier d'entrée et comment les extraits de code le modifient. Le code change la police, la couleur et le style de la police.

|![todo:image_alt_text](http://i.imgur.com/rqpPgJn.jpg)|
| :- |
|**Figure : Le texte dans le fichier d'entrée**|


|![todo:image_alt_text](http://i.imgur.com/rY27Lt9.png)|
| :- |
|**Figure : Le même texte avec un formatage mis à jour**|

```php
  # Instancier un objet Presentation qui représente un fichier PPTX
  $pres = new Presentation("FontProperties.pptx");
  try {
    # Accéder à une diapositive en utilisant sa position
    $slide = $pres->getSlides()->get_Item(0);
    # Accéder au premier et au deuxième placeholder dans la diapositive et le convertir en AutoShape
    $tf1 = $slide->getShapes()->get_Item(0)->getTextFrame();
    $tf2 = $slide->getShapes()->get_Item(1)->getTextFrame();
    # Accéder au premier Paragraph
    $para1 = $tf1->getParagraphs()->get_Item(0);
    $para2 = $tf2->getParagraphs()->get_Item(0);
    # Justifiez le paragraphe
    $para2->getParagraphFormat()->setAlignment(TextAlignment->JustifyLow);
    # Accéder à la première portion
    $port1 = $para1->getPortions()->get_Item(0);
    $port2 = $para2->getPortions()->get_Item(0);
    # Définir de nouvelles polices
    $fd1 = new FontData("Elephant");
    $fd2 = new FontData("Castellar");
    # Assigner de nouvelles polices à la portion
    $port1->getPortionFormat()->setLatinFont($fd1);
    $port2->getPortionFormat()->setLatinFont($fd2);
    # Mettre la police en gras
    $port1->getPortionFormat()->setFontBold(NullableBool::True);
    $port2->getPortionFormat()->setFontBold(NullableBool::True);
    # Mettre la police en italique
    $port1->getPortionFormat()->setFontItalic(NullableBool::True);
    $port2->getPortionFormat()->setFontItalic(NullableBool::True);
    # Définir la couleur de la police
    $port1->getPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
    $port1->getPortionFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLUE);
    $port2->getPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
    $port2->getPortionFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->GREEN);
    # Enregistrer le PPTX sur le disque
    $pres->save("WelcomeFont.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Définir les Propriétés de Police du Texte**
{{% alert color="primary" %}} 

Comme mentionné dans **Gestion des Propriétés Liées aux Polices**, une [Portion](https://reference.aspose.com/slides/php-java/aspose.slides/classes/Portion) est utilisée pour contenir du texte avec un style de formatage similaire dans un paragraphe. Cet article montre comment utiliser Aspose.Slides pour PHP via Java pour créer une zone de texte avec du texte et ensuite définir une police particulière, ainsi que diverses autres propriétés de la catégorie de police.

{{% /alert %}} 

Pour créer une zone de texte et définir les propriétés de police du texte qu'elle contient :

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation).
1. Obtenez la référence d'une diapositive en utilisant son index.
1. Ajoutez une [AutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/classes/AutoShape) de type **Rectangle** à la diapositive.
1. Supprimez le style de remplissage associé à l'[AutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/classes/AutoShape).
1. Accédez au [TextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/classes/TextFrame) associé à l'[AutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/classes/AutoShape).
1. Ajoutez du texte au [TextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/classes/TextFrame).
1. Accédez à l'objet [Portion](https://reference.aspose.com/slides/php-java/aspose.slides/classes/Portion) associé au [TextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/classes/TextFrame).
1. Définissez la police à utiliser pour la [Portion](https://reference.aspose.com/slides/php-java/aspose.slides/classes/Portion).
1. Définissez d'autres propriétés de police comme le gras, l'italique, le soulignement, la couleur et la hauteur à l'aide des propriétés pertinentes exposées par l'objet [Portion](https://reference.aspose.com/slides/php-java/aspose.slides/classes/Portion).
1. Écrivez la présentation modifiée en tant que fichier PPTX.

L'implémentation des étapes ci-dessus est donnée ci-dessous.

|![todo:image_alt_text](http://i.imgur.com/n5r12dS.jpg)|
| :- |
|**Figure : Texte avec certaines propriétés de police définies par Aspose.Slides pour PHP via Java**|

```php
  # Instancier un objet Presentation qui représente un fichier PPTX
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
    # Définir la propriété Souligne de la police
    $port->getPortionFormat()->setFontUnderline(TextUnderlineType::Single);
    # Définir la hauteur de la police
    $port->getPortionFormat()->setFontHeight(25);
    # Définir la couleur de la police
    $port->getPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
    $port->getPortionFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLUE);
    # Enregistrer la présentation sur le disque
    $pres->save("pptxFont.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```