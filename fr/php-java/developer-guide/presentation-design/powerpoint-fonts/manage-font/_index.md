---
title: Gérer les polices dans les présentations avec PHP
linktitle: Gérer les polices
type: docs
weight: 10
url: /fr/php-java/manage-fonts/
keywords:
- gérer les polices
- propriétés des polices
- paragraphe
- mise en forme du texte
- PowerPoint
- OpenDocument
- présentation
- PHP
- Aspose.Slides
description: "Contrôlez les polices en PHP avec Aspose.Slides : intégrez, remplacez et chargez des polices personnalisées pour garder les présentations PPT, PPTX et ODP claires, sécurisées pour la marque et cohérentes."
---

## **Gérer les propriétés liées aux polices**
{{% alert color="primary" %}} 

Les présentations contiennent généralement à la fois du texte et des images. Le texte peut être formaté de différentes manières, soit pour mettre en évidence des sections et des mots spécifiques, soit pour se conformer aux styles d'entreprise. Le formatage du texte aide les utilisateurs à varier l'apparence du contenu de la présentation. Cet article montre comment utiliser Aspose.Slides pour PHP via Java afin de configurer les propriétés de police des paragraphes de texte sur les diapositives.

{{% /alert %}} 

Pour gérer les propriétés de police d’un paragraphe avec Aspose.Slides pour PHP via Java :

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation).
1. Obtenez la référence d’une diapositive en utilisant son index.
1. Accédez aux formes [Placeholder](https://reference.aspose.com/slides/php-java/aspose.slides/placeholder/) dans la diapositive et convertissez‑les en [AutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/autoshape/).
1. Récupérez le [Paragraph](https://reference.aspose.com/slides/php-java/aspose.slides/paragraph/) depuis le [TextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/textframe/) exposé par [AutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/autoshape/).
1. Justifiez le paragraphe.
1. Accédez à la [Portion](https://reference.aspose.com/slides/php-java/aspose.slides/portion/) de texte d’un [Paragraph](https://reference.aspose.com/slides/php-java/aspose.slides/paragraph/).
1. Définissez la police à l’aide de [FontData](https://reference.aspose.com/slides/php-java/aspose.slides/fontdata/) et définissez la **Font** de la [Portion](https://reference.aspose.com/slides/php-java/aspose.slides/portion/) de texte en conséquence.
   1. Appliquez le gras à la police.
   1. Appliquez l’italique à la police.
1. Définissez la couleur de la police à l’aide du [FillFormat](https://reference.aspose.com/slides/php-java/aspose.slides/fillformat/) exposé par l’objet [Portion](https://reference.aspose.com/slides/php-java/aspose.slides/portion/).
1. Enregistrez la présentation modifiée dans un fichier PPTX.

L’implémentation des étapes ci‑dessus est présentée ci‑après. Elle prend une présentation non décorée et formate les polices sur l’une des diapositives. Les captures d’écran suivantes montrent le fichier d’entrée et comment les extraits de code le modifient. Le code modifie la police, la couleur et le style de la police.

|![todo:image_alt_text](http://i.imgur.com/rqpPgJn.jpg)|
| :- |
|**Figure: Le texte dans le fichier d'entrée**|

|![todo:image_alt_text](http://i.imgur.com/rY27Lt9.png)|
| :- |
|**Figure: Le même texte avec le formatage mis à jour**|
```php
  # Instancier un objet Presentation qui représente un fichier PPTX
  $pres = new Presentation("FontProperties.pptx");
  try {
    # Accéder à une diapositive en utilisant sa position
    $slide = $pres->getSlides()->get_Item(0);
    # Accéder aux premier et deuxième espaces réservés dans la diapositive et les convertir en AutoShape
    $tf1 = $slide->getShapes()->get_Item(0)->getTextFrame();
    $tf2 = $slide->getShapes()->get_Item(1)->getTextFrame();
    # Accéder au premier paragraphe
    $para1 = $tf1->getParagraphs()->get_Item(0);
    $para2 = $tf2->getParagraphs()->get_Item(0);
    # Justifier le paragraphe
    $para2->getParagraphFormat()->setAlignment(TextAlignment->JustifyLow);
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


## **Définir les propriétés de la police du texte**
{{% alert color="primary" %}} 

Comme indiqué dans **Gérer les propriétés liées aux polices**, une [Portion](https://reference.aspose.com/slides/php-java/aspose.slides/portion/) est utilisée pour regrouper du texte ayant un même style de formatage dans un paragraphe. Cet article montre comment utiliser Aspose.Slides pour PHP via Java pour créer une zone de texte contenant du texte, puis définir une police particulière ainsi que diverses autres propriétés de la catégorie de famille de polices.

{{% /alert %}} 

Pour créer une zone de texte et définir les propriétés de police du texte qu’elle contient :

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation).
1. Obtenez la référence d’une diapositive en utilisant son index.
1. Ajoutez un [AutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/autoshape/) de type **Rectangle** à la diapositive.
1. Supprimez le style de remplissage associé au [AutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/autoshape/).
1. Accédez au [TextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/textframe/) du [AutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/autoshape/).
1. Ajoutez du texte au [TextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/textframe/).
1. Accédez à l’objet [Portion](https://reference.aspose.com/slides/php-java/aspose.slides/portion/) associé au [TextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/textframe/).
1. Définissez la police à utiliser pour la [Portion](https://reference.aspose.com/slides/php-java/aspose.slides/portion/).
1. Définissez d’autres propriétés de police telles que le gras, l’italique, le soulignement, la couleur et la taille en utilisant les propriétés correspondantes exposées par l’objet [Portion](https://reference.aspose.com/slides/php-java/aspose.slides/portion/).
1. Enregistrez la présentation modifiée sous forme de fichier PPTX.

|![todo:image_alt_text](http://i.imgur.com/n5r12dS.jpg)|
| :- |
|**Figure : Texte avec certaines propriétés de police définies par Aspose.Slides pour PHP via Java**|
```php
  # Instancier un objet Presentation qui représente un fichier PPTX
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
    $tf->setText("Aspose TextBox");
    # Accéder à la Portion associée au TextFrame
    $port = $tf->getParagraphs()->get_Item(0)->getPortions()->get_Item(0);
    # Définir la police pour la Portion
    $port->getPortionFormat()->setLatinFont(new FontData("Times New Roman"));
    # Définir la propriété Gras de la police
    $port->getPortionFormat()->setFontBold(NullableBool::True);
    # Définir la propriété Italique de la police
    $port->getPortionFormat()->setFontItalic(NullableBool::True);
    # Définir la propriété Soulignement de la police
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
