---
title: Gérer les champs de texte dans les présentations PowerPoint en JavaScript
linktitle: Champs de texte
type: docs
weight: 52
url: /fr/nodejs-java/text-fields/
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
- Node.js
- JavaScript
- Aspose.Slides
description: "Créer, inspecter, modifier et supprimer des champs de texte dans les présentations PowerPoint avec Aspose.Slides pour Node.js via Java. Conserver la mise en forme et vérifier les fichiers PPTX et PPT enregistrés."
---
## **Vue d'ensemble**

Un paragraphe de texte se compose de portions. Une [Portion](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/portion/) ordinaire contient du texte littéral ; une portion de champ possède également un [Field](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/field/) dont le type identifie une valeur mise à jour automatiquement, comme un numéro de diapositive ou une date. Deux portions peuvent afficher les mêmes caractères alors qu'une seule contient un champ.

Utilisez [Portion.getField](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/portion/#getField) pour les distinguer : il vaut `null` pour du texte ordinaire. [Portion.addField](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/portion/#addField) convertit une portion existante en champ. Conservez un libellé et sa valeur dynamique dans des portions séparées afin que la conversion de la valeur ne remplace pas également le libellé.

Ce guide couvre les champs dans le texte, leur mise en forme et leur enregistrement en PPTX et PPT. Pour les cadres de texte et les paragraphes, voir [Gérer le texte](/slides/fr/nodejs-java/manage-text/).

## **Créer un champ de numéro de diapositive**

L'exemple complet suivant crée une zone de texte contenant un libellé littéral `Slide ` suivi d'un numéro mis à jour automatiquement. Il définit la taille, le poids et la couleur du numéro avant d'ajouter le champ, puis rouvre la présentation enregistrée et vérifie le type de champ, le texte et la mise en forme. Aucun fichier d'entrée n'est requis.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);
    const shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 40, 40, 240, 50);
    shape.addTextFrame("Slide ");
    const paragraph = shape.getTextFrame().getParagraphs().get_Item(0);

    const numberPortion = new aspose.slides.Portion();
    const numberColor = java.newInstanceSync("java.awt.Color", 0, 0, 139);
    numberPortion.getPortionFormat().setFontHeight(24);
    numberPortion.getPortionFormat().setFontBold(java.newByte(aspose.slides.NullableBool.True));
    numberPortion.getPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    numberPortion.getPortionFormat().getFillFormat().getSolidFillColor().setColor(numberColor);
    paragraph.getPortions().add(numberPortion);
    numberPortion.addField(aspose.slides.FieldType.getSlideNumber());

    presentation.save("slide_number.pptx", aspose.slides.SaveFormat.Pptx);

    const reopened = new aspose.slides.Presentation("slide_number.pptx");
    try {
        const savedShape = reopened.getSlides().get_Item(0).getShapes().get_Item(0);
        const savedNumber = savedShape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(1);
        const savedField = savedNumber.getField();
        const hasNumberField = savedField != null && aspose.slides.FieldType.getSlideNumber().getInternalString() === savedField.getType().getInternalString();
        const format = savedNumber.getPortionFormat();
        let formattingPreserved = format.getFontHeight() == 24 && format.getFontBold() == aspose.slides.NullableBool.True;
        formattingPreserved = formattingPreserved && format.getFillFormat().getSolidFillColor().getColor().getRGB() == numberColor.getRGB();

        console.log("Text: " + savedShape.getTextFrame().getText());
        console.log("Slide number field: " + hasNumberField);
        console.log("Formatting preserved: " + formattingPreserved);
    } finally {
        reopened.dispose();
    }
} finally {
    presentation.dispose();
}
```

La nouvelle présentation débute avec le numéro de diapositive 1, donc le texte est `Slide 1`, et les deux vérifications affichent `true`. Le numéro reste un champ après la réouverture ; ce n'est pas un littéral `1`. Les indices dans la vérification font référence à la forme et aux portions créées par cet exemple.

## **Choisir un type de champ**

[FieldType](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/fieldtype/) fournit les méthodes suivantes pour obtenir des valeurs prédéfinies. Passez la valeur appropriée à [addField](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/portion/#addField).

| Méthode | Objectif |
|---|---|
| [getSlideNumber](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/fieldtype/#getSlideNumber) | Le numéro de diapositive actuel. |
| [getDateTime](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/fieldtype/#getDateTime) | Date/heure dans le format par défaut de l'application de rendu. |
| [getDateTime1](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/fieldtype/#getDateTime1)–[getDateTime9](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/fieldtype/#getDateTime9) | Formats de date prédéfinis ou formats combinés date/heure. |
| [getDateTime10](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/fieldtype/#getDateTime10)–[getDateTime13](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/fieldtype/#getDateTime13) | Formats d'heure prédéfinis, avec options pour les secondes et une horloge 12 heures. |
| [getHeader](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/fieldtype/#getHeader) | Un champ d'en-tête ; voir les limitations de l'espace réservé et du format ci‑dessous. |
| [getFooter](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/fieldtype/#getFooter) | Un champ de pied de page. |

Par exemple, [getDateTime3](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/fieldtype/#getDateTime3) représente le jour, le nom complet du mois et l'année en anglais. Ce sont des formats de champ prédéfinis, pas des chaînes de format de date arbitraires. La langue définie avec [setLanguageId](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/baseportionformat/#setLanguageId) et l'application qui traite la présentation peuvent influencer le résultat affiché.

## **Créer un champ à partir d'une chaîne interne**

La surcharge chaîne de [addField](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/portion/#addField) accepte un identifiant de champ interne. Utilisez‑la lorsqu’il faut conserver un identifiant fourni par une autre application qui n’a pas de valeur prédéfinie. Vous pouvez également créer un [FieldType](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/fieldtype/) à partir de cet identifiant. [FieldType.getInternalString](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/fieldtype/#getInternalString) expose cet identifiant pour inspection.

Cet exemple stocke un champ spécifique à l'application `custom-report-id` avec le texte de secours `Report-042`. L'identifiant n’enregistre pas de calcul : Aspose.Slides ne génère pas d’identifiants de rapport pour un type inconnu. L'application qui comprend cet identifiant doit fournir sa signification et mettre à jour sa valeur.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const shape = presentation.getSlides().get_Item(0).getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 40, 40, 300, 50);
    shape.addTextFrame("Report-042");
    const portion = shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0);
    portion.addField("custom-report-id");

    presentation.save("custom_field.pptx", aspose.slides.SaveFormat.Pptx);

    const reopened = new aspose.slides.Presentation("custom_field.pptx");
    try {
        const savedShape = reopened.getSlides().get_Item(0).getShapes().get_Item(0);
        const savedPortion = savedShape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0);
        const savedField = savedPortion.getField();
        const typeName = savedField == null ? "ordinary text" : savedField.getType().getInternalString();
        console.log("Type: " + typeName);
        console.log("Text: " + savedPortion.getText());
    } finally {
        reopened.dispose();
    }
} finally {
    presentation.dispose();
}
```

