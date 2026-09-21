---
title: Gérer les champs de texte dans les présentations PowerPoint en PHP
linktitle: Champs de texte
type: docs
weight: 52
url: /fr/php-java/text-fields/
keywords:
- champ de texte
- texte automatique
- numéro de diapositive
- date et heure
- en-tête
- pied de page
- portion de texte
- PowerPoint
- PPT
- PPTX
- PHP
- Aspose.Slides
description: "Créer, inspecter, modifier et supprimer des champs de texte dans les présentations PowerPoint avec Aspose.Slides pour PHP via Java. Conserver la mise en forme et vérifier les fichiers PPTX et PPT enregistrés."
---
## **Vue d'ensemble**

Un paragraphe de texte se compose de portions. Une [Portion](https://reference.aspose.com/slides/fr/php-java/aspose.slides/portion/) ordinaire contient du texte littéral ; une portion de champ possède également un [Field](https://reference.aspose.com/slides/fr/php-java/aspose.slides/field/) dont le type identifie une valeur mise à jour automatiquement, comme le numéro de diapositive ou la date. Deux portions peuvent afficher les mêmes caractères alors qu’une seule contient un champ.

Utilisez [Portion::getField](https://reference.aspose.com/slides/fr/php-java/aspose.slides/portion/#getField) pour les distinguer : il vaut `null` pour du texte ordinaire. [Portion::addField](https://reference.aspose.com/slides/fr/php-java/aspose.slides/portion/#addField) convertit une portion existante en champ. Conservez une étiquette et sa valeur dynamique dans des portions séparées afin que la conversion de la valeur ne remplace pas également l’étiquette.

Ce guide couvre les champs à l’intérieur du texte, leur mise en forme et leur enregistrement en PPTX et PPT. Pour les cadres de texte et les paragraphes, voir [Manage Text](/slides/fr/php-java/manage-text/).

## **Créer un champ de numéro de diapositive**

L’exemple complet suivant crée une zone de texte contenant une étiquette littérale `Slide ` suivie d’un numéro mis à jour automatiquement. Il définit la taille, le poids et la couleur du numéro avant d’ajouter le champ, puis rouvre la présentation enregistrée et vérifie le type, le texte et la mise en forme du champ. Aucun fichier d’entrée n’est requis.

```php
use aspose\slides\FieldType;
use aspose\slides\FillType;
use aspose\slides\NullableBool;
use aspose\slides\Portion;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 40, 40, 240, 50);
    $shape->addTextFrame("Slide ");
    $paragraph = $shape->getTextFrame()->getParagraphs()->get_Item(0);

    $numberPortion = new Portion();
    $numberColor = new Java("java.awt.Color", 0, 0, 139);
    $numberPortion->getPortionFormat()->setFontHeight(24);
    $numberPortion->getPortionFormat()->setFontBold(NullableBool::True);
    $numberPortion->getPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
    $numberPortion->getPortionFormat()->getFillFormat()->getSolidFillColor()->setColor($numberColor);
    $paragraph->getPortions()->add($numberPortion);
    $numberPortion->addField(FieldType::getSlideNumber());

    $presentation->save("slide_number.pptx", SaveFormat::Pptx);

    $reopened = new Presentation("slide_number.pptx");
    try {
        $savedShape = $reopened->getSlides()->get_Item(0)->getShapes()->get_Item(0);
        $savedNumber = $savedShape->getTextFrame()->getParagraphs()->get_Item(0)->getPortions()->get_Item(1);
        $savedField = $savedNumber->getField();
        $hasNumberField = !java_is_null($savedField) && java_values(FieldType::getSlideNumber()->getInternalString()) === java_values($savedField->getType()->getInternalString());
        $format = $savedNumber->getPortionFormat();
        $formattingPreserved = java_values($format->getFontHeight()) == 24 && java_values($format->getFontBold()) == NullableBool::True;
        $formattingPreserved = $formattingPreserved && java_values($format->getFillFormat()->getSolidFillColor()->getColor()->getRGB()) == java_values($numberColor->getRGB());

        echo "Text: " . $savedShape->getTextFrame()->getText() . PHP_EOL;
        echo "Slide number field: " . ($hasNumberField ? "true" : "false") . PHP_EOL;
        echo "Formatting preserved: " . ($formattingPreserved ? "true" : "false") . PHP_EOL;
    } finally {
        $reopened->dispose();
    }
} finally {
    $presentation->dispose();
}
```

La nouvelle présentation commence avec le numéro de diapositive 1, ainsi le texte est `Slide 1`, et les deux vérifications affichent `true`. Le numéro reste un champ après la réouverture ; ce n’est pas le littéral `1`. Les indices dans la vérification font référence à la forme et aux portions créées par cet exemple.

## **Choisir un type de champ**

[FieldType](https://reference.aspose.com/slides/fr/php-java/aspose.slides/fieldtype/) fournit les méthodes suivantes pour obtenir des valeurs prédéfinies. Transmettez la valeur appropriée à [addField](https://reference.aspose.com/slides/fr/php-java/aspose.slides/portion/#addField).

| Méthode | Objectif |
|---|---|
| [getSlideNumber](https://reference.aspose.com/slides/fr/php-java/aspose.slides/fieldtype/#getSlideNumber) | Le numéro de diapositive actuel. |
| [getDateTime](https://reference.aspose.com/slides/fr/php-java/aspose.slides/fieldtype/#getDateTime) | Date/heure dans le format par défaut de l’application de rendu. |
| [getDateTime1](https://reference.aspose.com/slides/fr/php-java/aspose.slides/fieldtype/#getDateTime1)-[getDateTime9](https://reference.aspose.com/slides/fr/php-java/aspose.slides/fieldtype/#getDateTime9) | Formats de date prédéfinis ou combinaisons date/heure. |
| [getDateTime10](https://reference.aspose.com/slides/fr/php-java/aspose.slides/fieldtype/#getDateTime10)-[getDateTime13](https://reference.aspose.com/slides/fr/php-java/aspose.slides/fieldtype/#getDateTime13) | Formats d’heure prédéfinis, avec options pour les secondes et une horloge 12 heures. |
| [getHeader](https://reference.aspose.com/slides/fr/php-java/aspose.slides/fieldtype/#getHeader) | Un champ d’en‑tête ; voir les limitations de l’emplacement et du format ci‑dessous. |
| [getFooter](https://reference.aspose.com/slides/fr/php-java/aspose.slides/fieldtype/#getFooter) | Un champ de pied de page. |

Par exemple, [getDateTime3](https://reference.aspose.com/slides/fr/php-java/aspose.slides/fieldtype/#getDateTime3) représente le jour, le nom complet du mois et l’année en anglais. Il s’agit de formats de champ prédéfinis, et non de chaînes de format de date PHP arbitraires. La langue définie avec [setLanguageId](https://reference.aspose.com/slides/fr/php-java/aspose.slides/baseportionformat/#setLanguageId) et l’application qui traite la présentation peuvent influencer le résultat affiché.

## **Créer un champ à partir d’une chaîne interne**

La surcharge chaîne de [addField](https://reference.aspose.com/slides/fr/php-java/aspose.slides/portion/#addField) accepte un identifiant de champ interne. Utilisez‑la pour conserver un identifiant fourni par une autre application qui n’a pas de valeur prédéfinie. Vous pouvez également créer un [FieldType](https://reference.aspose.com/slides/fr/php-java/aspose.slides/fieldtype/#FieldType) à partir de l’identifiant. [FieldType::getInternalString](https://reference.aspose.com/slides/fr/php-java/aspose.slides/fieldtype/#getInternalString) expose cet identifiant pour inspection.

Cet exemple stocke un champ propre à l’application `custom-report-id` avec le texte de secours `Report-042`. L’identifiant n’enregistre aucune référence de calcul : Aspose.Slides ne génère pas d’identifiants de rapport pour un type inconnu. L’application qui comprend cet identifiant doit fournir sa signification et mettre à jour sa valeur.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $shape = $presentation->getSlides()->get_Item(0)->getShapes()->addAutoShape(ShapeType::Rectangle, 40, 40, 300, 50);
    $shape->addTextFrame("Report-042");
    $portion = $shape->getTextFrame()->getParagraphs()->get_Item(0)->getPortions()->get_Item(0);
    $portion->addField("custom-report-id");

    $presentation->save("custom_field.pptx", SaveFormat::Pptx);

    $reopened = new Presentation("custom_field.pptx");
    try {
        $savedShape = $reopened->getSlides()->get_Item(0)->getShapes()->get_Item(0);
        $savedPortion = $savedShape->getTextFrame()->getParagraphs()->get_Item(0)->getPortions()->get_Item(0);
        $savedField = $savedPortion->getField();
        $typeName = java_is_null($savedField) ? "ordinary text" : java_values($savedField->getType()->getInternalString());
        echo "Type: " . $typeName . PHP_EOL;
        echo "Text: " . $savedPortion->getText() . PHP_EOL;
    } finally {
        $reopened->dispose();
    }
} finally {
    $presentation->dispose();
}
```

Après ce cycle PPTX, le type est `custom-report-id` et le texte est `Report-042`. Fournir une chaîne comme `Y-m-d` nommerait un type de champ ; cela ne configurerait pas de format de date personnalisé. Pour une date fixe dans un format quelconque, utilisez du texte ordinaire.

## **Inspecter, modifier et supprimer les champs date/heure**

Modifiez un champ existant via [Field::setType](https://reference.aspose.com/slides/fr/php-java/aspose.slides/field/#setType). Vérifiez que le champ existe avant d’accéder à son type. Pour arrêter les mises à jour automatiques, appelez [Portion::removeField](https://reference.aspose.com/slides/fr/php-java/aspose.slides/portion/#removeField). Cela conserve la portion et son texte actuel tout en supprimant l’association du champ. Si vous avez besoin d’une valeur fixe spécifique, attribuez ce texte après avoir supprimé le champ.

Pour le paramètre d’API associé au traitement des champs date/heure, voir [Presentation::setCurrentDateTime](https://reference.aspose.com/slides/fr/php-java/aspose.slides/presentation/#setCurrentDateTime). L’exemple ci‑dessus utilise une date d’approbation explicite lors de la conversion d’un champ en texte ordinaire.

Téléchargez [sample.pptx](sample.pptx) et placez‑le dans le répertoire de travail JavaBridge, ou transmettez son chemin absolu au constructeur de présentation. Il contient deux formes de texte nommées, `UpdatedAt` et `ApprovedDate`, chacune avec un champ date/heure, plus des étiquettes de texte ordinaire. L’exemple suivant parcourt les formes de texte de niveau supérieur sur les diapositives normales. Il convertit les champs date/heure en format date longue et les rend italiques, tout en préservant leurs autres mises en forme. Seuls les champs de `ApprovedDate` deviennent du texte fixe.

L’échantillon reconnaît les identifiants internes intégrés `datetime` et `datetime1` à `datetime13`. Les groupes, tableaux, notes, dispositions et maîtres nécessitent le parcours de leurs propres conteneurs de texte et sont hors du périmètre de cet exemple.

```php
use aspose\slides\FieldType;
use aspose\slides\NullableBool;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("sample.pptx");
try {
    $approvalDate = new DateTimeImmutable("2030-04-05");
    $autoShapeClass = new JavaClass("com.aspose.slides.AutoShape");

    for ($slideIndex = 0; $slideIndex < java_values($presentation->getSlides()->size()); $slideIndex++) {

        $slide = $presentation->getSlides()->get_Item($slideIndex);
        for ($shapeIndex = 0; $shapeIndex < java_values($slide->getShapes()->size()); $shapeIndex++) {
            $shape = $slide->getShapes()->get_Item($shapeIndex);
            if (!java_instanceof($shape, $autoShapeClass)) {
                continue;
            }
            $textShape = $shape;
            if (java_is_null($textShape->getTextFrame())) {
                continue;
            }

            for ($paragraphIndex = 0; $paragraphIndex < java_values($textShape->getTextFrame()->getParagraphs()->getCount()); $paragraphIndex++) {

                $paragraph = $textShape->getTextFrame()->getParagraphs()->get_Item($paragraphIndex);
                for ($portionIndex = 0; $portionIndex < java_values($paragraph->getPortions()->getCount()); $portionIndex++) {
                    $portion = $paragraph->getPortions()->get_Item($portionIndex);
                    $field = $portion->getField();
                    if (java_is_null($field)) {
                        continue;
                    }

                    $typeName = java_values($field->getType()->getInternalString());
                    $isDateTime = $typeName != null && preg_match("/\Adatetime([1-9]|1[0-3])?\z/", $typeName) === 1;
                    if (!$isDateTime) {
                        continue;
                    }

                    $field->setType(FieldType::getDateTime3());
                    $portion->getPortionFormat()->setLanguageId("en-US");
                    $portion->getPortionFormat()->setFontItalic(NullableBool::True);

                    if (java_values($textShape->getName()) === "ApprovedDate") {
                        $portion->removeField();
                        $fixedDate = $approvalDate->format("d F Y");
                        $portion->setText($fixedDate);
                    }
                }
            }
        }
    }

    $presentation->save("updated_dates.pptx", SaveFormat::Pptx);

    $reopened = new Presentation("updated_dates.pptx");
    try {
        for ($shapeIndex = 0; $shapeIndex < java_values($reopened->getSlides()->get_Item(0)->getShapes()->size()); $shapeIndex++) {
            $shape = $reopened->getSlides()->get_Item(0)->getShapes()->get_Item($shapeIndex);
            if (!java_instanceof($shape, $autoShapeClass)) {
                continue;
            }
            $textShape = $shape;
            if (java_is_null($textShape->getTextFrame())) {
                continue;
            }
            if (java_values($textShape->getName()) !== "UpdatedAt" && java_values($textShape->getName()) !== "ApprovedDate") {
                continue;
            }

            $portion = $textShape->getTextFrame()->getParagraphs()->get_Item(0)->getPortions()->get_Item(0);
            $field = $portion->getField();
            $typeName = java_is_null($field) ? "ordinary text" : java_values($field->getType()->getInternalString());
            echo $textShape->getName() . ": " . $typeName . "; " . $portion->getText() . PHP_EOL;
            echo "Italic: " . $portion->getPortionFormat()->getFontItalic() . PHP_EOL;
        }
    } finally {
        $reopened->dispose();
    }
} finally {
    $presentation->dispose();
}
```

Après réouverture, `UpdatedAt` a le type `datetime3` et reste dynamique. `ApprovedDate` n’a aucun champ et contient `05 April 2030`. Les deux portions date sont en italique, et leur taille de police, gras et couleur d’origine restent intacts. Les étiquettes de texte ordinaires sont inchangées. La vérification lit la première portion des deux formes connues dans l’échantillon fourni.

## **Conserver la mise en forme du texte**

Travaillez avec la portion existante lors de l’ajout d’un champ, du changement de son type ou de sa suppression. Ces opérations conservent la mise en forme de cette portion. Utilisez [Portion::getPortionFormat](https://reference.aspose.com/slides/fr/php-java/aspose.slides/portion/#getPortionFormat) pour modifier uniquement les propriétés requises, comme le font les exemples pour la couleur ou l’italique.

Évitez de reconstruire tout un cadre de texte simplement pour mettre à jour un champ : cela peut perdre les limites originales des portions et leur mise en forme individuelle. Distinguisez également la mise en forme définie explicitement de celle héritée du paragraphe, de la disposition ou du thème. Voir [Text Formatting](/slides/fr/php-java/text-formatting/) pour des options de mise en forme plus larges.

## **Champs et espaces réservés d’en‑tête/pied de page**

Un champ fait partie d’une portion de texte. Un espace réservé est une forme avec un rôle dans la présentation, comme un pied de page ou le numéro de diapositive. Ajouter un champ à une zone de texte ordinaire ne transforme pas cette forme en espace réservé.

Les gestionnaires d’en‑tête/pied de page contrôlent le texte et la visibilité des espaces réservés sur les diapositives, les dispositions et les modèles, y compris la propagation aux diapositives dépendantes. Un champ numéro dans une zone de texte personnalisée peut donc être utile même si vous n’utilisez pas l’espace réservé du numéro de diapositive. Inversement, modifier la visibilité d’un espace réservé ne supprime pas un champ d’une zone de texte non liée.

Les types d’en‑tête et de pied de page prédéfinis ne créent pas les espaces réservés correspondants ni ne fournissent leur contenu. En particulier, une diapositive PowerPoint standard n’a pas d’espace réservé d’en‑tête ; les en‑têtes appartiennent aux pages de notes et aux prospectus. Ne supposez pas qu’un champ d’en‑tête ou de pied de page dans une forme quelconque obtiendra automatiquement le texte configuré via un gestionnaire d’espaces réservés. Pour ce flux de travail, voir [Presentation Headers and Footers](/slides/fr/php-java/presentation-header-and-footer/).

## **Limitations PPTX et PPT**

Vérifiez à la fois le type de champ et le texte résultant après l’enregistrement et la réouverture. Conserver un identifiant ne prouve pas qu’une application peut calculer ou afficher sa valeur.

| Format | Comportement du champ et limitations |
|---|---|
| PPTX | Stocke les identifiants internes des champs ainsi que le texte du champ. Dans les vérifications de cycle complet, les types prédéfinis et l’identifiant personnalisé utilisé ci‑dessus ont survécu à l’enregistrement et à la réouverture. Le type personnalisé inconnu a conservé son texte de secours ; il n’a pas acquis de logique de calcul automatique. Une autre application peut traiter les identifiants non pris en charge différemment. |
| PPT | Utilise des représentations de champs héritées et possède une compatibilité plus limitée. Dans les vérifications de cycle complet, les champs numéro de diapositive et les champs date/heure prédéfinis ont survécu à l’enregistrement et à la réouverture. Un champ personnalisé dans une zone de texte ordinaire de diapositive a rouvert avec son identifiant mais avec `*` comme texte ; un champ d’en‑tête dans le même contexte a également produit `*`. Ne comptez pas sur le fait que les champs personnalisés ou les contextes de champ non pris en charge conservent leur texte visible. |

Pour une sortie portable et fixe, convertissez les champs non pris en charge en texte ordinaire et attribuez explicitement la valeur souhaitée avant l’enregistrement. Cela préserve le texte choisi mais interrompt intentionnellement les mises à jour automatiques. Testez également l’application cible lorsque son propre recalcul de champ fait partie de votre flux de travail.

## **FAQ**

**Comment savoir si un nombre ou une date affiché(e) est un champ ?**  
Inspectez [Portion::getField](https://reference.aspose.com/slides/fr/php-java/aspose.slides/portion/#getField). Une valeur non nulle identifie un champ ; le texte affiché seul ne peut pas le révéler.

**La suppression d’un champ supprime‑t‑elle son texte ou sa mise en forme ?**  
Non. [removeField](https://reference.aspose.com/slides/fr/php-java/aspose.slides/portion/#removeField) convertit la portion existante en texte ordinaire. Attribuez une valeur explicite après si vous avez besoin d’une date figée ou d’une valeur de secours particulière.

**Une chaîne interne peut‑elle définir un nouveau format de date ou une formule ?**  
Non. Elle identifie un type de champ. Un identifiant inconnu ne fournit ni évaluateur ni motif de format de date PHP. Utilisez un type prédéfini pris en charge ou formatez vous‑même la valeur en texte ordinaire.

**Pourquoi vérifier à nouveau une présentation après l’avoir enregistrée ?**  
Les identifiants de champ, le texte calculé et la mise en forme sont des éléments distincts à vérifier. La conversion de format peut modifier le résultat visible même si l’identifiant du champ est toujours présent.