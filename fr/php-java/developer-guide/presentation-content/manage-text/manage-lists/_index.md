---
title: Gérer les listes à puces et numérotées dans les présentations avec PHP
linktitle: Gestion des listes
type: docs
weight: 60
url: /fr/php-java/manage-lists/
keywords:
- puce
- liste à puces
- liste numérotée
- puce symbole
- puce image
- puce personnalisée
- liste à plusieurs niveaux
- créer une puce
- ajouter une puce
- ajouter une liste
- PowerPoint
- OpenDocument
- présentation
- PHP
- Aspose.Slides
description: "Apprenez à créer et formater des listes à puces, des puces image, des listes à plusieurs niveaux et des listes numérotées dans les présentations PowerPoint et OpenDocument en utilisant Aspose.Slides pour PHP via Java."
---
## **Vue d'ensemble**

Aspose.Slides for PHP via Java vous permet de créer et de formater des listes à puces et numérotées dans les présentations PowerPoint et OpenDocument. Un élément de liste est un paragraphe dont les paramètres de puce sont contrôlés via son format de paragraphe.

Utilisez la méthode [Paragraph::getParagraphFormat](https://reference.aspose.com/slides/php-java/aspose.slides/paragraph/#getParagraphFormat) pour accéder aux paramètres de liste au niveau du paragraphe. Le point d'entrée principal est [ParagraphFormat::getBullet](https://reference.aspose.com/slides/php-java/aspose.slides/paragraphformat/#getBullet) qui renvoie un objet [BulletFormat](https://reference.aspose.com/slides/php-java/aspose.slides/bulletformat/) . Avec cet objet, vous pouvez définir le type de puce, le symbole, l'image, la couleur, la taille, le style de numérotation et le numéro de départ.

Cet article montre comment :

- créer une liste à puces avec un symbole personnalisé
- créer une puce image
- créer une liste à plusieurs niveaux en définissant la profondeur du paragraphe
- créer une liste numérotée
- examiner et modifier le formatage des listes dans une présentation existante
- lire les indicateurs de liste réels et les numéros à côté du texte du paragraphe

## **Créer une liste à puces**

Pour créer une liste à puces, ajoutez des objets [Paragraph](https://reference.aspose.com/slides/php-java/aspose.slides/paragraph/) à un [TextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/textframe/) et définissez [BulletFormat::setType](https://reference.aspose.com/slides/php-java/aspose.slides/bulletformat/#setType) sur [BulletType::Symbol](https://reference.aspose.com/slides/php-java/aspose.slides/bullettype/#Symbol). Vous pouvez ensuite définir [BulletFormat::setChar](https://reference.aspose.com/slides/php-java/aspose.slides/bulletformat/#setChar), [BulletFormat::getColor](https://reference.aspose.com/slides/php-java/aspose.slides/bulletformat/#getColor) et [BulletFormat::setHeight](https://reference.aspose.com/slides/php-java/aspose.slides/bulletformat/#setHeight) pour contrôler l'apparence de la puce.

Le code PHP suivant montre comment créer une liste à puces dans une diapositive :

```php
use aspose\slides\BulletType;
use aspose\slides\NullableBool;
use aspose\slides\Paragraph;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

function createParagraph($paragraphText)
{
    $paragraph = new Paragraph();
    $paragraph->getParagraphFormat()->getBullet()->setType(BulletType::Symbol);
    $paragraph->getParagraphFormat()->getBullet()->setChar("*");
    $paragraph->getParagraphFormat()->setIndent(15);
    $paragraph->getParagraphFormat()->getBullet()->setBulletHardColor(NullableBool::True);
    $bulletColor = new Java("java.awt.Color", 205, 92, 92);
    $paragraph->getParagraphFormat()->getBullet()->getColor()->setColor($bulletColor);
    $paragraph->getParagraphFormat()->getBullet()->setHeight(100);
    $paragraph->setText($paragraphText);
    return $paragraph;
}

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $autoShape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 20, 20, 200, 50);

    $textFrame = $autoShape->getTextFrame();
    $textFrame->getParagraphs()->clear();

    $paragraph1 = createParagraph("The first paragraph");
    $textFrame->getParagraphs()->add($paragraph1);

    $paragraph2 = createParagraph("The second paragraph");
    $textFrame->getParagraphs()->add($paragraph2);

    $presentation->save("symbol_bullets.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Le résultat :

![Les puces de symbole](symbol_bullets.png)

## **Créer une liste numérotée**

Utilisez les listes numérotées lorsque l'ordre des éléments est important. Définissez [BulletFormat::setType](https://reference.aspose.com/slides/php-java/aspose.slides/bulletformat/#setType) sur [BulletType::Numbered](https://reference.aspose.com/slides/php-java/aspose.slides/bullettype/#Numbered). Vous pouvez également choisir un format de numérotation avec [BulletFormat::setNumberedBulletStyle](https://reference.aspose.com/slides/php-java/aspose.slides/bulletformat/#setNumberedBulletStyle) ou définir [BulletFormat::setNumberedBulletStartWith](https://reference.aspose.com/slides/php-java/aspose.slides/bulletformat/#setNumberedBulletStartWith) lorsque la liste doit commencer à une valeur différente de 1.

Le code PHP suivant montre comment créer une liste numérotée dans une diapositive :

```php
use aspose\slides\BulletType;
use aspose\slides\Paragraph;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $autoShape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 20, 20, 90, 80);

    $textFrame = $autoShape->getTextFrame();
    $textFrame->getParagraphs()->clear();

    $paragraph1 = new Paragraph();
    $paragraph1->getParagraphFormat()->getBullet()->setType(BulletType::Numbered);
    $paragraph1->setText("Apple");
    $textFrame->getParagraphs()->add($paragraph1);

    $paragraph2 = new Paragraph();
    $paragraph2->getParagraphFormat()->getBullet()->setType(BulletType::Numbered);
    $paragraph2->setText("Orange");
    $textFrame->getParagraphs()->add($paragraph2);

    $paragraph3 = new Paragraph();
    $paragraph3->getParagraphFormat()->getBullet()->setType(BulletType::Numbered);
    $paragraph3->setText("Banana");
    $textFrame->getParagraphs()->add($paragraph3);

    $presentation->save("numbered_bullets.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Le résultat :

![Les puces numérotées](numbered_bullets.png)

## **Créer une puce image**

Aspose.Slides vous permet de remplacer un symbole de puce standard par une image. Les puces image fonctionnent mieux avec des images simples qui restent lisibles à petite taille, comme des icônes ou de petits fichiers PNG transparents.

{{% alert color="info" title="Note" %}}
Idéalement, si vous prévoyez de remplacer le symbole de puce standard par une image, il est préférable de choisir un graphique simple avec un arrière‑plan transparent. Ces images fonctionnent bien comme symboles de puce personnalisés.

Gardez à l'esprit que l'image sera réduite à une taille très petite. Pour cette raison, nous recommandons fortement de choisir une image qui reste nette et visuellement efficace lorsqu'elle est utilisée comme puce dans une liste.
{{% /alert %}}

Pour créer une puce image, ajoutez une image à [Presentation::getImages](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/#getImages) et affectez l'objet [PPImage](https://reference.aspose.com/slides/php-java/aspose.slides/ppimage/) renvoyé à [BulletFormat::getPicture](https://reference.aspose.com/slides/php-java/aspose.slides/bulletformat/#getPicture). Définissez [BulletFormat::setType](https://reference.aspose.com/slides/php-java/aspose.slides/bulletformat/#setType) sur [BulletType::Picture](https://reference.aspose.com/slides/php-java/aspose.slides/bullettype/#Picture) avant d'attribuer l'image.

Supposons que nous ayons un « image.png » :

![Une image pour les puces](picture_for_bullets.png)

Le code PHP suivant montre comment créer des puces image dans une diapositive :

```php
use aspose\slides\BulletType;
use aspose\slides\Images;
use aspose\slides\Paragraph;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

function createParagraph($paragraphText, $bulletImage)
{
    $paragraph = new Paragraph();
    $paragraph->getParagraphFormat()->getBullet()->setType(BulletType::Picture);
    $paragraph->getParagraphFormat()->getBullet()->getPicture()->setImage($bulletImage);
    $paragraph->getParagraphFormat()->setIndent(15);
    $paragraph->getParagraphFormat()->getBullet()->setHeight(100);
    $paragraph->setText($paragraphText);
    return $paragraph;
}

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $autoShape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 20, 20, 200, 50);

    $textFrame = $autoShape->getTextFrame();
    $textFrame->getParagraphs()->clear();

    $image = Images::fromFile("image.png");
    $bulletImage = $presentation->getImages()->addImage($image);

    $paragraph1 = createParagraph("The first paragraph", $bulletImage);
    $textFrame->getParagraphs()->add($paragraph1);

    $paragraph2 = createParagraph("The second paragraph", $bulletImage);
    $textFrame->getParagraphs()->add($paragraph2);

    $presentation->save("picture_bullets.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Le résultat :

![Les puces image](picture_bullets.png)

## **Créer une liste à plusieurs niveaux**

Utilisez [ParagraphFormat::setDepth](https://reference.aspose.com/slides/php-java/aspose.slides/paragraphformat/#setDepth) pour placer les éléments de liste à différents niveaux. Le niveau 0 est le niveau supérieur, le niveau 1 est imbriqué en dessous, etc.

Le code PHP suivant montre comment créer une liste à puces à plusieurs niveaux :

```php
use aspose\slides\Paragraph;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $autoShape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 20, 20, 260, 110);

    $textFrame = $autoShape->getTextFrame();
    $textFrame->getParagraphs()->clear();

    $paragraph1 = new Paragraph();
    $paragraph1->getParagraphFormat()->setDepth(0);
    $paragraph1->setText("My text - Depth 0");
    $textFrame->getParagraphs()->add($paragraph1);

    $paragraph2 = new Paragraph();
    $paragraph2->getParagraphFormat()->setDepth(1);
    $paragraph2->setText("My text - Depth 1");
    $textFrame->getParagraphs()->add($paragraph2);

    $paragraph3 = new Paragraph();
    $paragraph3->getParagraphFormat()->setDepth(2);
    $paragraph3->setText("My text - Depth 2");
    $textFrame->getParagraphs()->add($paragraph3);

    $paragraph4 = new Paragraph();
    $paragraph4->getParagraphFormat()->setDepth(3);
    $paragraph4->setText("My text - Depth 3");
    $textFrame->getParagraphs()->add($paragraph4);

    $presentation->save("multilevel_bullets.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Le résultat :

![La liste à plusieurs niveaux](multilevel_list.png)

## **Modifier une liste existante**

Pour modifier le formatage d'une liste dans une présentation existante, accédez au paragraphe cible et mettez à jour ses paramètres [ParagraphFormat::getBullet](https://reference.aspose.com/slides/php-java/aspose.slides/paragraphformat/#getBullet). Les mêmes propriétés utilisées pour créer des listes peuvent être utilisées pour inspecter ou modifier des listes chargées à partir d'un fichier PPT, PPTX ou ODP.

Le code PHP suivant modifie le premier paragraphe d'un cadre de texte pour utiliser un style de liste numérotée :

```php
use aspose\slides\BulletType;
use aspose\slides\NumberedBulletStyle;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("input.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $autoShape = $slide->getShapes()->get_Item(0);

    $paragraph = $autoShape->getTextFrame()->getParagraphs()->get_Item(0);
    $paragraph->getParagraphFormat()->getBullet()->setType(BulletType::Numbered);
    $paragraph->getParagraphFormat()->getBullet()->setNumberedBulletStyle(NumberedBulletStyle::BulletRomanUCPeriod);
    $paragraph->getParagraphFormat()->getBullet()->setNumberedBulletStartWith(1);
    $paragraph->getParagraphFormat()->setMarginLeft(30);
    $paragraph->getParagraphFormat()->setIndent(-20);

    $presentation->save("updated_list.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Lire les valeurs réelles des puces**

Lors de l'extraction du contenu d'une présentation, conservez les indicateurs de liste à côté du texte du paragraphe. Appelez [ParagraphFormat::getEffective](https://reference.aspose.com/slides/php-java/aspose.slides/paragraphformat/#getEffective) et accédez à [ParagraphFormatEffectiveData::getBullet](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraphformateffectivedata/#getBullet--) pour obtenir le format de puce effectif. Vérifiez son [getType](https://reference.aspose.com/slides/java/com.aspose.slides/ibulletformateffectivedata/#getType--) avant de lire [getActualBulletValue](https://reference.aspose.com/slides/java/com.aspose.slides/ibulletformateffectivedata/#getActualBulletValue--).

Pour les listes numérotées, distinguez ces trois valeurs :

- [getNumberedBulletStyle](https://reference.aspose.com/slides/java/com.aspose.slides/ibulletformateffectivedata/#getNumberedBulletStyle--) détermine le format, par exemple des nombres arabes suivis d'un point ou des lettres minuscules suivies d'un point.
- [getNumberedBulletStartWith](https://reference.aspose.com/slides/java/com.aspose.slides/ibulletformateffectivedata/#getNumberedBulletStartWith--) spécifie le numéro de départ pour un groupe de paragraphes numérotés.
- [getActualBulletValue](https://reference.aspose.com/slides/java/com.aspose.slides/ibulletformateffectivedata/#getActualBulletValue--) renvoie le marqueur formaté pour un paragraphe particulier. Par exemple, le deuxième élément d'une liste commençant à 5 renvoie `6.`.

Conservez [getDepth](https://reference.aspose.com/slides/php-java/aspose.slides/paragraphformat/#getDepth) avec chaque paragraphe pour retenir son niveau d'imbrication. Le marqueur réel n'encode pas la hiérarchie complète : un élément imbriqué peut renvoyer `c.` plutôt qu'une étiquette combinée comme `6.c.`.

L'exemple autonome suivant crée des listes, les enregistre dans une présentation, puis recharge la présentation pour rapporter le texte, la profondeur, le type de puce et la valeur réelle de chaque paragraphe. Le petit marqueur image bleu est créé à partir d'un SVG en ligne.

```php
use aspose\slides\BulletType;
use aspose\slides\FillType;
use aspose\slides\NullableBool;
use aspose\slides\NumberedBulletStyle;
use aspose\slides\Paragraph;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;
use aspose\slides\SlideSizeScaleType;
use aspose\slides\SvgImage;

$presentation = new Presentation();
try {
    $presentation->getSlideSize()->setSize(720, 440, SlideSizeScaleType::DoNotScale);
    $slide = $presentation->getSlides()->get_Item(0);

    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 30, 20, 660, 400);
    $shape->getFillFormat()->setFillType(FillType::NoFill);
    $shape->getLineFormat()->getFillFormat()->setFillType(FillType::NoFill);

    $textFrame = $shape->getTextFrame();
    $textFrame->getParagraphs()->clear();

    // Crée un marqueur image sans fichier image externe.
    $svg = new SvgImage("<svg xmlns='http://www.w3.org/2000/svg' width='16' height='16'><rect width='16' height='16' rx='4' fill='#0078D4'/></svg>");
    $bulletImage = $presentation->getImages()->addImage($svg);

    $black = new Java("java.awt.Color", 0, 0, 0);
    $addParagraph = function ($text, $depth, $type, $start, $style) use ($textFrame, $bulletImage, $black) {
        $paragraph = new Paragraph();
        $paragraph->setText($text);

        $format = $paragraph->getParagraphFormat();
        $format->setDepth($depth);
        $format->setMarginLeft(30 + $depth * 40);
        $format->setIndent(-28);
        $format->setSpaceAfter(8);
        $format->getDefaultPortionFormat()->setFontHeight(22);
        $format->getDefaultPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
        $format->getDefaultPortionFormat()->getFillFormat()->getSolidFillColor()->setColor($black);
        $format->getBullet()->setType($type);
        $format->getBullet()->setBulletHardColor(NullableBool::True);
        $format->getBullet()->getColor()->setColor($black);
        if ($type == BulletType::Numbered) {
            $format->getBullet()->setNumberedBulletStyle($style);
            $format->getBullet()->setNumberedBulletStartWith($start);
        } else if ($type == BulletType::Symbol) {
            $format->getBullet()->setChar("\u{2022}");
        } else if ($type == BulletType::Picture) {
            $format->getBullet()->getPicture()->setImage($bulletImage);
        }

        $textFrame->getParagraphs()->add($paragraph);
    };

    $addParagraph("First item", 0, BulletType::Numbered, 5, NumberedBulletStyle::BulletArabicPeriod);
    $addParagraph("Second item", 0, BulletType::Numbered, 5, NumberedBulletStyle::BulletArabicPeriod);
    $addParagraph("Nested item", 1, BulletType::Numbered, 3, NumberedBulletStyle::BulletAlphaLCPeriod);
    $addParagraph("Next nested item", 1, BulletType::Numbered, 3, NumberedBulletStyle::BulletAlphaLCPeriod);
    $addParagraph("Deep item", 2, BulletType::Numbered, 4, NumberedBulletStyle::BulletRomanLCPeriod);
    $addParagraph("Back to top level", 0, BulletType::Numbered, 5, NumberedBulletStyle::BulletArabicPeriod);
    $addParagraph("Symbol marker", 0, BulletType::Symbol, 1, NumberedBulletStyle::BulletArabicPeriod);
    $addParagraph("No bullet", 0, BulletType::None, 1, NumberedBulletStyle::BulletArabicPeriod);
    $addParagraph("Picture marker", 0, BulletType::Picture, 1, NumberedBulletStyle::BulletArabicPeriod);
    $presentation->save("actual_bullet_values.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}

$loadedPresentation = new Presentation("actual_bullet_values.pptx");
try {
    $loadedShape = $loadedPresentation->getSlides()->get_Item(0)->getShapes()->get_Item(0);
    echo "Text | Depth | Type | Actual value\n";
    $paragraphs = $loadedShape->getTextFrame()->getParagraphs();
    for ($i = 0; $i < java_values($paragraphs->getCount()); $i++) {
        $paragraph = $paragraphs->get_Item($i);
        $bullet = $paragraph->getParagraphFormat()->getEffective()->getBullet();
        switch (java_values($bullet->getType())) {
            case BulletType::Numbered:
            case BulletType::Symbol:
                $marker = $bullet->getActualBulletValue();
                break;
            case BulletType::None:
                $marker = "null (no bullet)";
                break;
            case BulletType::Picture:
                $marker = "null (image required)";
                break;
            default:
                $marker = "unsupported bullet type";
                break;
        }
        $typeNames = [BulletType::Numbered => "Numbered", BulletType::Symbol => "Symbol", BulletType::None => "None", BulletType::Picture => "Picture"];
        $typeName = $typeNames[java_values($bullet->getType())] ?? "Unknown";
        echo $paragraph->getText() . " | " . $paragraph->getParagraphFormat()->getDepth() . " | " . $typeName . " | " . $marker . "\n";
    }
} finally {
    $loadedPresentation->dispose();
}
```

Les listes sources sont affichées ci-dessous.

![Listes commençant à 5, éléments imbriqués en lettres et chiffres romains, un marqueur symbole, un paragraphe sans puce, et un petit marqueur image bleu](actual_bullet_values.png)

Le rapport correspond aux marqueurs affichés dans PowerPoint :

```text
Text | Depth | Type | Actual value
First item | 0 | Numbered | 5.
Second item | 0 | Numbered | 6.
Nested item | 1 | Numbered | c.
Next nested item | 1 | Numbered | d.
Deep item | 2 | Numbered | iv.
Back to top level | 0 | Numbered | 7.
Symbol marker | 0 | Symbol | •
No bullet | 0 | None | null (no bullet)
Picture marker | 0 | Picture | null (image required)
```

Pour [BulletType::None and BulletType::Picture](https://reference.aspose.com/slides/php-java/aspose.slides/bullettype/), [getActualBulletValue](https://reference.aspose.com/slides/java/com.aspose.slides/ibulletformateffectivedata/#getActualBulletValue--) renvoie `null`, et non une chaîne vide. Gérez ces types séparément : le premier n'a aucun marqueur, tandis que le second nécessite d'extraire séparément l'image de la puce. Une puce image ne peut pas être reproduite simplement en extrayant un marqueur texte.

## **FAQ**

**Les listes à puces et numérotées peuvent-elles être exportées en PDF ou en images ?**

Oui. Aspose.Slides conserve le formatage des listes lorsque le format cible prend en charge la disposition du texte et les fonctions de puces correspondantes.

**Puis-je modifier les listes dans des présentations existantes ?**

Oui. Chargez la présentation, accédez au paragraphe ciblé, inspectez ou mettez à jour ses paramètres [ParagraphFormat::getBullet](https://reference.aspose.com/slides/php-java/aspose.slides/paragraphformat/#getBullet), puis enregistrez la présentation.

**Les listes peuvent-elles contenir du texte non latin ?**

Oui. Le texte des éléments de liste peut contenir des caractères Unicode, vous pouvez donc créer des listes dans des présentations multilingues. Assurez‑vous que les polices utilisées dans la présentation prennent en charge les caractères requis.