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
  - gérer les puces
  - retrait de paragraphe
  - retrait suspendu
  - puce de paragraphe
  - liste numérotée
  - liste à puces
  - propriétés du paragraphe
  - importer HTML
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

* [TextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/textframe/) représente le conteneur de texte dans une forme et fournit l’accès à sa collection de paragraphes.
* [Paragraph](https://reference.aspose.com/slides/php-java/aspose.slides/paragraph/) représente un paragraphe dans un cadre de texte et fournit l’accès à ses portions et à la mise en forme au niveau du paragraphe.
* [Portion](https://reference.aspose.com/slides/php-java/aspose.slides/portion/) représente une séquence de texte au sein d’un paragraphe. Chaque portion peut avoir son propre texte et une mise en forme au niveau des caractères.

Un paragraphe peut donc contenir du texte avec différentes polices, couleurs, tailles et autres mises en forme en utilisant plusieurs portions.

## **Créer et formater des paragraphes**

Créez des paragraphes dans le cadre de texte d’une forme et utilisez des portions pour formater des séquences de texte individuelles. Cette section montre comment combiner plusieurs portions au sein de chaque paragraphe et appliquer différentes couleurs, tailles de police et styles.

### **Créer des paragraphes avec plusieurs portions**

L’exemple PHP suivant crée trois paragraphes, chacun contenant trois séquences de texte dans la collection retournée par [Paragraph::getPortions](https://reference.aspose.com/slides/php-java/aspose.slides/paragraph/#getPortions). Il réutilise le paragraphe par défaut et sa portion vide, puis ajoute les paragraphes et portions restants. La mise en forme est appliquée via [Portion::getPortionFormat](https://reference.aspose.com/slides/php-java/aspose.slides/portion/#getPortionFormat) : la première portion de chaque paragraphe est rouge, en gras et de 15 points ; la deuxième est bleue, en italique et de 18 points. La troisième portion conserve sa mise en forme par défaut :

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

Organisez le texte des paragraphes en listes avec des symboles, des nombres ou des images personnalisées. Les exemples de cette section couvrent le formatage des puces, les listes à plusieurs niveaux et les numéros de départ personnalisés.

### **Créer une liste à puces ou numérotée**

Les puces et la numérotation facilitent la lecture des éléments liés. Dans Aspose.Slides, les paramètres de liste sont définis via [BulletFormat](https://reference.aspose.com/slides/php-java/aspose.slides/bulletformat/).

Cet exemple PHP ajoute une puce symbole et un élément numéroté au même cadre de texte. [BulletFormat::setType](https://reference.aspose.com/slides/php-java/aspose.slides/bulletformat/#setType) sélectionne le type de puce, tandis que [BulletFormat::setChar](https://reference.aspose.com/slides/php-java/aspose.slides/bulletformat/#setChar) fournit le symbole et [BulletFormat::setNumberedBulletStyle](https://reference.aspose.com/slides/php-java/aspose.slides/bulletformat/#setNumberedBulletStyle) sélectionne le style de numérotation. Les deux éléments utilisent des puces noires avec une hauteur de 100 % et un retrait de paragraphe de 25 points :

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

### **Utiliser des puces d’image**

Les puces d’image vous permettent d’utiliser une image personnalisée à la place d’un symbole ou d’un nombre.

Cet exemple PHP ajoute une image à la collection d’images de la présentation en tant que [PPImage](https://reference.aspose.com/slides/php-java/aspose.slides/ppimage/) et l’utilise comme puce de paragraphe. Il appelle [BulletFormat::setType](https://reference.aspose.com/slides/php-java/aspose.slides/bulletformat/#setType) pour utiliser une puce image et assigne l’image via [BulletFormat::getPicture](https://reference.aspose.com/slides/php-java/aspose.slides/bulletformat/#getPicture). [BulletFormat::setHeight](https://reference.aspose.com/slides/php-java/aspose.slides/bulletformat/#setHeight) est défini à 100 % pour dimensionner la puce par rapport au texte du paragraphe :

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

Définissez [ParagraphFormat::setDepth](https://reference.aspose.com/slides/php-java/aspose.slides/paragraphformat/#setDepth) pour placer les paragraphes à différents niveaux d’une liste. Le niveau supérieur a une profondeur de `0`.

Cet exemple PHP attribue des valeurs de [ParagraphFormat::setDepth](https://reference.aspose.com/slides/php-java/aspose.slides/paragraphformat/#setDepth) de 0 à 3 à quatre paragraphes, créant une hiérarchie dans un seul cadre de texte. Chaque paragraphe utilise une puce symbole, avec [BulletFormat::setChar](https://reference.aspose.com/slides/php-java/aspose.slides/bulletformat/#setChar) alternant entre une puce ronde et un tiret pour distinguer les niveaux adjacents :

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

Utilisez [BulletFormat::setNumberedBulletStartWith](https://reference.aspose.com/slides/php-java/aspose.slides/bulletformat/#setNumberedBulletStartWith) pour définir le numéro initial affiché pour un paragraphe numéroté.

Cet exemple PHP définit [BulletFormat::setType](https://reference.aspose.com/slides/php-java/aspose.slides/bulletformat/#setType) pour utiliser la numérotation pour trois paragraphes et attribue des valeurs à [BulletFormat::setNumberedBulletStartWith](https://reference.aspose.com/slides/php-java/aspose.slides/bulletformat/#setNumberedBulletStartWith) de 2, 3 et 7. La valeur de départ est configurée séparément pour chaque paragraphe, permettant aux numéros affichés de sauter des valeurs :

```php
use aspose\slides\BulletType;
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

## **Contrôler la mise en page du paragraphe et les propriétés de fin**

Ajustez les marges et retraits du paragraphe pour contrôler la position de la première ligne et des lignes renvoyées. Vous pouvez également formater le caractère de fin du paragraphe séparément des portions de texte visibles.

### **Définir un retrait de première ligne**

Utilisez la méthode [ParagraphFormat::setIndent](https://reference.aspose.com/slides/php-java/aspose.slides/paragraphformat/#setIndent) pour contrôler le retrait de première ligne d’un paragraphe. Ce paramètre déplace uniquement la première ligne par rapport à la marge gauche du paragraphe. Une valeur positive décale la première ligne vers la droite, tandis que les lignes restantes restent alignées avec le corps du paragraphe.

Utilisez [ParagraphFormat::setMarginLeft](https://reference.aspose.com/slides/php-java/aspose.slides/paragraphformat/#setMarginLeft) lorsque vous devez déplacer tout le paragraphe. Utilisez [ParagraphFormat::setIndent](https://reference.aspose.com/slides/php-java/aspose.slides/paragraphformat/#setIndent) lorsque vous devez déplacer uniquement la première ligne.

L’exemple suivant donne à trois paragraphes le même [ParagraphFormat::setMarginLeft](https://reference.aspose.com/slides/php-java/aspose.slides/paragraphformat/#setMarginLeft) de 20 points et des valeurs de [ParagraphFormat::setIndent](https://reference.aspose.com/slides/php-java/aspose.slides/paragraphformat/#setIndent) de 0, 20 et 40 points. Les premières lignes commencent à des décalages progressivement plus grands, tandis que les lignes renvoyées conservent la même marge gauche :

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

Un retrait suspendu est une mise en page de paragraphe où la première ligne commence à gauche des lignes restantes. Dans Aspose.Slides, vous créez cet effet avec la propriété [ParagraphFormat::setIndent](https://reference.aspose.com/slides/php-java/aspose.slides/paragraphformat/#setIndent). Définissez `Indent` à une valeur négative pour déplacer la première ligne vers la gauche par rapport au corps du paragraphe.

En pratique, [ParagraphFormat::setMarginLeft](https://reference.aspose.com/slides/php-java/aspose.slides/paragraphformat/#setMarginLeft) définit la position gauche du corps du paragraphe, et [ParagraphFormat::setIndent](https://reference.aspose.com/slides/php-java/aspose.slides/paragraphformat/#setIndent) définit la position de la première ligne par rapport à cette marge. Pour créer un retrait suspendu, définissez une valeur positive pour `MarginLeft` et une valeur négative pour `Indent`.

Ce formatage est utile pour les bibliographies, références, entrées de glossaire et autres paragraphes où les lignes renvoyées doivent s’aligner sous le corps du paragraphe plutôt que sous le premier caractère de la première ligne.

L’exemple PHP suivant associe des valeurs de [ParagraphFormat::setMarginLeft](https://reference.aspose.com/slides/php-java/aspose.slides/paragraphformat/#setMarginLeft) de 40 et 60 points à des valeurs de [ParagraphFormat::setIndent](https://reference.aspose.com/slides/php-java/aspose.slides/paragraphformat/#setIndent) de -20 et -30 points. Dans chaque paragraphe, la première ligne commence à gauche des lignes renvoyées ; le deuxième paragraphe possède un retrait suspendu plus important :

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

### **Définir les propriétés de fin du paragraphe**

La méthode [Paragraph::setEndParagraphPortionFormat](https://reference.aspose.com/slides/php-java/aspose.slides/paragraph/#setEndParagraphPortionFormat) contrôle la mise en forme du caractère de fin du paragraphe. L’exemple suivant crée un [PortionFormat](https://reference.aspose.com/slides/php-java/aspose.slides/portionformat/) avec [BasePortionFormat::setFontHeight](https://reference.aspose.com/slides/php-java/aspose.slides/baseportionformat/#setFontHeight) réglé à 48 points et [BasePortionFormat::setLatinFont](https://reference.aspose.com/slides/php-java/aspose.slides/baseportionformat/#setLatinFont) réglé sur Times New Roman. Il attribue ce format au caractère de fin du deuxième paragraphe, laissant les portions de texte visibles inchangées :

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

## **Compter les lignes rendues**

Pour les règles de paragraphe qui affectent le renvoi à la ligne automatique et la ponctuation en fin de ligne, voir [Contrôle du retour à la ligne](/slides/fr/php-java/text-formatting/#control-line-breaking) et [Contrôle de la ponctuation suspendue](/slides/fr/php-java/text-formatting/#control-hanging-punctuation).

Utilisez [Paragraph::getLinesCount](https://reference.aspose.com/slides/php-java/aspose.slides/paragraph/#getLinesCount) pour compter les lignes occupées par un paragraphe après la mise en page du texte, y compris le renvoi à la ligne automatique. Cela est utile lors de la vérification de la longueur du texte et de la mise en page dans les modèles de présentation.

Un paragraphe est un élément de [TextFrame::getParagraphs](https://reference.aspose.com/slides/php-java/aspose.slides/textframe/#getParagraphs), et il peut occuper plusieurs lignes rendues. Un retour à la ligne explicite au sein d’un paragraphe force une nouvelle ligne sans créer un autre paragraphe. Le renvoi à la ligne automatique crée des lignes en fonction de la largeur disponible sans insérer de retours à la ligne explicites dans le texte. Ainsi, compter les paragraphes ou les caractères de retour à la ligne ne fournit pas le nombre de lignes rendues.

L’exemple suivant crée une forme de texte, compte ses lignes, rétrécit la forme, puis remplace le texte par une chaîne plus courte. L’exemple active le renvoi à la ligne avec [TextFrameFormat::setWrapText](https://reference.aspose.com/slides/php-java/aspose.slides/textframeformat/#setWrapText) et désactive l’ajustement automatique avec [TextFrameFormat::setAutofitType](https://reference.aspose.com/slides/php-java/aspose.slides/textframeformat/#setAutofitType) afin que la largeur de la forme contrôle le renvoi à la ligne sans réduire automatiquement le texte ou redimensionner la forme. Chaque mesure utilise [Paragraph::getLinesCount](https://reference.aspose.com/slides/php-java/aspose.slides/paragraph/#getLinesCount). Les dimensions de la forme sont exprimées en points. Enfin, l’exemple ajoute un autre paragraphe et additionne les comptes de lignes à travers le cadre de texte.

```php
use aspose\slides\NullableBool;
use aspose\slides\Paragraph;
use aspose\slides\Presentation;
use aspose\slides\ShapeType;
use aspose\slides\TextAutofitType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 50, 400, 200);
    $textFrame = $shape->getTextFrame();
    $textFrame->getTextFrameFormat()->setWrapText(NullableBool::True);
    $textFrame->getTextFrameFormat()->setAutofitType(TextAutofitType::None);

    $paragraph = $textFrame->getParagraphs()->get_Item(0);
    $paragraph->getParagraphFormat()->getDefaultPortionFormat()->setFontHeight(20);
    $paragraph->setText("This text demonstrates how automatic wrapping changes the number of rendered lines.");
    echo "Original width: " . java_values($paragraph->getLinesCount()) . PHP_EOL;

    $shape->setWidth(150);
    echo "Narrower shape: " . java_values($paragraph->getLinesCount()) . PHP_EOL;

    $paragraph->setText("Short text.");
    echo "Shorter text: " . java_values($paragraph->getLinesCount()) . PHP_EOL;

    $secondParagraph = new Paragraph();
    $secondParagraph->setText("Another paragraph.");
    $secondParagraph->getParagraphFormat()->getDefaultPortionFormat()->setFontHeight(20);
    $textFrame->getParagraphs()->add($secondParagraph);

    $totalLineCount = 0;
    for ($i = 0; $i < java_values($textFrame->getParagraphs()->getCount()); $i++) {
        $currentParagraph = $textFrame->getParagraphs()->get_Item($i);
        $totalLineCount += java_values($currentParagraph->getLinesCount());
    }
    echo "Total lines in the text frame: " . $totalLineCount . PHP_EOL;
} finally {
    $presentation->dispose();
}
```

Avec ce texte et ces dimensions, rétrécir la forme augmente le nombre de lignes, tandis que remplacer le texte par la courte chaîne le réduit. Les comptes exacts peuvent varier selon la disponibilité et le remplacement des polices, la taille de la police, les marges, les retraits, le renvoi à la ligne et les paramètres d’ajustement automatique. Utilisez les polices et les réglages de mise en page prévus pour l’environnement cible lors de la vérification d’un modèle.

Le nombre de lignes seul ne détermine pas si le texte dépasse son conteneur. La hauteur disponible, la hauteur des lignes, l’espacement des paragraphes et des lignes, ainsi que le comportement d’ajustement automatique sont également importants ; même une seule ligne peut dépasser la largeur disponible lorsque le renvoi à la ligne est désactivé.

## **Importer et exporter le contenu d’un paragraphe**

Utilisez HTML pour introduire du texte dans une présentation ou exporter des paragraphes existants pour une utilisation extérieure. Cette section montre également comment rendre des paragraphes individuels en images, y compris les paragraphes dans les cellules de tableau.

### **Importer du texte HTML dans des paragraphes**

Utilisez [ParagraphCollection::addFromHtml](https://reference.aspose.com/slides/php-java/aspose.slides/paragraphcollection/#addFromHtml) pour convertir le balisage HTML en paragraphes et portions dans un cadre de texte.

Cet exemple PHP lit du HTML depuis un fichier et transmet le balisage à [ParagraphCollection::addFromHtml](https://reference.aspose.com/slides/php-java/aspose.slides/paragraphcollection/#addFromHtml). Il supprime le paragraphe par défaut du cadre de texte afin que le cadre ne contienne que le contenu importé. La forme rectangulaire laisse une marge de 10 points sur chaque côté de la diapositive :

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

### **Exporter le texte du paragraphe vers HTML**

Utilisez [ParagraphCollection::exportToHtml](https://reference.aspose.com/slides/php-java/aspose.slides/paragraphcollection/#exportToHtml) pour exporter une plage sélectionnée de paragraphes en HTML. Lors de la réutilisation du texte d’une présentation sur un site web, vous pouvez vouloir conserver les emphases locales sans transmettre la police, la taille ou les styles de zone de texte de la présentation. Définissez [TextToHtmlConversionOptions::setTextInheritanceLimit](https://reference.aspose.com/slides/php-java/aspose.slides/texttohtmlconversionoptions/#setTextInheritanceLimit) pour contrôler jusqu’où l’exportateur suit l’héritage de la mise en forme.

Téléchargez [la présentation d'exemple](text-inheritance.pptx) et placez-le dans le répertoire de travail de l’application. Sa première diapositive contient une forme de texte avec le texte "Inherited text; explicit red 18pt". L’entrée utilise délibérément plusieurs niveaux de mise en forme :

- Le style de texte par défaut de la présentation fournit Calibri et une taille de 28 pt.
- Le style de texte de premier niveau du cadre de texte fournit du texte bleu et de l’italique.
- Le paragraphe définit explicitement le texte en gras.
- La deuxième portion, "explicit red 18pt", définit explicitement le texte rouge et une taille de 18 pt.

L’exemple complet suivant exporte les mêmes paragraphes trois fois. Il transmet [TextToHtmlConversionOptions](https://reference.aspose.com/slides/php-java/aspose.slides/texttohtmlconversionoptions/) à la méthode d’exportation et écrit chaque résultat dans un fichier HTML UTF-8 séparé :

```php
use aspose\slides\Presentation;
use aspose\slides\TextInheritanceLimit;
use aspose\slides\TextToHtmlConversionOptions;

$presentation = new Presentation("text-inheritance.pptx");
try {
    $shape = $presentation->getSlides()->get_Item(0)->getShapes()->get_Item(0);

    if (java_instanceof($shape, new JavaClass("com.aspose.slides.AutoShape"))) {
        $textFrame = $shape->getTextFrame();
        if (!java_is_null($textFrame)) {
            $paragraphs = $textFrame->getParagraphs();

            $modes = array(TextInheritanceLimit::All, TextInheritanceLimit::TextBox, TextInheritanceLimit::ParagraphOnly);
            $fileNames = array("All.html", "TextBox.html", "ParagraphOnly.html");

            for ($i = 0; $i < count($modes); $i++) {
                $options = new TextToHtmlConversionOptions();
                $options->setTextInheritanceLimit($modes[$i]);

                $html = $paragraphs->exportToHtml(0, $paragraphs->getCount(), $options);
                if (file_put_contents($fileNames[$i], java_values($html)) === false) {
                    echo "The HTML file could not be written." . PHP_EOL;
                }
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

Le HTML généré contient le CSS suivant pour la première portion, "Inherited text; ". Le tableau répertorie les déclarations pertinentes ; les autres propriétés générées sont omises pour plus de clarté.

| Sortie | CSS pertinent pour la première portion | Apparence |
| --- | --- | --- |
| `All.html` | `font-family:'Calibri'; font-size:28pt; color:#0000ff; font-style:italic; font-weight:bold` | Texte bleu, gras, italique à 28 pt en Calibri, si cette police est disponible. |
| `TextBox.html` | `color:#0000ff; font-style:italic; font-weight:bold` | Texte bleu, gras, italique ; la page ou le navigateur environnant fournit la famille de police et la taille. |
| `ParagraphOnly.html` | `font-weight:bold` | Texte gras ; la page ou le navigateur environnant fournit la famille de police, la taille, la couleur et le style italique. |

La deuxième portion conserve `color:#ff0000`, `font-size:18pt` et `font-weight:bold` dans les trois sorties. Elle conserve également l’italique avec `All` et `TextBox`, mais pas avec `ParagraphOnly`. Restreindre l’héritage ne supprime donc pas la mise en forme assignée explicitement à un paragraphe ou à une portion.

Ouvrez les fichiers dans le même navigateur pour les comparer. Dans les deux modes restreints, les propriétés CSS omises sont résolues par les styles de la page de destination ou les paramètres par défaut du navigateur, de sorte que l’apparence résultante dépend de l’endroit où le HTML est utilisé.

### **Rendre un paragraphe en image**

[Paragraph::getImage](https://reference.aspose.com/slides/php-java/aspose.slides/paragraph/#getImage) rend directement un paragraphe individuel et renvoie un [IImage](https://reference.aspose.com/slides/php-java/aspose.slides/iimage/). Enregistrez le résultat dans un fichier ou un flux avec [IImage::save](https://reference.aspose.com/slides/php-java/aspose.slides/iimage/#save). Vous n’avez pas besoin de rendre la forme contenant ou de recadrer un bitmap manuellement.

[Paragraph::getImage](https://reference.aspose.com/slides/php-java/aspose.slides/paragraph/#getImage) peut renvoyer `null` si le paragraphe est introuvable dans sa collection parente, n’a pas de limites de rendu valides, ou ne peut pas être rendu. Vérifiez le résultat avant de l’enregistrer et libérez l’image retournée après utilisation.

#### **Rendre un paragraphe à l’échelle par défaut**

L’exemple utilise une présentation avec une diapositive dont la première forme est une zone de texte contenant trois paragraphes.

![La zone de texte avec trois paragraphes](paragraph_to_image_input.png)

L’exemple suivant sélectionne le deuxième paragraphe à l’indice 1 et appelle [Paragraph::getImage](https://reference.aspose.com/slides/php-java/aspose.slides/paragraph/#getImage) sans paramètres d’échelle. Il vérifie que la forme contient le paragraphe requis et que le rendu renvoie une image avant d’appeler [IImage::save](https://reference.aspose.com/slides/php-java/aspose.slides/iimage/#save) pour l’enregistrer au format PNG. Le bloc `finally` libère l’image après utilisation.

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

![L’image du paragraphe](paragraph_to_image_output.png)

#### **Rendre un paragraphe dans une cellule de tableau avec mise à l’échelle**

Utilisez la surcharge de [Paragraph::getImage](https://reference.aspose.com/slides/php-java/aspose.slides/paragraph/#getImage) qui accepte les paramètres `$scaleX` et `$scaleY` pour définir les facteurs d’échelle horizontale et verticale. L’exemple suivant crée un tableau, rend le paragraphe dans sa première cellule à deux fois sa largeur et hauteur par défaut, et enregistre le résultat sous forme d’image PNG.

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

Un facteur d’échelle de `1` maintient cet axe à sa taille de pixel par défaut. Par exemple, `2` pour les deux facteurs produit une image dont la largeur et la hauteur sont approximativement deux fois les dimensions par défaut, entraînant quatre fois plus de pixels. Des facteurs plus grands produisent généralement un texte plus net pour le zoom ou les sorties haute résolution, mais augmentent également l’utilisation de mémoire et la taille du fichier. Des facteurs inférieurs à `1` produisent des images plus petites avec moins de détails. Utilisez des facteurs égaux pour préserver le ratio d’aspect du paragraphe ; des facteurs horizontaux et verticaux différents étirent la sortie indépendamment.

Rendre une forme entière avec [Shape::getImage](https://reference.aspose.com/slides/php-java/aspose.slides/shape/#getImage) reste utile lorsque la sortie doit inclure le remplissage, la bordure ou d’autres contextes visuels de la forme. Pour une image contenant uniquement le paragraphe, utilisez [Paragraph::getImage](https://reference.aspose.com/slides/php-java/aspose.slides/paragraph/#getImage).

## **FAQ**

**Puis‑je désactiver complètement le renvoi à la ligne à l'intérieur d'un cadre de texte ?**

Oui. Définissez [TextFrameFormat::setWrapText](https://reference.aspose.com/slides/php-java/aspose.slides/textframeformat/#setWrapText) pour désactiver le renvoi à la ligne afin que les lignes ne se coupent pas aux bords du cadre de texte.

**Comment obtenir les limites exactes sur la diapositive d'un paragraphe spécifique ?**

Utilisez [Paragraph::getRect](https://reference.aspose.com/slides/php-java/aspose.slides/paragraph/#getRect) pour récupérer le rectangle englobant du paragraphe. [Portion::getRect](https://reference.aspose.com/slides/php-java/aspose.slides/portion/#getRect) fournit les limites d’une portion individuelle.

**Où le alignement du paragraphe (gauche, droite, centre ou justifié) est‑il contrôlé ?**

[ParagraphFormat::setAlignment](https://reference.aspose.com/slides/php-java/aspose.slides/paragraphformat/#setAlignment) est un réglage au niveau du paragraphe et s’applique à tout le paragraphe, quel que soit le formatage des portions individuelles. Pour aligner verticalement les polices de tailles différentes au sein de chaque ligne, voir [Aligner les polices dans une ligne](/slides/fr/php-java/text-formatting/#align-fonts-within-a-line).

**Puis‑je définir la langue de vérification pour une partie d’un paragraphe ?**

Oui. Définissez [BasePortionFormat::setLanguageId](https://reference.aspose.com/slides/php-java/aspose.slides/baseportionformat/#setLanguageId) pour des portions individuelles, ainsi un paragraphe peut contenir du texte en plusieurs langues.