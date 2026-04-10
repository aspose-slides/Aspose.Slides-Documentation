---
title: Gérer les paragraphes de texte PowerPoint en PHP
linktitle: Gérer le paragraphe
type: docs
weight: 40
url: /fr/php-java/manage-paragraph/
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
- texte vers HTML
- paragraphe vers HTML
- paragraphe vers image
- texte vers image
- exporter le paragraphe
- PowerPoint
- OpenDocument
- présentation
- PHP
- Aspose.Slides
description: "Maîtriser la mise en forme des paragraphes avec Aspose.Slides pour PHP via Java — optimiser l'alignement, l'espacement et le style dans les présentations PPT, PPTX et ODP."
---
Aspose.Slides fournit toutes les classes dont vous avez besoin pour travailler avec les textes, les paragraphes et les fragments de PowerPoint.

* Aspose.Slides fournit la classe [TextFrame](https://reference.aspose.com/slides/fr/php-java/aspose.slides/textframe/) permettant d’ajouter des objets représentant un paragraphe. Un objet `TextFame` peut contenir un ou plusieurs paragraphes (chaque paragraphe est créé par un retour chariot).
* Aspose.Slides fournit la classe [Paragraph](https://reference.aspose.com/slides/fr/php-java/aspose.slides/paragraph/) permettant d’ajouter des objets représentant des fragments. Un objet `Paragraph` peut contenir un ou plusieurs fragments (collection d’objets de fragment).
* Aspose.Slides fournit la classe [Portion](https://reference.aspose.com/slides/fr/php-java/aspose.slides/portion/) permettant d’ajouter des objets représentant du texte et leurs propriétés de mise en forme.

Un objet `Paragraph` peut gérer du texte avec différentes propriétés de mise en forme grâce à ses objets sous-jacents `Portion`.

## **Ajouter plusieurs paragraphes contenant plusieurs fragments**

Ces étapes montrent comment ajouter un cadre de texte contenant 3 paragraphes et chaque paragraphe contenant 3 fragments :

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/fr/php-java/aspose.slides/presentation/).
2. Accédez à la référence de la diapositive concernée via son indice.
3. Ajoutez une [AutoShape](https://reference.aspose.com/slides/fr/php-java/aspose.slides/autoshape/) rectangulaire à la diapositive.
4. Récupérez l’`ITextFrame` associé à l’[AutoShape](https://reference.aspose.com/slides/fr/php-java/aspose.slides/autoshape/).
5. Créez deux objets [Paragraph](https://reference.aspose.com/slides/fr/php-java/aspose.slides/paragraph/) et ajoutez-les à la collection de paragraphes du [TextFrame](https://reference.aspose.com/slides/fr/php-java/aspose.slides/textframe/).
6. Créez trois objets [Portion](https://reference.aspose.com/slides/fr/php-java/aspose.slides/portion/) pour chaque nouveau `Paragraph` (deux objets Portion pour le paragraphe par défaut) et ajoutez chaque objet `Portion` à la collection de fragments de chaque `Paragraph`.
7. Définissez du texte pour chaque fragment.
8. Appliquez les caractéristiques de mise en forme souhaitées à chaque fragment en utilisant les propriétés de mise en forme exposées par l’objet `Portion`.
9. Enregistrez la présentation modifiée.

```php
# Instancier une classe Presentation qui représente un fichier PPTX
$pres = new Presentation();
try {
    # Accéder à la première diapositive
    $slide = $pres->getSlides()->get_Item(0);
    # Ajouter une AutoShape de type Rectangle
    $ashp = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 150, 300, 150);
    # Accéder au TextFrame de l'AutoShape
    $tf = $ashp->getTextFrame();
    # Create Paragraphs and Portions with different text formats
    $para0 = $tf->getParagraphs()->get_Item(0);
    $port01 = new Portion();
    $port02 = new Portion();
    $para0->getPortions()->add($port01);
    $para0->getPortions()->add($port02);
    $para1 = new Paragraph();
    $tf->getParagraphs()->add($para1);
    $port10 = new Portion();
    $port11 = new Portion();
    $port12 = new Portion();
    $para1->getPortions()->add($port10);
    $para1->getPortions()->add($port11);
    $para1->getPortions()->add($port12);
    $para2 = new Paragraph();
    $tf->getParagraphs()->add($para2);
    $port20 = new Portion();
    $port21 = new Portion();
    $port22 = new Portion();
    $para2->getPortions()->add($port20);
    $para2->getPortions()->add($port21);
    $para2->getPortions()->add($port22);
    for($i = 0; $i < 3; $i++) {
        for($j = 0; $j < 3; $j++) {
            $portion = $tf->getParagraphs()->get_Item($i)->getPortions()->get_Item($j);
            $portion->setText("Portion0" . $j);
            if ($j == 0) {
                $portion->getPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
                $portion->getPortionFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->RED);
                $portion->getPortionFormat()->setFontBold(NullableBool::True);
                $portion->getPortionFormat()->setFontHeight(15);
            } else if ($j == 1) {
                $portion->getPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
                $portion->getPortionFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLUE);
                $portion->getPortionFormat()->setFontItalic(NullableBool::True);
                $portion->getPortionFormat()->setFontHeight(18);
            }
        }
    }
    # Enregistrer le PPTX sur le disque
    $pres->save("multiParaPort_out.pptx", SaveFormat::Pptx);
} finally {
    if (!java_is_null($pres)) {
        $pres->dispose();
    }
}
```

## **Gérer les puces de paragraphe**

Les listes à puces vous aident à organiser et présenter l’information rapidement et efficacement. Les paragraphes à puces sont toujours plus faciles à lire et à comprendre.

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/fr/php-java/aspose.slides/presentation/).
2. Accédez à la référence de la diapositive concernée via son indice.
3. Ajoutez une [AutoShape](https://reference.aspose.com/slides/fr/php-java/aspose.slides/autoshape/) à la diapositive sélectionnée.
4. Accédez au [TextFrame](https://reference.aspose.com/slides/fr/php-java/aspose.slides/textframe/) de l’autoforme.
5. Supprimez le paragraphe par défaut dans le `TextFrame`.
6. Créez la première instance de paragraphe en utilisant la classe [Paragraph](https://reference.aspose.com/slides/fr/php-java/aspose.slides/paragraph/).
7. Définissez le `Type` de puce du paragraphe sur `Symbol` et indiquez le caractère de la puce.
8. Définissez le `Text` du paragraphe.
9. Définissez le `Indent` du paragraphe pour la puce.
10. Définissez une couleur pour la puce.
11. Définissez une hauteur pour la puce.
12. Ajoutez le nouveau paragraphe à la collection de paragraphes du `TextFrame`.
13. Ajoutez le deuxième paragraphe et répétez le processus indiqué aux étapes 7 à 13.
14. Enregistrez la présentation.

```php
# Instancie une classe Presentation qui représente un fichier PPTX
$pres = new Presentation();
try {
    # Accède à la première diapositive
    $slide = $pres->getSlides()->get_Item(0);
    # Ajoute et accède à l'AutoShape
    $aShp = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 200, 200, 400, 200);
    # Accède au cadre texte de l'autoforme
    $txtFrm = $aShp->getTextFrame();
    # Supprime le paragraphe par défaut
    $txtFrm->getParagraphs()->removeAt(0);
    # Crée un paragraphe
    $para = new Paragraph();
    # Définit le style de puce du paragraphe et le symbole
    $para->getParagraphFormat()->getBullet()->setType(BulletType::Symbol);
    $para->getParagraphFormat()->getBullet()->setChar(8226);
    # Définit le texte du paragraphe
    $para->setText("Welcome to Aspose.Slides");
    # Définit le retrait de la puce
    $para->getParagraphFormat()->setIndent(25);
    # Définit la couleur de la puce
    $para->getParagraphFormat()->getBullet()->getColor()->setColorType(ColorType::RGB);
    $para->getParagraphFormat()->getBullet()->getColor()->setColor(java("java.awt.Color")->BLACK);
    $para->getParagraphFormat()->getBullet()->setBulletHardColor(NullableBool::True);// définir IsBulletHardColor à true pour utiliser sa propre couleur de puce

    # Définit la hauteur de la puce
    $para->getParagraphFormat()->getBullet()->setHeight(100);
    # Ajoute le paragraphe au cadre texte
    $txtFrm->getParagraphs()->add($para);
    # Crée le deuxième paragraphe
    $para2 = new Paragraph();
    # Définit le type et le style de puce du paragraphe
    $para2->getParagraphFormat()->getBullet()->setType(BulletType::Numbered);
    $para2->getParagraphFormat()->getBullet()->setNumberedBulletStyle(NumberedBulletStyle->BulletCircleNumWDBlackPlain);
    # Ajoute le texte du paragraphe
    $para2->setText("This is numbered bullet");
    # Définit le retrait de la puce
    $para2->getParagraphFormat()->setIndent(25);
    $para2->getParagraphFormat()->getBullet()->getColor()->setColorType(ColorType::RGB);
    $para2->getParagraphFormat()->getBullet()->getColor()->setColor(java("java.awt.Color")->BLACK);
    $para2->getParagraphFormat()->getBullet()->setBulletHardColor(NullableBool::True);// définir IsBulletHardColor à true pour utiliser sa propre couleur de puce

    # Définit la hauteur de la puce
    $para2->getParagraphFormat()->getBullet()->setHeight(100);
    # Ajoute le paragraphe au cadre texte
    $txtFrm->getParagraphs()->add($para2);
    # Enregistre la présentation modifiée
    $pres->save("Bullet_out.pptx", SaveFormat::Pptx);
} finally {
    if (!java_is_null($pres)) {
        $pres->dispose();
    }
}
```

## **Gérer les puces d’image**

Les listes à puces vous aident à organiser et présenter l’information rapidement et efficacement. Les paragraphes avec image sont faciles à lire et à comprendre.

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/fr/php-java/aspose.slides/presentation/).
2. Accédez à la référence de la diapositive concernée via son indice.
3. Ajoutez une [AutoShape](https://reference.aspose.com/slides/fr/php-java/aspose.slides/autoshape/) à la diapositive.
4. Accédez au [TextFrame](https://reference.aspose.com/slides/fr/php-java/aspose.slides/textframe/) de l’autoforme.
5. Supprimez le paragraphe par défaut dans le `TextFrame`.
6. Créez la première instance de paragraphe en utilisant la classe [Paragraph](https://reference.aspose.com/slides/fr/php-java/aspose.slides/paragraph/).
7. Chargez l’image dans [PPImage](https://reference.aspose.com/slides/fr/php-java/aspose.slides/ppimage/).
8. Définissez le type de puce sur [Picture](https://reference.aspose.com/slides/fr/php-java/aspose.slides/bullettype/#Picture) et définissez l’image.
9. Définissez le `Text` du Paragraph.
10. Définissez le `Indent` du Paragraph pour la puce.
11. Définissez une couleur pour la puce.
12. Définissez une hauteur pour la puce.
13. Ajoutez le nouveau paragraphe à la collection de paragraphes du `TextFrame`.
14. Ajoutez le deuxième paragraphe et répétez le processus basé sur les étapes précédentes.
15. Enregistrez la présentation modifiée.

```php
# Instancie une classe Presentation qui représente un fichier PPTX
$presentation = new Presentation();
try {
    # Accède à la première diapositive
    $slide = $presentation->getSlides()->get_Item(0);
    # Instancie l'image pour les puces
    $picture;
    $image = Images->fromFile("bullets.png");
    try {
        $picture = $presentation->getImages()->addImage($image);
    } finally {
        if (!java_is_null($image)) {
            $image->dispose();
        }
    }
    # Ajoute et accède à l'AutoShape
    $autoShape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 200, 200, 400, 200);
    # Accède au cadre texte de l'autoshape
    $textFrame = $autoShape->getTextFrame();
    # Supprime le paragraphe par défaut
    $textFrame->getParagraphs()->removeAt(0);
    # Crée un nouveau paragraphe
    $paragraph = new Paragraph();
    $paragraph->setText("Welcome to Aspose.Slides");
    # Définit le style de puce du paragraphe et l'image
    $paragraph->getParagraphFormat()->getBullet()->setType(BulletType::Picture);
    $paragraph->getParagraphFormat()->getBullet()->getPicture()->setImage($picture);
    # Définit la hauteur de la puce
    $paragraph->getParagraphFormat()->getBullet()->setHeight(100);
    # Ajoute le paragraphe au cadre texte
    $textFrame->getParagraphs()->add($paragraph);
    # Enregistre la présentation sous forme de fichier PPTX
    $presentation->save("ParagraphPictureBulletsPPTX_out.pptx", SaveFormat::Pptx);
    # Enregistre la présentation sous forme de fichier PPT
    $presentation->save("ParagraphPictureBulletsPPT_out.ppt", SaveFormat::Ppt);
} catch (JavaException $e) {
} finally {
    if (!java_is_null($presentation)) {
        $presentation->dispose();
    }
}
```

## **Gérer les puces à plusieurs niveaux**

Les listes à puces vous aident à organiser et présenter l’information rapidement et efficacement. Les puces à plusieurs niveaux sont faciles à lire et à comprendre.

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/fr/php-java/aspose.slides/presentation/).
2. Accédez à la référence de la diapositive concernée via son indice.
3. Ajoutez une [AutoShape](https://reference.aspose.com/slides/fr/php-java/aspose.slides/autoshape/) dans la nouvelle diapositive.
4. Accédez au [TextFrame](https://reference.aspose.com/slides/fr/php-java/aspose.slides/textframe/) de l’autoforme.
5. Supprimez le paragraphe par défaut dans le `TextFrame`.
6. Créez la première instance de paragraphe via la classe [Paragraph](https://reference.aspose.com/slides/fr/php-java/aspose.slides/paragraph/) et définissez la profondeur à 0.
7. Créez la deuxième instance de paragraphe via la classe `Paragraph` et définissez la profondeur à 1.
8. Créez la troisième instance de paragraphe via la classe `Paragraph` et définissez la profondeur à 2.
9. Créez la quatrième instance de paragraphe via la classe `Paragraph` et définissez la profondeur à 3.
10. Ajoutez les nouveaux paragraphes à la collection de paragraphes du `TextFrame`.
11. Enregistrez la présentation modifiée.

```php
# Instancie une classe Presentation qui représente un fichier PPTX
$pres = new Presentation();
try {
    # Accède à la première diapositive
    $slide = $pres->getSlides()->get_Item(0);
    # Ajoute et accède à l'AutoShape
    $aShp = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 200, 200, 400, 200);
    # Accède au cadre texte de l'AutoShape créée
    $text = $aShp->addTextFrame("");
    # Efface le paragraphe par défaut
    $text->getParagraphs()->clear();
    # Ajoute le premier paragraphe
    $para1 = new Paragraph();
    $para1->setText("Content");
    $para1->getParagraphFormat()->getBullet()->setType(BulletType::Symbol);
    $para1->getParagraphFormat()->getBullet()->setChar(8226);
    $para1->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
    $para1->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLACK);
    # Définit le niveau de la puce
    $para1->getParagraphFormat()->setDepth(0);
    # Ajoute le deuxième paragraphe
    $para2 = new Paragraph();
    $para2->setText("Second Level");
    $para2->getParagraphFormat()->getBullet()->setType(BulletType::Symbol);
    $para2->getParagraphFormat()->getBullet()->setChar('-');
    $para2->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
    $para2->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLACK);
    # Définit le niveau de la puce
    $para2->getParagraphFormat()->setDepth(1);
    # Ajoute le troisième paragraphe
    $para3 = new Paragraph();
    $para3->setText("Third Level");
    $para3->getParagraphFormat()->getBullet()->setType(BulletType::Symbol);
    $para3->getParagraphFormat()->getBullet()->setChar(8226);
    $para3->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
    $para3->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLACK);
    # Définit le niveau de la puce
    $para3->getParagraphFormat()->setDepth(2);
    # Ajoute le quatrième paragraphe
    $para4 = new Paragraph();
    $para4->setText("Fourth Level");
    $para4->getParagraphFormat()->getBullet()->setType(BulletType::Symbol);
    $para4->getParagraphFormat()->getBullet()->setChar('-');
    $para4->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
    $para4->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLACK);
    # Définit le niveau de la puce
    $para4->getParagraphFormat()->setDepth(3);
    # Ajoute les paragraphes à la collection
    $text->getParagraphs()->add($para1);
    $text->getParagraphs()->add($para2);
    $text->getParagraphs()->add($para3);
    $text->getParagraphs()->add($para4);
    # Enregistre la présentation sous forme de fichier PPTX
    $pres->save("MultilevelBullet.pptx", SaveFormat::Pptx);
} finally {
    if (!java_is_null($pres)) {
        $pres->dispose();
    }
}
```

## **Gérer un paragraphe avec une liste numérotée personnalisée**

La classe [BulletFormat](https://reference.aspose.com/slides/fr/php-java/aspose.slides/bulletformat/) propose la méthode [setNumberedBulletStartWith](https://reference.aspose.com/slides/fr/php-java/aspose.slides/bulletformat/setnumberedbulletstartwith/) et d’autres qui vous permettent de gérer les paragraphes avec une numérotation ou une mise en forme personnalisée.

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/fr/php-java/aspose.slides/presentation/).
2. Accédez à la diapositive contenant le paragraphe.
3. Ajoutez une [AutoShape](https://reference.aspose.com/slides/fr/php-java/aspose.slides/autoshape/) à la diapositive.
4. Accédez au [TextFrame](https://reference.aspose.com/slides/fr/php-java/aspose.slides/textframe/) de l’autoforme.
5. Supprimez le paragraphe par défaut dans le `TextFrame`.
6. Créez la première instance de paragraphe via la classe [Paragraph](https://reference.aspose.com/slides/fr/php-java/aspose.slides/paragraph/) et définissez [NumberedBulletStartWith](https://reference.aspose.com/slides/fr/php-java/aspose.slides/bulletformat/setnumberedbulletstartwith/) à 2.
7. Créez la deuxième instance de paragraphe via la classe `Paragraph` et définissez `NumberedBulletStartWith` à 3.
8. Créez la troisième instance de paragraphe via la classe `Paragraph` et définissez `NumberedBulletStartWith` à 7.
9. Ajoutez les nouveaux paragraphes à la collection de paragraphes du `TextFrame`.
10. Enregistrez la présentation modifiée.

```php
$presentation = new Presentation();
try {
    $shape = $presentation->getSlides()->get_Item(0)->getShapes()->addAutoShape(ShapeType::Rectangle, 200, 200, 400, 200);
    # Accède au cadre texte de l'autoshape créé
    $textFrame = $shape->getTextFrame();
    # Supprime le paragraphe existant par défaut
    $textFrame->getParagraphs()->removeAt(0);
    # Première liste
    $paragraph1 = new Paragraph();
    $paragraph1->setText("bullet 2");
    $paragraph1->getParagraphFormat()->setDepth(4);
    $paragraph1->getParagraphFormat()->getBullet()->setNumberedBulletStartWith(2);
    $paragraph1->getParagraphFormat()->getBullet()->setType(BulletType::Numbered);
    $textFrame->getParagraphs()->add($paragraph1);
    $paragraph2 = new Paragraph();
    $paragraph2->setText("bullet 3");
    $paragraph2->getParagraphFormat()->setDepth(4);
    $paragraph2->getParagraphFormat()->getBullet()->setNumberedBulletStartWith(3);
    $paragraph2->getParagraphFormat()->getBullet()->setType(BulletType::Numbered);
    $textFrame->getParagraphs()->add($paragraph2);
    $paragraph5 = new Paragraph();
    $paragraph5->setText("bullet 7");
    $paragraph5->getParagraphFormat()->setDepth(4);
    $paragraph5->getParagraphFormat()->getBullet()->setNumberedBulletStartWith(7);
    $paragraph5->getParagraphFormat()->getBullet()->setType(BulletType::Numbered);
    $textFrame->getParagraphs()->add($paragraph5);
    $presentation->save("SetCustomBulletsNumber-slides.pptx", SaveFormat::Pptx);
} finally {
    if (!java_is_null($presentation)) {
        $presentation->dispose();
    }
}
```

## **Définir le retrait de première ligne d’un paragraphe**

Utilisez la méthode [ParagraphFormat::setIndent](https://reference.aspose.com/slides/fr/php-java/aspose.slides/paragraphformat/setindent/) pour contrôler le retrait de première ligne d’un paragraphe. Cette méthode ne déplace que la première ligne par rapport à la marge gauche du paragraphe. Une valeur positive décale la première ligne vers la droite, tandis que les lignes restantes restent alignées au corps du paragraphe.

Utilisez [ParagraphFormat::setMarginLeft](https://reference.aspose.com/slides/fr/php-java/aspose.slides/paragraphformat/setmarginleft/) lorsque vous devez déplacer tout le paragraphe. Utilisez [ParagraphFormat::setIndent](https://reference.aspose.com/slides/fr/php-java/aspose.slides/paragraphformat/setindent/) lorsque vous ne devez déplacer que la première ligne.

L’exemple ci‑dessous crée plusieurs paragraphes et applique différentes valeurs de retrait pour démontrer l’influence du retrait de première ligne sur la mise en page du paragraphe.

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/fr/php-java/aspose.slides/presentation/).
2. Accédez à la diapositive cible.
3. Ajoutez une [AutoShape](https://reference.aspose.com/slides/fr/php-java/aspose.slides/autoshape/) rectangulaire à la diapositive.
4. Ajoutez un [TextFrame](https://reference.aspose.com/slides/fr/php-java/aspose.slides/textframe/) vide à la forme et supprimez le paragraphe par défaut.
5. Créez plusieurs paragraphes et définissez différentes valeurs d’[Indent](https://reference.aspose.com/slides/fr/php-java/aspose.slides/paragraphformat/setindent/) pour ceux‑ci.
6. Ajoutez les paragraphes au cadre de texte.
7. Enregistrez la présentation modifiée.

```php
$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $rectangleShape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle,50,50,420,220);
    $rectangleShape->getFillFormat()->setFillType(FillType::NoFill);
    $rectangleShape->getLineFormat()->getFillFormat()->setFillType(FillType::Solid);
    $rectangleShape->getLineFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->GRAY);

    $textFrame = $rectangleShape->addTextFrame("");
    $textFrame->getTextFrameFormat()->setAutofitType(TextAutofitType::Shape);
    $textFrame->getParagraphs()->removeAt(0);

    $firstParagraph = new Paragraph();
    $firstParagraph->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
    $firstParagraph->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLACK);
    $firstParagraph->setText("No first-line indent. Wrapped lines start at the same position as the first line.");
    $firstParagraph->getParagraphFormat()->setMarginLeft(20.0);
    $firstParagraph->getParagraphFormat()->setIndent(0.0);

    $secondParagraph = new Paragraph();
    $secondParagraph->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
    $secondParagraph->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLACK);
    $secondParagraph->setText("First-line indent of 20 points. The first line moves to the right, while wrapped lines remain aligned to the paragraph body.");
    $secondParagraph->getParagraphFormat()->setMarginLeft(20.0);
    $secondParagraph->getParagraphFormat()->setIndent(20.0);

    $thirdParagraph = new Paragraph();
    $thirdParagraph->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
    $thirdParagraph->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLACK);
    $thirdParagraph->setText("First-line indent of 40 points. This paragraph shows a larger first-line offset to make the effect easier to see.");
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

![Le retrait de première ligne des paragraphes](first_line_indent.png)

## **Définir le retrait suspendu d’un paragraphe**

Un retrait suspendu est une mise en page de paragraphe dans laquelle la première ligne commence à gauche des lignes restantes. Dans Aspose.Slides, vous créez cet effet avec la méthode [ParagraphFormat::setIndent](https://reference.aspose.com/slides/fr/php-java/aspose.slides/paragraphformat/setindent/). Définissez le retrait à une valeur négative pour déplacer la première ligne vers la gauche par rapport au corps du paragraphe.

En pratique, [ParagraphFormat::setMarginLeft](https://reference.aspose.com/slides/fr/php-java/aspose.slides/paragraphformat/setmarginleft/) définit la position gauche du corps du paragraphe, et [ParagraphFormat::setIndent](https://reference.aspose.com/slides/fr/php-java/aspose.slides/paragraphformat/setindent/) définit la position de la première ligne par rapport à cette marge. Pour créer un retrait suspendu, définissez une valeur positive pour `MarginLeft` et une valeur négative pour `Indent`.

Cette mise en forme est utile pour les bibliographies, références, entrées de glossaire et autres paragraphes où les lignes renvoyées doivent s’aligner sous le corps du paragraphe plutôt que sous le premier caractère de la première ligne.

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/fr/php-java/aspose.slides/presentation/).
2. Accédez à la diapositive cible.
3. Ajoutez une [AutoShape](https://reference.aspose.com/slides/fr/php-java/aspose.slides/autoshape/) rectangulaire à la diapositive.
4. Ajoutez un [TextFrame](https://reference.aspose.com/slides/fr/php-java/aspose.slides/textframe/) vide à la forme et supprimez le paragraphe par défaut.
5. Créez des paragraphes et définissez une valeur positive de [MarginLeft](https://reference.aspose.com/slides/fr/php-java/aspose.slides/paragraphformat/setmarginleft/) pour chaque paragraphe.
6. Définissez une valeur négative d’[Indent](https://reference.aspose.com/slides/fr/php-java/aspose.slides/paragraphformat/setindent/) pour créer l’effet de retrait suspendu.
7. Ajoutez les paragraphes au cadre de texte.
8. Enregistrez la présentation modifiée.

```php
$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $rectangleShape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle,50,50,420,220);
    $rectangleShape->getFillFormat()->setFillType(FillType::NoFill);
    $rectangleShape->getLineFormat()->getFillFormat()->setFillType(FillType::Solid);
    $rectangleShape->getLineFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->GRAY);

    $textFrame = $rectangleShape->addTextFrame("");
    $textFrame->getTextFrameFormat()->setAutofitType(TextAutofitType::Shape);
    $textFrame->getParagraphs()->removeAt(0);

    $firstParagraph = new Paragraph();
    $firstParagraph->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
    $firstParagraph->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLACK);
    $firstParagraph->setText("A hanging indent is created by combining a positive left margin with a negative indent. The first line starts to the left, while wrapped lines align with the paragraph body.");
    $firstParagraph->getParagraphFormat()->setMarginLeft(40.0);
    $firstParagraph->getParagraphFormat()->setIndent(-20.0);

    $secondParagraph = new Paragraph();
    $secondParagraph->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
    $secondParagraph->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLACK);
    $secondParagraph->setText("This second example uses a deeper hanging indent so the difference between the first line and the wrapped lines is easier to compare.");
    $secondParagraph->getParagraphFormat()->setMarginLeft(60.0);
    $secondParagraph->getParagraphFormat()->setIndent(-30.0);

    $textFrame->getParagraphs()->add($firstParagraph);
    $textFrame->getParagraphs()->add($secondParagraph);

    $presentation->save("hanging_indent.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

![Le retrait suspendu des paragraphes](hanging_indent.png)

## **Gérer les propriétés de fin de paragraphe**

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/fr/php-java/aspose.slides/presentation/).
2. Obtenez la référence de la diapositive contenant le paragraphe via sa position.
3. Ajoutez un rectangle [AutoShape](https://reference.aspose.com/slides/fr/php-java/aspose.slides/autoshape/) à la diapositive.
4. Ajoutez un [TextFrame](https://reference.aspose.com/slides/fr/php-java/aspose.slides/textframe/) avec deux paragraphes au rectangle.
5. Définissez la hauteur de police et le type de police pour les paragraphes.
6. Définissez les propriétés End pour les paragraphes.
7. Enregistrez la présentation modifiée sous forme de fichier PPTX.

```php
$pres = new Presentation();
try {
    $shape = $pres->getSlides()->get_Item(0)->getShapes()->addAutoShape(ShapeType::Rectangle, 10, 10, 200, 250);
    $para1 = new Paragraph();
    $para1->getPortions()->add(new Portion("Sample text"));
    $para2 = new Paragraph();
    $para2->getPortions()->add(new Portion("Sample text 2"));
    $portionFormat = new PortionFormat();
    $portionFormat::setFontHeight(48);
    $portionFormat::setLatinFont(new FontData("Times New Roman"));
    $para2->setEndParagraphPortionFormat($portionFormat);
    $shape->getTextFrame()->getParagraphs()->add($para1);
    $shape->getTextFrame()->getParagraphs()->add($para2);
    $pres->save($resourcesOutputPath . "pres.pptx", SaveFormat::Pptx);
} finally {
    if (!java_is_null($pres)) {
        $pres->dispose();
    }
}
```

## **Importer du texte HTML dans des paragraphes**

Aspose.Slides fournit une prise en charge améliorée de l’importation de texte HTML dans des paragraphes.

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/fr/php-java/aspose.slides/presentation/).
2. Accédez à la référence de la diapositive concernée via son indice.
3. Ajoutez une [AutoShape](https://reference.aspose.com/slides/fr/php-java/aspose.slides/autoshape/) à la diapositive.
4. Ajoutez et accédez au [TextFrame](https://reference.aspose.com/slides/fr/php-java/aspose.slides/textframe/) de l’`AutoShape`.
5. Supprimez le paragraphe par défaut dans le `TextFrame`.
6. Lisez le fichier HTML source avec un TextReader.
7. Créez la première instance de paragraphe via la classe [Paragraph](https://reference.aspose.com/slides/fr/php-java/aspose.slides/paragraph/).
8. Ajoutez le contenu du fichier HTML lu avec le TextReader à la [ParagraphCollection](https://reference.aspose.com/slides/fr/php-java/aspose.slides/paragraphcollection/) du TextFrame.
9. Enregistrez la présentation modifiée.

```php
# Crée une instance de présentation vide
$pres = new Presentation();
try {
    # Accède à la diapositive par défaut (première) de la présentation
    $slide = $pres->getSlides()->get_Item(0);
    # Ajoute l'AutoShape pour accueillir le contenu HTML
    $ashape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 10, 10, $pres->getSlideSize()->getSize()->getWidth() - 20, $pres->getSlideSize()->getSize()->getHeight() - 10);
    $ashape->getFillFormat()->setFillType(FillType::NoFill);
    # Ajoute un cadre texte à la forme
    $ashape->addTextFrame("");
    # Vide tous les paragraphes du cadre texte ajouté
    $ashape->getTextFrame()->getParagraphs()->clear();
    # Charge le fichier HTML en utilisant un lecteur de flux
    $tr = new StreamReader("file.html");
    # Ajoute le texte du lecteur de flux HTML au cadre texte
    $ashape->getTextFrame()->getParagraphs()->addFromHtml($tr->readToEnd());
    # Enregistre la présentation
    $pres->save("output_out.pptx", SaveFormat::Pptx);
} finally {
    if (!java_is_null($pres)) {
        $pres->dispose();
    }
}
```

## **Exporter le texte d’un paragraphe en HTML**

Aspose.Slides fournit une prise en charge améliorée de l’exportation de textes (contenus dans des paragraphes) vers HTML.

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/fr/php-java/aspose.slides/presentation/) et chargez la présentation souhaitée.
2. Accédez à la référence de la diapositive concernée via son indice.
3. Accédez à la forme contenant le texte qui sera exporté en HTML.
4. Accédez au [TextFrame](https://reference.aspose.com/slides/fr/php-java/aspose.slides/textframe/) de la forme.
5. Créez une instance de `StreamWriter` et ajoutez le nouveau fichier HTML.
6. Fournissez un indice de départ à StreamWriter et exportez les paragraphes souhaités.

```php
# Charge le fichier de présentation
$pres = new Presentation("ExportingHTMLText.pptx");
try {
    # Accède à la première diapositive par défaut de la présentation
    $slide = $pres->getSlides()->get_Item(0);
    # Index souhaité
    $index = 0;
    # Accède à la forme ajoutée
    $ashape = $slide->getShapes()->get_Item($index);
    # Création du fichier HTML de sortie
    $os = new Java("java.io.FileOutputStream", "output.html");
    $writer = new OutputStreamWriter($os, "UTF-8");
    # Extraction du premier paragraphe en HTML
    # Écriture des données des paragraphes en HTML en fournissant l'index de départ du paragraphe, le nombre total de paragraphes à copier
    $writer->write($ashape->getTextFrame()->getParagraphs()->exportToHtml(0, $ashape->getTextFrame()->getParagraphs()->getCount(), null));
    $writer->close();
} catch (JavaException $e) {
} finally {
    if (!java_is_null($pres)) {
        $pres->dispose();
    }
}
```

## **Enregistrer un paragraphe sous forme d’image**

Dans cette section, nous explorerons deux exemples illustrant comment enregistrer un paragraphe de texte, représenté par la classe [Paragraph](https://reference.aspose.com/slides/fr/php-java/aspose.slides/paragraph/), sous forme d’image. Les deux exemples incluent l’obtention de l’image d’une forme contenant le paragraphe à l’aide des méthodes `getImage` de la classe [Shape](https://reference.aspose.com/slides/fr/php-java/aspose.slides/shape/), le calcul des limites du paragraphe au sein de la forme, et son exportation en tant qu’image bitmap. Ces approches permettent d’extraire des parties spécifiques du texte d’une présentation PowerPoint et de les enregistrer comme images séparées, ce qui peut être utile dans divers scénarios.

Supposons que nous ayons un fichier de présentation nommé sample.pptx avec une diapositive, dont la première forme est une zone de texte contenant trois paragraphes.

![La zone de texte avec trois paragraphes](paragraph_to_image_input.png)

**Example 1**

Dans cet exemple, nous obtenons le deuxième paragraphe sous forme d’image. Pour cela, nous extrayons l’image de la forme de la première diapositive de la présentation, puis calculons les limites du deuxième paragraphe dans le cadre de texte de la forme. Le paragraphe est ensuite redessiné sur une nouvelle image bitmap, qui est enregistrée au format PNG. Cette méthode est particulièrement utile lorsque vous devez enregistrer un paragraphe spécifique comme image séparée tout en conservant les dimensions exactes et la mise en forme du texte.

```php
$imageIO = new Java("javax.imageio.ImageIO");

$presentation = new Presentation("sample.pptx");
try {
    $firstShape = $presentation->getSlides()->get_Item(0)->getShapes()->get_Item(0);

    // Enregistre la forme en mémoire sous forme de bitmap.
    $shapeImage = $firstShape->getImage();
    $shapeImageStream = new Java("java.io.ByteArrayOutputStream");
    $shapeImage->save($shapeImageStream, ImageFormat::Png);
    $shapeImage->dispose();

    // Crée un bitmap de forme à partir de la mémoire.
    $shapeImageInputStream = new Java("java.io.ByteArrayInputStream", $shapeImageStream->toByteArray());
    $shapeBitmap = $imageIO->read($shapeImageInputStream);

    // Calcule les limites du deuxième paragraphe.
    $secondParagraph = $firstShape->getTextFrame()->getParagraphs()->get_Item(1);
    $paragraphRectangle = $secondParagraph->getRect();

    // Calcule les coordonnées et la taille pour l'image de sortie (taille minimale - 1x1 pixel).
    $imageX = floor(java_values($paragraphRectangle->getX()));
    $imageY = floor(java_values($paragraphRectangle->getY()));
    $imageWidth = max(1, ceil(java_values($paragraphRectangle->getWidth())));
    $imageHeight = max(1, ceil(java_values($paragraphRectangle->getHeight())));

    // Recadre le bitmap de la forme pour n'obtenir que le bitmap du paragraphe.
    $paragraphBitmap = $shapeBitmap->getSubimage($imageX, $imageY, $imageWidth, $imageHeight);

    $imageIO->write($paragraphBitmap, "png", new Java("java.io.File", "paragraph.png"));
} finally {
    if (!java_is_null($presentation)) {
        $presentation->dispose();
    }
}
```

![L’image du paragraphe](paragraph_to_image_output.png)

**Example 2**

Dans cet exemple, nous étendons l’approche précédente en ajoutant des facteurs d’échelle à l’image du paragraphe. La forme est extraite de la présentation et enregistrée comme image avec un facteur d’échelle de `2`. Cela permet d’obtenir une sortie à résolution plus élevée lors de l’exportation du paragraphe. Les limites du paragraphe sont alors calculées en tenant compte de l’échelle. Le redimensionnement peut être particulièrement utile lorsqu’une image plus détaillée est requise, par exemple pour une utilisation dans des documents imprimés de haute qualité.

```php
$imageIO = new Java("javax.imageio.ImageIO");

$imageScaleX = 2;
$imageScaleY = $imageScaleX;

$presentation = new Presentation("sample.pptx");
try {
    $firstShape = $presentation->getSlides()->get_Item(0)->getShapes()->get_Item(0);

    // Enregistre la forme en mémoire sous forme de bitmap avec mise à l'échelle.
    $shapeImage = $firstShape->getImage(ShapeThumbnailBounds::Shape, $imageScaleX, $imageScaleY);
    $shapeImageStream = new Java("java.io.ByteArrayOutputStream");
    $shapeImage->save($shapeImageStream, ImageFormat::Png);
    $shapeImage->dispose();

    // Crée un bitmap de forme à partir de la mémoire.
    $shapeImageInputStream = new Java("java.io.ByteArrayInputStream", $shapeImageStream->toByteArray());
    $shapeBitmap = $imageIO->read($shapeImageInputStream);

    // Calcule les limites du deuxième paragraphe.
    $secondParagraph = $firstShape->getTextFrame()->getParagraphs()->get_Item(1);
    $paragraphRectangle = $secondParagraph->getRect();
    $paragraphRectangle->setRect(
            java_values($paragraphRectangle->getX()) * $imageScaleX,
            java_values($paragraphRectangle->getY()) * $imageScaleY,
            java_values($paragraphRectangle->getWidth()) * $imageScaleX,
            java_values($paragraphRectangle->getHeight()) * $imageScaleY
    );

    // Calcule les coordonnées et la taille de l'image de sortie (taille minimale - 1x1 pixel).
    $imageX = floor(java_values($paragraphRectangle->getX()));
    $imageY = floor(java_values($paragraphRectangle->getY()));
    $imageWidth = max(1, ceil(java_values($paragraphRectangle->getWidth())));
    $imageHeight = max(1, ceil(java_values($paragraphRectangle->getHeight())));

    // Recadre le bitmap de la forme pour n'obtenir que le bitmap du paragraphe.
    $paragraphBitmap = $shapeBitmap->getSubimage($imageX, $imageY, $imageWidth, $imageHeight);

    $imageIO->write($paragraphBitmap, "png", new Java("java.io.File", "paragraph.png"));
} finally {
    if (!java_is_null($presentation)) {
        $presentation->dispose();
    }
}
```

## **FAQ**

**Puis‑je désactiver complètement le retour à la ligne à l’intérieur d’un TextFrame ?**

Oui. Utilisez le paramètre d’enroulement du TextFrame ([setWrapText](https://reference.aspose.com/slides/fr/php-java/aspose.slides/textframeformat/setwraptext/)) pour désactiver l’enroulement afin que les lignes ne se coupent pas aux bords du cadre.

**Comment puis‑je obtenir les limites exactes sur la diapositive d’un paragraphe spécifique ?**

Vous pouvez récupérer le rectangle englobant du paragraphe (et même d’un seul fragment) pour connaître sa position et ses dimensions précises sur la diapositive.

**Où la justification du paragraphe (gauche/droite/centré/justifié) est‑elle contrôlée ?**

[Alignment](https://reference.aspose.com/slides/fr/php-java/aspose.slides/paragraphformat/setalignment/) est un paramètre au niveau du paragraphe dans [ParagraphFormat](https://reference.aspose.com/slides/fr/php-java/aspose.slides/paragraphformat/); il s’applique à l’ensemble du paragraphe indépendamment de la mise en forme de chaque fragment.

**Puis‑je définir une langue de vérification orthographique pour seulement une partie d’un paragraphe (par ex., un mot) ?**

Oui. La langue est définie au niveau du fragment ([PortionFormat::setLanguageId](https://reference.aspose.com/slides/fr/php-java/aspose.slides/baseportionformat/#setLanguageId)), donc plusieurs langues peuvent coexister au sein d’un même paragraphe.