Après ce aller‑retour PPTX, le type est `custom-report-id` et le texte est `Report-042`. Fournir une chaîne telle que `yyyy-MM-dd` nommerait un type de champ ; cela ne configurerait pas un format de date personnalisé. Pour une date fixe dans un format arbitraire, utilisez du texte ordinaire.

## **Inspecter, modifier et supprimer les champs date/heure**

Modifiez un champ existant via [Field.setType](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/field/#setType). Vérifiez que le champ existe avant d’accéder à son type. Pour arrêter les mises à jour automatiques, appelez [Portion.removeField](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/portion/#removeField). Cela conserve la portion et son texte actuel tout en supprimant l’association du champ. Si vous avez besoin d’une valeur fixe spécifique, attribuez ce texte après avoir retiré le champ.

Pour le paramètre d’API lié au traitement des champs date/heure, voir [Presentation.setCurrentDateTime](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/presentation/#setCurrentDateTime). L'exemple ci‑dessous utilise une date d'approbation explicite lors de la conversion d'un champ en texte ordinaire.

Téléchargez [sample.pptx](sample.pptx) et placez‑le dans le répertoire de travail. Il contient deux formes de texte nommées, `UpdatedAt` et `ApprovedDate`, chacune avec un champ date/heure, ainsi que des libellés de texte ordinaire. L'exemple suivant parcourt les formes de texte de niveau supérieur sur les diapositives classiques. Il transforme les champs date/heure en un format de date longue et les met en italique, tout en conservant leurs autres formatages. Seuls les champs de `ApprovedDate` deviennent du texte fixe.

La date d'approbation est le 5 avril 2030 ; les indices de mois en JavaScript commencent à zéro, donc avril correspond à `3`. UTC est utilisé à la fois pour la création et le formatage afin que la date reste indépendante du fuseau horaire local.

L'exemple reconnaît les identifiants internes intégrés `datetime` et `datetime1` à `datetime13`. Les groupes, tableaux, notes, mises en page et masques maîtres nécessitent le parcours de leurs propres conteneurs de texte et sont hors du périmètre de cet exemple.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new aspose.slides.Presentation("sample.pptx");
try {
    const approvalDate = new Date(Date.UTC(2030, 3, 5));
    const dateFormat = new Intl.DateTimeFormat("en-GB", { day: "2-digit", month: "long", year: "numeric", timeZone: "UTC" });

    for (let slideIndex = 0; slideIndex < presentation.getSlides().size(); slideIndex++) {
        const slide = presentation.getSlides().get_Item(slideIndex);
        for (let shapeIndex = 0; shapeIndex < slide.getShapes().size(); shapeIndex++) {
            const shape = slide.getShapes().get_Item(shapeIndex);
            if (!java.instanceOf(shape, "com.aspose.slides.IAutoShape")) {
                continue;
            }
            if (shape.getTextFrame() == null) {
                continue;
            }

            for (let paragraphIndex = 0; paragraphIndex < shape.getTextFrame().getParagraphs().getCount(); paragraphIndex++) {
                const paragraph = shape.getTextFrame().getParagraphs().get_Item(paragraphIndex);
                for (let portionIndex = 0; portionIndex < paragraph.getPortions().getCount(); portionIndex++) {
                    const portion = paragraph.getPortions().get_Item(portionIndex);
                    const field = portion.getField();
                    if (field == null) {
                        continue;
                    }

                    const typeName = field.getType().getInternalString();
                    const isDateTime = typeName != null && /^datetime([1-9]|1[0-3])?$/.test(typeName);
                    if (!isDateTime) {
                        continue;
                    }

                    field.setType(aspose.slides.FieldType.getDateTime3());
                    portion.getPortionFormat().setLanguageId("en-US");
                    portion.getPortionFormat().setFontItalic(java.newByte(aspose.slides.NullableBool.True));

                    if (shape.getName() === "ApprovedDate") {
                        portion.removeField();
                        const fixedDate = dateFormat.format(approvalDate);
                        portion.setText(fixedDate);
                    }
                }
            }
        }
    }

    presentation.save("updated_dates.pptx", aspose.slides.SaveFormat.Pptx);

    const reopened = new aspose.slides.Presentation("updated_dates.pptx");
    try {
        for (let shapeIndex = 0; shapeIndex < reopened.getSlides().get_Item(0).getShapes().size(); shapeIndex++) {
            const shape = reopened.getSlides().get_Item(0).getShapes().get_Item(shapeIndex);
            if (!java.instanceOf(shape, "com.aspose.slides.IAutoShape")) {
                continue;
            }
            if (shape.getTextFrame() == null) {
                continue;
            }
            if (shape.getName() !== "UpdatedAt" && shape.getName() !== "ApprovedDate") {
                continue;
            }

            const portion = shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0);
            const field = portion.getField();
            const typeName = field == null ? "ordinary text" : field.getType().getInternalString();
            console.log(shape.getName() + ": " + typeName + "; " + portion.getText());
            console.log("Italic: " + portion.getPortionFormat().getFontItalic());
        }
    } finally {
        reopened.dispose();
    }
} finally {
    presentation.dispose();
}
```

Après réouverture, `UpdatedAt` a le type `datetime3` et reste dynamique. `ApprovedDate` n'a pas de champ et contient `05 April 2030`. Les deux portions de date sont en italique, et leur taille de police, graisse et couleur d'origine restent intactes. Les libellés de texte ordinaire sont inchangés. La vérification lit la première portion des deux formes connues dans l'échantillon fourni.

## **Conserver la mise en forme du texte**

Travaillez avec la portion existante lors de l'ajout d'un champ, du changement de son type ou de sa suppression. Ces opérations conservent la mise en forme de cette portion. Utilisez [Portion.getPortionFormat](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/portion/#getPortionFormat) pour modifier uniquement les propriétés requises, comme le font les exemples pour la couleur ou l'italique.

Évitez de reconstruire tout un cadre de texte uniquement pour mettre à jour un champ : cela peut entraîner la perte des délimitations originales des portions et de leur mise en forme individuelle. Distinguiez également la mise en forme définie explicitement de celle héritée du paragraphe, de la mise en page ou du thème. Voir [Text Formatting](/slides/fr/nodejs-java/text-formatting/) pour des options de mise en forme plus larges.

## **Champs et espaces réservés d'en-tête/pied de page**

Un champ fait partie d'une portion de texte. Un espace réservé est une forme avec un rôle de présentation, comme un pied de page ou un numéro de diapositive. Ajouter un champ à une zone de texte ordinaire ne transforme pas cette forme en espace réservé.

Les gestionnaires d'en‑tête/pied de page contrôlent le texte et la visibilité des espaces réservés sur les diapositives, les mises en page et les masques maîtres, y compris leur propagation aux diapositives dépendantes. Un champ numérique dans une zone de texte personnalisée peut donc être utile même si vous n'utilisez pas l'espace réservé du numéro de diapositive. À l'inverse, modifier la visibilité d'un espace réservé ne supprime pas un champ d'une zone de texte non liée.

Les types d'en‑tête et de pied de page prédéfinis ne créent pas les espaces réservés correspondants ni ne fournissent leur contenu. En particulier, une diapositive PowerPoint standard n’a pas d’espace réservé d’en‑tête ; les en‑têtes appartiennent aux pages de notes et aux documents de distribution. Ne supposez pas qu’un champ d’en‑tête ou de pied de page dans une forme quelconque obtienne automatiquement le texte configuré via un gestionnaire d’espace réservé. Pour ce flux de travail, voir [Presentation Headers and Footers](/slides/fr/nodejs-java/presentation-header-and-footer/).

## **Limitations PPTX et PPT**

Vérifiez à la fois le type de champ et le texte qui en résulte après l’enregistrement et la réouverture. Conserver un identifiant ne prouve pas qu’une application puisse calculer ou afficher sa valeur.

| Format | Comportement du champ et limitations |
|---|---|
| PPTX | Stocke les identifiants internes des champs avec le texte du champ. Dans les vérifications en aller‑retour, les types prédéfinis et l’identifiant personnalisé utilisé ci‑dessus ont survécu à l’enregistrement et à la réouverture. Le type personnalisé inconnu a conservé son texte de secours ; il n’a pas acquis de logique de calcul automatique. Une autre application peut traiter les identifiants non pris en charge différemment. |
| PPT | Utilise des représentations de champ héritées et possède une compatibilité plus limitée. Dans les vérifications en aller‑retour, les champs de numéro de diapositive et les champs date/heure prédéfinis ont survécu à l’enregistrement et à la réouverture. Un champ personnalisé dans une zone de texte de diapositive ordinaire a été rouvert avec son identifiant mais avec `*` comme texte ; un champ d’en‑tête dans le même contexte a également produit `*`. Ne comptez pas sur le fait que les champs personnalisés ou les contextes de champ non pris en charge conservent leur texte visible. |

Pour une sortie portable et fixe, convertissez les champs non pris en charge en texte ordinaire et attribuez explicitement la valeur souhaitée avant l’enregistrement. Cela préserve le texte choisi tout en arrêtant intentionnellement les mises à jour automatiques. Testez également l’application cible lorsque son propre recalcul de champ fait partie de votre flux de travail.

## **FAQ**

**Comment savoir si un numéro ou une date affiché(e) est un champ ?**

Inspectez [Portion.getField](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/portion/#getField). Une valeur non nulle identifie un champ ; le texte affiché seul ne peut pas le déterminer.

**La suppression d’un champ supprime‑t‑elle son texte ou sa mise en forme ?**

Non. [removeField](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/portion/#removeField) convertit la portion existante en texte ordinaire. Attribuez une valeur explicite ensuite si vous avez besoin d’une date figée particulière ou d’une valeur de secours.

**Une chaîne interne peut‑elle définir un nouveau format de date ou une formule ?**

Non. Elle identifie un type de champ. Un identifiant inconnu ne fournit pas d’évaluateur ni de modèle de format de date. Utilisez un type prédéfini pris en charge ou formatez vous‑même la valeur en texte ordinaire.

**Pourquoi vérifier à nouveau une présentation après l’avoir enregistrée ?**

Les identifiants de champ, le texte calculé et la mise en forme sont des éléments distincts à vérifier. La conversion de format peut modifier le résultat visible même si l’identifiant du champ est toujours présent.