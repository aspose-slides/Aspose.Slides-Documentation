---
title: Gérer les paragraphes de texte PowerPoint en PHP
linktitle: Gérer le paragraphe
type: docs
weight: 40
url: /fr/php-java/manage-paragraph/
aliases:
  - /php-java/paragraph/
  - /php-java/portion/
keywords:
- ajouter du texte
- ajouter un paragraphe
- gérer le texte
- gérer le paragraphe
- gérer la puce
- retrait de paragraphe
- retrait suspendu
- puce de paragraphe
- liste numérotée
- liste à puces
- propriétés du paragraphe
- importer du HTML
- texte en HTML
- paragraphe en HTML
- paragraphe en image
- texte en image
- exporter le paragraphe
- PowerPoint
- présentation
- PHP
- Aspose.Slides
description: "Apprenez à créer et formater des paragraphes, des portions, des puces, des listes numérotées, des retraits, du contenu HTML et des images de paragraphes avec Aspose.Slides pour PHP via Java."
---
## **Vue d'ensemble**

Aspose.Slides for PHP via Java représente le texte comme une hiérarchie de cadres de texte, de paragraphes et de portions :

* [TextFrame](https://reference.aspose.com/slides/fr/php-java/aspose.slides/textframe/) représente le conteneur de texte dans une forme et fournit l'accès à sa collection de paragraphes.
* [Paragraph](https://reference.aspose.com/slides/fr/php-java/aspose.slides/paragraph/) représente un paragraphe dans un cadre de texte et fournit l'accès à ses portions ainsi qu'à la mise en forme au niveau du paragraphe.
* [Portion](https://reference.aspose.com/slides/fr/php-java/aspose.slides/portion/) représente un segment de texte au sein d'un paragraphe. Chaque portion peut avoir son propre texte et une mise en forme au niveau des caractères.

Un paragraphe peut donc contenir du texte avec différentes polices, couleurs, tailles et autres formats en utilisant plusieurs portions.

## **Créer et formater des paragraphes**

### **Créer des paragraphes avec plusieurs portions**

Les étapes suivantes créent un cadre de texte avec trois paragraphes, chacun contenant trois portions :

1. Créer une instance de la classe [Presentation](https://reference.aspose.com/slides/fr/php-java/aspose.slides/presentation/).
2. Accéder à la diapositive concernée via son indice.
3. Ajouter une [AutoShape](https://reference.aspose.com/slides/fr/php-java/aspose.slides/autoshape/) rectangulaire à la diapositive.
4. Accéder au [TextFrame](https://reference.aspose.com/slides/fr/php-java/aspose.slides/textframe/) de la forme.
5. Utiliser le paragraphe par défaut et ajouter deux autres objets [Paragraph](https://reference.aspose.com/slides/fr/php-java/aspose.slides/paragraph/) au cadre de texte.
6. Ajouter suffisamment d'objets [Portion](https://reference.aspose.com/slides/fr/php-java/aspose.slides/portion/) afin que chaque paragraphe contienne trois portions. Le paragraphe par défaut contient déjà une portion vide.
7. Définir le texte de chaque portion.
8. Appliquer une mise en forme au niveau des caractères via [Portion::getPortionFormat](https://reference.aspose.com/slides/fr/php-java/aspose.slides/portion/#getPortionFormat--).
9. Enregistrer la présentation modifiée.

Cet exemple PHP implémente les étapes :

```php
use aspose\slides\FillType;
use aspose\slides\NullableBool;
use aspose\slides\Paragraph;
use aspose\slides\Portion;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 150, 300, 150);
    $textFrame = $shape->getTextFrame();

    $firstParagraph = $textFrame->getParagraphs()->get_Item(0);
    $firstParagraph->getPortions()->add(new Portion());
    $firstParagraph->getPortions()->add(new Portion());

    $secondParagraph = new Paragraph();
    $secondParagraph->getPortions()->add(new Portion());
    $secondParagraph->getPortions()->add(new Portion());
    $secondParagraph->getPortions()->add(new Portion());
    $textFrame->getParagraphs()->add($secondParagraph);

    $thirdParagraph = new Paragraph();
    $thirdParagraph->getPortions()->add(new Portion());
    $thirdParagraph->getPortions()->add(new Portion());
    $thirdParagraph->getPortions()->add(new Portion());
    $textFrame->getParagraphs()->add($thirdParagraph);

    $paragraphCount = java_values($textFrame->getParagraphs()->getCount());
    for ($paragraphIndex = 0; $paragraphIndex < $paragraphCount; $paragraphIndex++) {
        $paragraph = $textFrame->getParagraphs()->get_Item($paragraphIndex);
        $portionCount = java_values($paragraph->getPortions()->getCount());
        for ($portionIndex = 0; $portionIndex < $portionCount; $portionIndex++) {
            $portion = $paragraph->getPortions()->get_Item($portionIndex);
            $portion->setText("Portion " . ($paragraphIndex + 1) . "." . ($portionIndex + 1));

            if ($portionIndex == 0) {
                $portion->getPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
                $portion->getPortionFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->RED);
                $portion->getPortionFormat()->setFontBold(NullableBool::True);
                $portion->getPortionFormat()->setFontHeight(15);
            } else if ($portionIndex == 1) {
                $portion->getPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
                $portion->getPortionFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLUE);
                $portion->getPortionFormat()->setFontItalic(NullableBool::True);
                $portion->getPortionFormat()->setFontHeight(18);
            }
        }
    }

    $presentation->save("paragraphs_with_portions.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Créer des listes à puces et numérotées**

### **Créer une liste à puces ou numérotée**

Les puces et la numérotation facilitent la lecture des éléments liés. Dans Aspose.Slides, les paramètres de liste sont définis via [BulletFormat](https://reference.aspose.com/slides/fr/php-java/aspose.slides/bulletformat/).

1. Créer une instance de la classe [Presentation](https://reference.aspose.com/slides/fr/php-java/aspose.slides/presentation/).
2. Accéder à la diapositive concernée via son indice.
3. Ajouter une [AutoShape](https://reference.aspose.com/slides/fr/php-java/aspose.slides/autoshape/) à la diapositive sélectionnée.
4. Accéder au [TextFrame](https://reference.aspose.com/slides/fr/php-java/aspose.slides/textframe/) de la forme.
5. Supprimer le paragraphe par défaut du cadre de texte.
6. Créer un [Paragraph](https://reference.aspose.com/slides/fr/php-java/aspose.slides/paragraph/) pour une puce symbole.
7. Définir [BulletFormat::setType](https://reference.aspose.com/slides/fr/php-java/aspose.slides/bulletformat/#setType-int-) à [BulletType::Symbol](https://reference.aspose.com/slides/fr/php-java/aspose.slides/bullettype/) et spécifier le caractère de la puce.
8. Définir le texte du paragraphe, le retrait, la couleur de la puce et la hauteur de la puce.
9. Ajouter le paragraphe au cadre de texte.
10. Créer un deuxième paragraphe et définir [BulletFormat::setType](https://reference.aspose.com/slides/fr/php-java/aspose.slides/bulletformat/#setType-int-) à [BulletType::Numbered](https://reference.aspose.com/slides/fr/php-java/aspose.slides/bullettype/).
11. Configurer le style de puce numérotée et ajouter le paragraphe au cadre de texte.
12. Enregistrer la présentation.

Cet exemple PHP crée une puce symbole et une puce numérotée :

```php
use aspose\slides\BulletType;
use aspose\slides\ColorType;
use aspose\slides\NullableBool;
use aspose\slides\NumberedBulletStyle;
use aspose\slides\Paragraph;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 200, 200, 400, 200);
    $textFrame = $shape->getTextFrame();
    $textFrame->getParagraphs()->clear();

    $symbolParagraph = new Paragraph();
    $symbolParagraph->setText("Welcome to Aspose.Slides");
    $symbolParagraph->getParagraphFormat()->getBullet()->setType(BulletType::Symbol);
    $symbolParagraph->getParagraphFormat()->getBullet()->setChar("•");
    $symbolParagraph->getParagraphFormat()->setIndent(25);
    $symbolParagraph->getParagraphFormat()->getBullet()->getColor()->setColorType(ColorType::RGB);
    $symbolParagraph->getParagraphFormat()->getBullet()->getColor()->setColor(java("java.awt.Color")->BLACK);
    $symbolParagraph->getParagraphFormat()->getBullet()->setBulletHardColor(NullableBool::True);
    $symbolParagraph->getParagraphFormat()->getBullet()->setHeight(100);
    $textFrame->getParagraphs()->add($symbolParagraph);

    $numberedParagraph = new Paragraph();
    $numberedParagraph->setText("This is a numbered item");
    $numberedParagraph->getParagraphFormat()->getBullet()->setType(BulletType::Numbered);
    $numberedParagraph->getParagraphFormat()->getBullet()->setNumberedBulletStyle(NumberedBulletStyle::BulletCircleNumWDBlackPlain);
    $numberedParagraph->getParagraphFormat()->setIndent(25);
    $numberedParagraph->getParagraphFormat()->getBullet()->getColor()->setColorType(ColorType::RGB);
    $numberedParagraph->getParagraphFormat()->getBullet()->getColor()->setColor(java("java.awt.Color")->BLACK);
    $numberedParagraph->getParagraphFormat()->getBullet()->setBulletHardColor(NullableBool::True);
    $numberedParagraph->getParagraphFormat()->getBullet()->setHeight(100);
    $textFrame->getParagraphs()->add($numberedParagraph);

    $presentation->save("bulleted_and_numbered_list.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

### **Utiliser des puces image**

Les puces image vous permettent d'utiliser une image personnalisée au lieu d'un symbole ou d'un chiffre.

1. Créer une instance de la classe [Presentation](https://reference.aspose.com/slides/fr/php-java/aspose.slides/presentation/).
2. Accéder à la diapositive concernée via son indice.
3. Ajouter une [AutoShape](https://reference.aspose.com/slides/fr/php-java/aspose.slides/autoshape/) et accéder à son [TextFrame](https://reference.aspose.com/slides/fr/php-java/aspose.slides/textframe/).
4. Supprimer le paragraphe par défaut du cadre de texte.
5. Charger l'image de la puce et l'ajouter à la collection d'images de la présentation en tant que [PPImage](https://reference.aspose.com/slides/fr/php-java/aspose.slides/ppimage/).
6. Créer un [Paragraph](https://reference.aspose.com/slides/fr/php-java/aspose.slides/paragraph/) et définir son texte.
7. Définir [BulletFormat::setType](https://reference.aspose.com/slides/fr/php-java/aspose.slides/bulletformat/#setType-int-) à [BulletType::Picture](https://reference.aspose.com/slides/fr/php-java/aspose.slides/bullettype/).
8. Assigner l'image via [BulletFormat::getPicture](https://reference.aspose.com/slides/fr/php-java/aspose.slides/bulletformat/#getPicture--) et définir la hauteur de la puce.
9. Ajouter le paragraphe au cadre de texte.
10. Enregistrer la présentation modifiée.

Cet exemple PHP crée une puce image :

```php
use aspose\slides\BulletType;
use aspose\slides\Images;
use aspose\slides\Paragraph;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $bulletImage = Images::fromFile("bullets.png");
    try {
        $presentationImage = $presentation->getImages()->addImage($bulletImage);
    } finally {
        $bulletImage->dispose();
    }

    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 200, 200, 400, 200);
    $textFrame = $shape->getTextFrame();
    $textFrame->getParagraphs()->clear();

    $paragraph = new Paragraph();
    $paragraph->setText("Welcome to Aspose.Slides");
    $paragraph->getParagraphFormat()->getBullet()->setType(BulletType::Picture);
    $paragraph->getParagraphFormat()->getBullet()->getPicture()->setImage($presentationImage);
    $paragraph->getParagraphFormat()->getBullet()->setHeight(100);
    $textFrame->getParagraphs()->add($paragraph);

    $presentation->save("picture_bullet.pptx", SaveFormat::Pptx);
    $presentation->save("picture_bullet.ppt", SaveFormat::Ppt);
} finally {
    $presentation->dispose();
}
```

### **Créer une liste à plusieurs niveaux**

Définir [ParagraphFormat::setDepth](https://reference.aspose.com/slides/fr/php-java/aspose.slides/paragraphformat/#setDepth-short-) pour placer les paragraphes à différents niveaux d'une liste. Le niveau supérieur a une profondeur de `0`.

1. Créer une [Presentation](https://reference.aspose.com/slides/fr/php-java/aspose.slides/presentation/) et accéder à une diapositive.
2. Ajouter une [AutoShape](https://reference.aspose.com/slides/fr/php-java/aspose.slides/autoshape/) et supprimer le paragraphe par défaut de son cadre de texte.
3. Créer quatre paragraphes et configurer leurs symboles de puce.
4. Définir leurs valeurs [ParagraphFormat::setDepth](https://reference.aspose.com/slides/fr/php-java/aspose.slides/paragraphformat/#setDepth-short-) à `0`, `1`, `2` et `3`.
5. Ajouter les paragraphes au cadre de texte et enregistrer la présentation.

Cet exemple PHP crée une liste à puces à quatre niveaux :

```php
use aspose\slides\BulletType;
use aspose\slides\FillType;
use aspose\slides\Paragraph;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 200, 200, 400, 200);
    $textFrame = $shape->getTextFrame();
    $textFrame->getParagraphs()->clear();

    $firstParagraph = new Paragraph();
    $firstParagraph->setText("Content");
    $firstParagraph->getParagraphFormat()->getBullet()->setType(BulletType::Symbol);
    $firstParagraph->getParagraphFormat()->getBullet()->setChar("•");
    $firstParagraph->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
    $firstParagraph->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLACK);
    $firstParagraph->getParagraphFormat()->setDepth(0);

    $secondParagraph = new Paragraph();
    $secondParagraph->setText("Second level");
    $secondParagraph->getParagraphFormat()->getBullet()->setType(BulletType::Symbol);
    $secondParagraph->getParagraphFormat()->getBullet()->setChar('-');
    $secondParagraph->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
    $secondParagraph->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLACK);
    $secondParagraph->getParagraphFormat()->setDepth(1);

    $thirdParagraph = new Paragraph();
    $thirdParagraph->setText("Third level");
    $thirdParagraph->getParagraphFormat()->getBullet()->setType(BulletType::Symbol);
    $thirdParagraph->getParagraphFormat()->getBullet()->setChar("•");
    $thirdParagraph->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
    $thirdParagraph->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLACK);
    $thirdParagraph->getParagraphFormat()->setDepth(2);

    $fourthParagraph = new Paragraph();
    $fourthParagraph->setText("Fourth level");
    $fourthParagraph->getParagraphFormat()->getBullet()->setType(BulletType::Symbol);
    $fourthParagraph->getParagraphFormat()->getBullet()->setChar('-');
    $fourthParagraph->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
    $fourthParagraph->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLACK);
    $fourthParagraph->getParagraphFormat()->setDepth(3);

    $textFrame->getParagraphs()->add($firstParagraph);
    $textFrame->getParagraphs()->add($secondParagraph);
    $textFrame->getParagraphs()->add($thirdParagraph);
    $textFrame->getParagraphs()->add($fourthParagraph);

    $presentation->save("multilevel_list.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

### **Commencer les éléments numérotés à des valeurs personnalisées**

Utiliser [BulletFormat::setNumberedBulletStartWith](https://reference.aspose.com/slides/fr/php-java/aspose.slides/bulletformat/#setNumberedBulletStartWith-short-) pour définir le numéro initial affiché pour un paragraphe numéroté.

1. Créer une [Presentation](https://reference.aspose.com/slides/fr/php-java/aspose.slides/presentation/) et ajouter une [AutoShape](https://reference.aspose.com/slides/fr/php-java/aspose.slides/autoshape/) à une diapositive.
2. Supprimer le paragraphe par défaut du cadre de texte de la forme.
3. Créer trois paragraphes numérotés.
4. Définir [BulletFormat::setNumberedBulletStartWith](https://reference.aspose.com/slides/fr/php-java/aspose.slides/bulletformat/#setNumberedBulletStartWith-short-) à `2`, `3` et `7` pour les paragraphes respectifs.
5. Ajouter les paragraphes au cadre de texte et enregistrer la présentation.

Cet exemple PHP attribue un numéro de démarrage personnalisé à chaque paragraphe :

```php
use aspose\slides\BulletType;
use aspose\slides\Paragraph;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $shape = $presentation->getSlides()->get_Item(0)->getShapes()->addAutoShape(ShapeType::Rectangle, 200, 200, 400, 200);
    $textFrame = $shape->getTextFrame();
    $textFrame->getParagraphs()->clear();

    $firstParagraph = new Paragraph();
    $firstParagraph->setText("Start at 2");
    $firstParagraph->getParagraphFormat()->getBullet()->setType(BulletType::Numbered);
    $firstParagraph->getParagraphFormat()->getBullet()->setNumberedBulletStartWith(2);
    $textFrame->getParagraphs()->add($firstParagraph);

    $secondParagraph = new Paragraph();
    $secondParagraph->setText("Start at 3");
    $secondParagraph->getParagraphFormat()->getBullet()->setType(BulletType::Numbered);
    $secondParagraph->getParagraphFormat()->getBullet()->setNumberedBulletStartWith(3);
    $textFrame->getParagraphs()->add($secondParagraph);

    $thirdParagraph = new Paragraph();
    $thirdParagraph->setText("Start at 7");
    $thirdParagraph->getParagraphFormat()->getBullet()->setType(BulletType::Numbered);
    $thirdParagraph->getParagraphFormat()->getBullet()->setNumberedBulletStartWith(7);
    $textFrame->getParagraphs()->add($thirdParagraph);

    $presentation->save("custom_numbered_list.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Contrôler la mise en page des paragraphes et les propriétés de fin**

### **Définir un retrait de première ligne**

Utilisez [ParagraphFormat::setIndent](https://reference.aspose.com/slides/fr/php-java/aspose.slides/paragraphformat/#setIndent-float-) pour contrôler le retrait de la première ligne d'un paragraphe. Cette méthode déplace uniquement la première ligne par rapport à la marge gauche du paragraphe. Une valeur positive décale la première ligne vers la droite, tandis que les lignes restantes restent alignées au corps du paragraphe.

Utilisez [ParagraphFormat::setMarginLeft](https://reference.aspose.com/slides/fr/php-java/aspose.slides/paragraphformat/#setMarginLeft-float-) lorsque vous devez déplacer l'ensemble du paragraphe. Utilisez [ParagraphFormat::setIndent](https://reference.aspose.com/slides/fr/php-java/aspose.slides/paragraphformat/#setIndent-float-) lorsque vous devez déplacer uniquement la première ligne.

L'exemple ci-dessous crée plusieurs paragraphes et applique différentes valeurs de [ParagraphFormat::setIndent] pour démontrer comment le retrait de première ligne affecte la mise en page des paragraphes.

1. Créer une instance de la classe [Presentation](https://reference.aspose.com/slides/fr/php-java/aspose.slides/presentation/).
2. Accéder à la diapositive cible.
3. Ajouter une [AutoShape](https://reference.aspose.com/slides/fr/php-java/aspose.slides/autoshape/) rectangulaire à la diapositive.
4. Accéder au [TextFrame](https://reference.aspose.com/slides/fr/php-java/aspose.slides/textframe/) de la forme et supprimer le paragraphe par défaut.
5. Créer plusieurs paragraphes et définir différentes valeurs de [ParagraphFormat::setIndent] pour chacun.
6. Ajouter les paragraphes au cadre de texte.
7. Enregistrer la présentation modifiée.

Ce code PHP montre comment définir un retrait de paragraphe :

```php
use aspose\slides\FillType;
use aspose\slides\Paragraph;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;
use aspose\slides\TextAutofitType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 50, 420, 220);
    $shape->getFillFormat()->setFillType(FillType::NoFill);
    $shape->getLineFormat()->getFillFormat()->setFillType(FillType::Solid);
    $shape->getLineFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->GRAY);

    $textFrame = $shape->getTextFrame();
    $textFrame->getTextFrameFormat()->setAutofitType(TextAutofitType::Shape);
    $textFrame->getParagraphs()->clear();

    $firstParagraph = new Paragraph();
    $firstParagraph->setText("No first-line indent. Wrapped lines start at the same position as the first line.");
    $firstParagraph->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
    $firstParagraph->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLACK);
    $firstParagraph->getParagraphFormat()->setMarginLeft(20.0);
    $firstParagraph->getParagraphFormat()->setIndent(0.0);

    $secondParagraph = new Paragraph();
    $secondParagraph->setText("First-line indent of 20 points. The first line moves to the right, while wrapped lines remain aligned to the paragraph body.");
    $secondParagraph->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
    $secondParagraph->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLACK);
    $secondParagraph->getParagraphFormat()->setMarginLeft(20.0);
    $secondParagraph->getParagraphFormat()->setIndent(20.0);

    $thirdParagraph = new Paragraph();
    $thirdParagraph->setText("First-line indent of 40 points. This paragraph shows a larger first-line offset to make the effect easier to see.");
    $thirdParagraph->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
    $thirdParagraph->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLACK);
    $thirdParagraph->getParagraphFormat()->setMarginLeft(20.0);
    $thirdParagraph->getParagraphFormat()->setIndent(40.0);

    $textFrame->getParagraphs()->add($firstParagraph);
    $textFrame->getParagraphs()->add($secondParagraph);
    $textFrame->getParagraphs()->add($thirdParagraph);

    $presentation->save("paragraph_indent.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Le résultat :

![Le retrait de première ligne des paragraphes](first_line_indent.png)

### **Définir un retrait suspendu**

Un retrait suspendu est une mise en page de paragraphe où la première ligne commence à gauche des lignes restantes. Dans Aspose.Slides, vous créez cet effet avec [ParagraphFormat::setIndent]. Fournissez une valeur négative pour déplacer la première ligne vers la gauche par rapport au corps du paragraphe.

En pratique, [ParagraphFormat::setMarginLeft] définit la position gauche du corps du paragraphe, et [ParagraphFormat::setIndent] définit la position de la première ligne par rapport à cette marge. Pour créer un retrait suspendu, passez une valeur positive à `setMarginLeft` et une valeur négative à `setIndent`.

Ce formatage est utile pour les bibliographies, références, entrées de glossaire et autres paragraphes où les lignes renvoyées doivent s'aligner sous le corps du paragraphe plutôt que sous le premier caractère de la première ligne.

1. Créer une instance de la classe [Presentation](https://reference.aspose.com/slides/fr/php-java/aspose.slides/presentation/).
2. Accéder à la diapositive cible.
3. Ajouter une [AutoShape](https://reference.aspose.com/slides/fr/php-java/aspose.slides/autoshape/) rectangulaire à la diapositive.
4. Accéder au [TextFrame](https://reference.aspose.com/slides/fr/php-java/aspose.slides/textframe/) de la forme et supprimer le paragraphe par défaut.
5. Créer des paragraphes et passer une valeur positive à [ParagraphFormat::setMarginLeft](https://reference.aspose.com/slides/fr/php-java/aspose.slides/paragraphformat/#setMarginLeft-float-) pour chaque paragraphe.
6. Passer une valeur négative à [ParagraphFormat::setIndent](https://reference.aspose.com/slides/fr/php-java/aspose.slides/paragraphformat/#setIndent-float-) pour créer l'effet de retrait suspendu.
7. Ajouter les paragraphes au cadre de texte.
8. Enregistrer la présentation modifiée.

Ce code PHP montre comment définir un retrait suspendu pour un paragraphe :

```php
use aspose\slides\FillType;
use aspose\slides\Paragraph;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;
use aspose\slides\TextAutofitType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 50, 420, 220);
    $shape->getFillFormat()->setFillType(FillType::NoFill);
    $shape->getLineFormat()->getFillFormat()->setFillType(FillType::Solid);
    $shape->getLineFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->GRAY);

    $textFrame = $shape->getTextFrame();
    $textFrame->getTextFrameFormat()->setAutofitType(TextAutofitType::Shape);
    $textFrame->getParagraphs()->clear();

    $firstParagraph = new Paragraph();
    $firstParagraph->setText("A hanging indent is created by combining a positive left margin with a negative indent. The first line starts to the left, while wrapped lines align with the paragraph body.");
    $firstParagraph->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
    $firstParagraph->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLACK);
    $firstParagraph->getParagraphFormat()->setMarginLeft(40.0);
    $firstParagraph->getParagraphFormat()->setIndent(-20.0);

    $secondParagraph = new Paragraph();
    $secondParagraph->setText("This second example uses a deeper hanging indent so the difference between the first line and the wrapped lines is easier to compare.");
    $secondParagraph->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
    $secondParagraph->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLACK);
    $secondParagraph->getParagraphFormat()->setMarginLeft(60.0);
    $secondParagraph->getParagraphFormat()->setIndent(-30.0);

    $textFrame->getParagraphs()->add($firstParagraph);
    $textFrame->getParagraphs()->add($secondParagraph);

    $presentation->save("hanging_indent.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Le résultat :

![Le retrait suspendu des paragraphes](hanging_indent.png)

### **Définir les propriétés de fin de paragraphe**

[Paragraph::setEndParagraphPortionFormat](https://reference.aspose.com/slides/fr/php-java/aspose.slides/paragraph/#setEndParagraphPortionFormat-com.aspose.slides.PortionFormat-) contrôle la mise en forme du marqueur de fin de paragraphe. L'exemple PHP suivant attribue une taille de police et une police latine au marqueur de fin du deuxième paragraphe :

1. Charger une [Presentation](https://reference.aspose.com/slides/fr/php-java/aspose.slides/presentation/) et accéder à une diapositive.
2. Ajouter une [AutoShape](https://reference.aspose.com/slides/fr/php-java/aspose.slides/autoshape/) et supprimer son paragraphe par défaut.
3. Créer deux paragraphes et y ajouter des portions de texte.
4. Créer un [PortionFormat](https://reference.aspose.com/slides/fr/php-java/aspose.slides/portionformat/) pour le marqueur de fin du deuxième paragraphe.
5. Définir [BasePortionFormat::setFontHeight](https://reference.aspose.com/slides/fr/php-java/aspose.slides/baseportionformat/#setFontHeight-float-) et [BasePortionFormat::setLatinFont](https://reference.aspose.com/slides/fr/php-java/aspose.slides/baseportionformat/#setLatinFont-com.aspose.slides.IFontData-).
6. Assigner le format avec [Paragraph::setEndParagraphPortionFormat](https://reference.aspose.com/slides/fr/php-java/aspose.slides/paragraph/#setEndParagraphPortionFormat-com.aspose.slides.PortionFormat-) et enregistrer la présentation.

```php
use aspose\slides\FontData;
use aspose\slides\Paragraph;
use aspose\slides\Portion;
use aspose\slides\PortionFormat;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation("Test.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 10, 10, 200, 250);
    $textFrame = $shape->getTextFrame();
    $textFrame->getParagraphs()->clear();

    $firstParagraph = new Paragraph();
    $firstParagraph->getPortions()->add(new Portion("Sample text"));

    $secondParagraph = new Paragraph();
    $secondParagraph->getPortions()->add(new Portion("Sample text 2"));

    $endParagraphFormat = new PortionFormat();
    $endParagraphFormat->setFontHeight(48);
    $endParagraphFormat->setLatinFont(new FontData("Times New Roman"));
    $secondParagraph->setEndParagraphPortionFormat($endParagraphFormat);

    $textFrame->getParagraphs()->add($firstParagraph);
    $textFrame->getParagraphs()->add($secondParagraph);

    $presentation->save("end_paragraph_format.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Importer et exporter le contenu des paragraphes**

### **Importer du texte HTML dans les paragraphes**

Utilisez [ParagraphCollection::addFromHtml](https://reference.aspose.com/slides/fr/php-java/aspose.slides/paragraphcollection/#addFromHtml-java.lang.String-) pour convertir le balisage HTML en paragraphes et portions dans un cadre de texte.

1. Créer une instance de la classe [Presentation](https://reference.aspose.com/slides/fr/php-java/aspose.slides/presentation/).
2. Accéder à une diapositive et ajouter une [AutoShape](https://reference.aspose.com/slides/fr/php-java/aspose.slides/autoshape/).
3. Accéder au [TextFrame](https://reference.aspose.com/slides/fr/php-java/aspose.slides/textframe/) de la forme et supprimer le paragraphe par défaut.
4. Lire le fichier HTML source.
5. Passer la chaîne HTML à [ParagraphCollection::addFromHtml](https://reference.aspose.com/slides/fr/php-java/aspose.slides/paragraphcollection/#addFromHtml-java.lang.String-).
6. Enregistrer la présentation modifiée.

Cet exemple PHP importe du HTML dans un cadre de texte :

```php
use aspose\slides\FillType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $shapeWidth = java_values($presentation->getSlideSize()->getSize()->getWidth()) - 20;
    $shapeHeight = java_values($presentation->getSlideSize()->getSize()->getHeight()) - 20;
    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 10, 10, $shapeWidth, $shapeHeight);
    $shape->getFillFormat()->setFillType(FillType::NoFill);
    $shape->getTextFrame()->getParagraphs()->clear();

    $html = file_get_contents("file.html");
    if ($html !== false) {
        $shape->getTextFrame()->getParagraphs()->addFromHtml($html);
        $presentation->save("html_text.pptx", SaveFormat::Pptx);
    } else {
        echo "The HTML file could not be read.";
    }
} finally {
    $presentation->dispose();
}
```

### **Exporter le texte d'un paragraphe vers HTML**

Utilisez [ParagraphCollection::exportToHtml](https://reference.aspose.com/slides/fr/php-java/aspose.slides/paragraphcollection/#exportToHtml-int-int-com.aspose.slides.ITextToHtmlConversionOptions-) pour exporter une plage sélectionnée de paragraphes au format HTML.

1. Créer une instance de la classe [Presentation](https://reference.aspose.com/slides/fr/php-java/aspose.slides/presentation/) et charger la présentation souhaitée.
2. Accéder à la diapositive et trouver la [AutoShape](https://reference.aspose.com/slides/fr/php-java/aspose.slides/autoshape/) qui contient le texte.
3. Accéder au [TextFrame](https://reference.aspose.com/slides/fr/php-java/aspose.slides/textframe/) de la forme.
4. Appeler [ParagraphCollection::exportToHtml](https://reference.aspose.com/slides/fr/php-java/aspose.slides/paragraphcollection/#exportToHtml-int-int-com.aspose.slides.ITextToHtmlConversionOptions-) avec l'indice du paragraphe de départ et le nombre de paragraphes à exporter.
5. Écrire la chaîne HTML renvoyée dans un fichier.

Cet exemple PHP exporte tous les paragraphes du premier cadre de texte :

```php
use aspose\slides\Presentation;

$presentation = new Presentation("ExportingHTMLText.pptx");
try {
    $shape = $presentation->getSlides()->get_Item(0)->getShapes()->get_Item(0);

    if (java_instanceof($shape, new JavaClass("com.aspose.slides.AutoShape"))) {
        $textFrame = $shape->getTextFrame();
        if (!java_is_null($textFrame)) {
            $paragraphs = $textFrame->getParagraphs();
            $html = $paragraphs->exportToHtml(0, $paragraphs->getCount(), null);
            if (file_put_contents("paragraphs.html", $html) === false) {
                echo "The HTML file could not be written.";
            }
        } else {
            echo "The first shape does not contain a text frame.";
        }
    } else {
        echo "The first shape is not a text shape.";
    }
} finally {
    $presentation->dispose();
}
```

### **Rendre un paragraphe sous forme d'image**

[Paragraph::getImage](https://reference.aspose.com/slides/fr/php-java/aspose.slides/paragraph/#getImage--) rend directement un paragraphe individuel et renvoie un [IImage]. Enregistrez le résultat dans un fichier ou un flux avec [IImage::save](https://reference.aspose.com/slides/fr/php-java/aspose.slides/iimage/#save-java.lang.String-int-). Il n'est pas nécessaire de rendre la forme contenant ou de recadrer une bitmap manuellement.

[Paragraph::getImage](https://reference.aspose.com/slides/fr/php-java/aspose.slides/paragraph/#getImage--) peut renvoyer `null` si le paragraphe est introuvable dans sa collection parente, n'a pas de limites de rendu valides, ou ne peut pas être rendu. Vérifiez le résultat avant de l'enregistrer et libérez l'image retournée après utilisation.

#### **Rendre un paragraphe à l'échelle par défaut**

Supposons que nous ayons un fichier de présentation appelé sample.pptx avec une diapositive, où la première forme est une zone de texte contenant trois paragraphes.

![La zone de texte avec trois paragraphes](paragraph_to_image_input.png)

L'exemple PHP suivant rend le deuxième paragraphe dans une forme de texte normale à l'échelle par défaut et enregistre l'image retournée au format PNG. Le bloc `finally` garantit que l'image est correctement libérée.

```php
use aspose\slides\ImageFormat;
use aspose\slides\Presentation;

$presentation = new Presentation("sample.pptx");
try {
    $shape = $presentation->getSlides()->get_Item(0)->getShapes()->get_Item(0);

    if (java_instanceof($shape, new JavaClass("com.aspose.slides.AutoShape"))) {
        $textFrame = $shape->getTextFrame();
        if (!java_is_null($textFrame) && java_values($textFrame->getParagraphs()->getCount()) > 1) {
            $paragraph = $textFrame->getParagraphs()->get_Item(1);
            $paragraphImage = $paragraph->getImage();

            if (!java_is_null($paragraphImage)) {
                try {
                    $paragraphImage->save("paragraph.png", ImageFormat::Png);
                } finally {
                    $paragraphImage->dispose();
                }
            } else {
                echo "The paragraph could not be rendered.";
            }
        } else {
            echo "The expected paragraph was not found.";
        }
    } else {
        echo "The first shape is not a text shape.";
    }
} finally {
    $presentation->dispose();
}
```

Le résultat :

![L'image du paragraphe](paragraph_to_image_output.png)

#### **Rendre un paragraphe dans une cellule de tableau avec mise à l'échelle**

Utilisez la surcharge de [Paragraph::getImage] qui accepte les paramètres `$scaleX` et `$scaleY` pour définir les facteurs d'échelle horizontaux et verticaux. L'exemple PHP suivant crée un tableau, rend le paragraphe dans sa première cellule à deux fois sa largeur et hauteur par défaut, et enregistre le résultat sous forme d'image PNG.

```php
use aspose\slides\ImageFormat;
use aspose\slides\Presentation;

$scaleX = 2;
$scaleY = 2;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $table = $slide->getShapes()->addTable(50, 50, array(300), array(80));
    $paragraph = $table->get_Item(0, 0)->getTextFrame()->getParagraphs()->get_Item(0);
    $paragraph->setText("Text in a table cell");

    $paragraphImage = $paragraph->getImage($scaleX, $scaleY);
    if (!java_is_null($paragraphImage)) {
        try {
            $paragraphImage->save("table_paragraph.png", ImageFormat::Png);
        } finally {
            $paragraphImage->dispose();
        }
    } else {
        echo "The paragraph could not be rendered.";
    }
} finally {
    $presentation->dispose();
}
```

Un facteur d'échelle de `1` conserve cet axe à sa taille de pixel par défaut. Par exemple, `2` pour les deux facteurs produit une image dont la largeur et la hauteur sont approximativement deux fois les dimensions d'origine, ce qui donne quatre fois plus de pixels. Des facteurs plus grands produisent généralement un texte plus net pour le zoom ou la sortie haute résolution, mais ils augmentent également l'utilisation mémoire et la taille du fichier. Les facteurs inférieurs à `1` produisent des images plus petites avec moins de détails. Utilisez des facteurs égaux pour préserver le ratio d'aspect du paragraphe ; des facteurs horizontaux et verticaux différents étirent la sortie indépendamment.

Rendre l'ensemble d'une forme avec [Shape::getImage] reste utile lorsque la sortie doit inclure le remplissage, la bordure ou d'autres contextes visuels de la forme. Pour une image ne contenant que le paragraphe, utilisez [Paragraph::getImage].

## **FAQ**

**Puis-je désactiver complètement le retour à la ligne à l'intérieur d'un cadre de texte ?**

Oui. Définissez [TextFrameFormat::setWrapText](https://reference.aspose.com/slides/fr/php-java/aspose.slides/textframeformat/#setWrapText-byte-) pour désactiver le retour à la ligne afin que les lignes ne se coupent pas aux bords du cadre de texte.

**Comment obtenir les limites exactes sur la diapositive d'un paragraphe spécifique ?**

Utilisez [Paragraph::getRect](https://reference.aspose.com/slides/fr/php-java/aspose.slides/paragraph/#getRect--) pour récupérer le rectangle englobant du paragraphe. [Portion::getRect](https://reference.aspose.com/slides/fr/php-java/aspose.slides/portion/#getRect--) fournit les limites d'une portion individuelle.

**Où le réglage de l'alignement du paragraphe (gauche, droite, centre ou justifié) est‑il contrôlé ?**

[ParagraphFormat::setAlignment](https://reference.aspose.com/slides/fr/php-java/aspose.slides/paragraphformat/#setAlignment-int-) est un paramètre au niveau du paragraphe et s'applique à l'ensemble du paragraphe quel que soit le formatage des portions individuelles.

**Puis-je définir la langue de relecture pour une partie d'un paragraphe ?**

Oui. Définissez [BasePortionFormat::setLanguageId](https://reference.aspose.com/slides/fr/php-java/aspose.slides/baseportionformat/#setLanguageId-java.lang.String-) pour les portions individuelles, afin qu'un paragraphe puisse contenir du texte dans plusieurs langues.