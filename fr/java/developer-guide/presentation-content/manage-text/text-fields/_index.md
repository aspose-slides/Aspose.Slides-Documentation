---
title: Gérer les champs de texte dans les présentations PowerPoint en Java
linktitle: Champs de texte
type: docs
weight: 52
url: /fr/java/text-fields/
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
- Java
- Aspose.Slides
description: "Créer, inspecter, modifier et supprimer des champs de texte dans les présentations PowerPoint avec Aspose.Slides pour Java. Conserver la mise en forme et vérifier les fichiers PPTX et PPT enregistrés."
---
## **Vue d'ensemble**

Un paragraphe texte se compose de portions. Une [IPortion](https://reference.aspose.com/slides/fr/java/com.aspose.slides/iportion/) ordinaire contient du texte littéral ; une portion de champ possède également un [IField](https://reference.aspose.com/slides/fr/java/com.aspose.slides/ifield/) dont le type identifie une valeur mise à jour automatiquement, comme un numéro de diapositive ou une date. Deux portions peuvent afficher les mêmes caractères alors qu’une seule contient un champ.

Utilisez [IPortion.getField](https://reference.aspose.com/slides/fr/java/com.aspose.slides/iportion/#getField--) pour les distinguer : il est `null` pour du texte ordinaire. [IPortion.addField](https://reference.aspose.com/slides/fr/java/com.aspose.slides/iportion/#addField-com.aspose.slides.IFieldType-) convertit une portion existante en champ. Conservez une étiquette et sa valeur dynamique dans des portions séparées afin que la conversion de la valeur ne remplace pas également l’étiquette.

Ce guide couvre les champs dans le texte, leur mise en forme, et leur enregistrement dans PPTX et PPT. Pour les cadres de texte et les paragraphes, voyez [Manage Text](/slides/fr/java/manage-text/).

## **Créer un champ de numéro de diapositive**

L’exemple complet suivant crée une zone de texte contenant une étiquette littérale `Slide ` suivie d’un numéro mis à jour automatiquement. Il définit la taille, le poids et la couleur du numéro avant d’ajouter le champ, puis rouvre la présentation enregistrée et vérifie le type du champ, le texte et la mise en forme. Aucun fichier d’entrée n’est requis.

```java
import java.awt.Color;
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 40, 40, 240, 50);
    shape.addTextFrame("Slide ");
    IParagraph paragraph = shape.getTextFrame().getParagraphs().get_Item(0);

    Portion numberPortion = new Portion();
    Color numberColor = new Color(0, 0, 139);
    numberPortion.getPortionFormat().setFontHeight(24);
    numberPortion.getPortionFormat().setFontBold(NullableBool.True);
    numberPortion.getPortionFormat().getFillFormat().setFillType(FillType.Solid);
    numberPortion.getPortionFormat().getFillFormat().getSolidFillColor().setColor(numberColor);
    paragraph.getPortions().add(numberPortion);
    numberPortion.addField(FieldType.getSlideNumber());

    presentation.save("slide_number.pptx", SaveFormat.Pptx);

    Presentation reopened = new Presentation("slide_number.pptx");
    try {
        IAutoShape savedShape = (IAutoShape) reopened.getSlides().get_Item(0).getShapes().get_Item(0);
        IPortion savedNumber = savedShape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(1);
        IField savedField = savedNumber.getField();
        boolean hasNumberField = savedField != null && FieldType.getSlideNumber().getInternalString().equals(savedField.getType().getInternalString());
        IPortionFormat format = savedNumber.getPortionFormat();
        boolean formattingPreserved = format.getFontHeight() == 24 && format.getFontBold() == NullableBool.True;
        formattingPreserved &= format.getFillFormat().getSolidFillColor().getColor().getRGB() == numberColor.getRGB();

        System.out.println("Text: " + savedShape.getTextFrame().getText());
        System.out.println("Slide number field: " + hasNumberField);
        System.out.println("Formatting preserved: " + formattingPreserved);
    } finally {
        reopened.dispose();
    }
} finally {
    presentation.dispose();
}
```

La nouvelle présentation commence avec le numéro de diapositive 1, ainsi le texte est `Slide 1`, et les deux vérifications affichent `true`. Le numéro reste un champ après la réouverture ; ce n’est pas le littéral `1`. Les conversions et indices dans la vérification font référence à la forme et aux portions créées par cet exemple.

## **Choisir un type de champ**

[FieldType](https://reference.aspose.com/slides/fr/java/com.aspose.slides/fieldtype/) implémente [IFieldType](https://reference.aspose.com/slides/fr/java/com.aspose.slides/ifieldtype/) et fournit les méthodes suivantes pour obtenir des valeurs prédéfinies. Transmettez la valeur appropriée à [addField](https://reference.aspose.com/slides/fr/java/com.aspose.slides/iportion/#addField-com.aspose.slides.IFieldType-).

| Méthode | Description |
|---|---|
| [getSlideNumber](https://reference.aspose.com/slides/fr/java/com.aspose.slides/fieldtype/#getSlideNumber--) | Le numéro de diapositive actuel. |
| [getDateTime](https://reference.aspose.com/slides/fr/java/com.aspose.slides/fieldtype/#getDateTime--) | Date/heure au format par défaut de l’application de rendu. |
| [getDateTime1](https://reference.aspose.com/slides/fr/java/com.aspose.slides/fieldtype/#getDateTime1--)–[getDateTime9](https://reference.aspose.com/slides/fr/java/com.aspose.slides/fieldtype/#getDateTime9--) | Formats de date prédéfinis ou combinaisons date/heure. |
| [getDateTime10](https://reference.aspose.com/slides/fr/java/com.aspose.slides/fieldtype/#getDateTime10--)–[getDateTime13](https://reference.aspose.com/slides/fr/java/com.aspose.slides/fieldtype/#getDateTime13--) | Formats d’heure prédéfinis, avec options pour les secondes et une horloge de 12 heures. |
| [getHeader](https://reference.aspose.com/slides/fr/java/com.aspose.slides/fieldtype/#getHeader--) | Un champ d’en-tête ; voir les limites de l’espace réservé et du format ci-dessous. |
| [getFooter](https://reference.aspose.com/slides/fr/java/com.aspose.slides/fieldtype/#getFooter--) | Un champ de pied de page. |

Par exemple, [getDateTime3](https://reference.aspose.com/slides/fr/java/com.aspose.slides/fieldtype/#getDateTime3--) représente le jour, le nom complet du mois et l’année en anglais. Il s’agit de formats de champ prédéfinis, et non de chaînes de format de date Java arbitraires. La langue définie avec [setLanguageId](https://reference.aspose.com/slides/fr/java/com.aspose.slides/ibaseportionformat/#setLanguageId-java.lang.String-) et l’application qui traite la présentation peuvent influencer le résultat affiché.

## **Créer un champ à partir d’une chaîne interne**

La surcharge chaîne de [addField](https://reference.aspose.com/slides/fr/java/com.aspose.slides/iportion/#addField-java.lang.String-) accepte un identifiant de champ interne. Utilisez‑la pour préserver un identifiant fourni par une autre application qui n’a pas de valeur prédéfinie. Vous pouvez également créer un [FieldType](https://reference.aspose.com/slides/fr/java/com.aspose.slides/fieldtype/#FieldType-java.lang.String-) à partir de cet identifiant. [IFieldType.getInternalString](https://reference.aspose.com/slides/fr/java/com.aspose.slides/ifieldtype/#getInternalString--) expose cet identifiant pour inspection.

Cet exemple stocke un champ `custom-report-id` spécifique à l’application avec le texte de secours `Report-042`. L’identifiant ne déclenche aucun calcul : Aspose.Slides ne génère pas d’identifiants de rapport pour un type inconnu. L’application qui comprend cet identifiant doit fournir sa signification et mettre à jour sa valeur.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    IAutoShape shape = presentation.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 40, 40, 300, 50);
    shape.addTextFrame("Report-042");
    IPortion portion = shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0);
    portion.addField("custom-report-id");

    presentation.save("custom_field.pptx", SaveFormat.Pptx);

    Presentation reopened = new Presentation("custom_field.pptx");
    try {
        IAutoShape savedShape = (IAutoShape) reopened.getSlides().get_Item(0).getShapes().get_Item(0);
        IPortion savedPortion = savedShape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0);
        IField savedField = savedPortion.getField();
        String typeName = savedField == null ? "ordinary text" : savedField.getType().getInternalString();
        System.out.println("Type: " + typeName);
        System.out.println("Text: " + savedPortion.getText());
    } finally {
        reopened.dispose();
    }
} finally {
    presentation.dispose();
}
```

Après ce aller‑retour PPTX, le type est `custom-report-id` et le texte est `Report-042`. Fournir une chaîne telle que `yyyy-MM-dd` nommerait un type de champ ; cela ne configurerait pas un format de date personnalisé. Pour une date fixe dans un format arbitraire, utilisez du texte ordinaire.

## **Inspecter, modifier et supprimer les champs date/heure**

Modifiez un champ existant via [IField.setType](https://reference.aspose.com/slides/fr/java/com.aspose.slides/ifield/#setType-com.aspose.slides.IFieldType-). Vérifiez que le champ existe avant d’accéder à son type. Pour arrêter les mises à jour automatiques, appelez [IPortion.removeField](https://reference.aspose.com/slides/fr/java/com.aspose.slides/iportion/#removeField--). Cela conserve la portion et son texte actuel tout en supprimant l’association du champ. Si vous avez besoin d’une valeur fixe spécifique, assignez ce texte après avoir supprimé le champ.

Pour le paramètre d’API associé au traitement des champs date/heure, voir [Presentation.setCurrentDateTime](https://reference.aspose.com/slides/fr/java/com.aspose.slides/presentation/#setCurrentDateTime-java.util.Date-). L’exemple ci‑dessus utilise une date d’approbation explicite lors de la conversion d’un champ en texte ordinaire.

Téléchargez [sample.pptx](sample.pptx) et placez‑le dans le répertoire de travail. Il contient deux formes de texte nommées, `UpdatedAt` et `ApprovedDate`, chacune avec un champ date/heure, ainsi que des étiquettes de texte ordinaires. L’exemple suivant parcourt les formes de texte de premier niveau sur les diapositives ordinaires. Il convertit les champs date/heure en format de date longue et les met en italique, tout en préservant leur autre mise en forme. Seuls les champs de `ApprovedDate` deviennent du texte fixe.

L’échantillon reconnaît les identifiants internes intégrés `datetime` et `datetime1` à `datetime13`. Les groupes, tableaux, notes, mises en page et maîtres nécessitent le parcours de leurs propres conteneurs de texte et sont hors du périmètre de cet exemple.

```java
import java.time.LocalDate;
import java.time.format.DateTimeFormatter;
import java.util.Locale;
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.pptx");
try {
    LocalDate approvalDate = LocalDate.of(2030, 4, 5);
    DateTimeFormatter dateFormat = DateTimeFormatter.ofPattern("dd MMMM yyyy", Locale.US);

    for (ISlide slide : presentation.getSlides()) {
        for (IShape shape : slide.getShapes()) {
            if (!(shape instanceof IAutoShape)) {
                continue;
            }
            IAutoShape textShape = (IAutoShape) shape;
            if (textShape.getTextFrame() == null) {
                continue;
            }

            for (IParagraph paragraph : textShape.getTextFrame().getParagraphs()) {
                for (IPortion portion : paragraph.getPortions()) {
                    IField field = portion.getField();
                    if (field == null) {
                        continue;
                    }

                    String typeName = field.getType().getInternalString();
                    boolean isDateTime = typeName != null && typeName.matches("datetime([1-9]|1[0-3])?");
                    if (!isDateTime) {
                        continue;
                    }

                    field.setType(FieldType.getDateTime3());
                    portion.getPortionFormat().setLanguageId("en-US");
                    portion.getPortionFormat().setFontItalic(NullableBool.True);

                    if ("ApprovedDate".equals(textShape.getName())) {
                        portion.removeField();
                        String fixedDate = approvalDate.format(dateFormat);
                        portion.setText(fixedDate);
                    }
                }
            }
        }
    }

    presentation.save("updated_dates.pptx", SaveFormat.Pptx);

    Presentation reopened = new Presentation("updated_dates.pptx");
    try {
        for (IShape shape : reopened.getSlides().get_Item(0).getShapes()) {
            if (!(shape instanceof IAutoShape)) {
                continue;
            }
            IAutoShape textShape = (IAutoShape) shape;
            if (textShape.getTextFrame() == null) {
                continue;
            }
            if (!"UpdatedAt".equals(textShape.getName()) && !"ApprovedDate".equals(textShape.getName())) {
                continue;
            }

            IPortion portion = textShape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0);
            IField field = portion.getField();
            String typeName = field == null ? "ordinary text" : field.getType().getInternalString();
            System.out.println(textShape.getName() + ": " + typeName + "; " + portion.getText());
            System.out.println("Italic: " + portion.getPortionFormat().getFontItalic());
        }
    } finally {
        reopened.dispose();
    }
} finally {
    presentation.dispose();
}
```

Après réouverture, `UpdatedAt` a le type `datetime3` et reste dynamique. `ApprovedDate` n’a aucun champ et contient `05 April 2030`. Les deux portions de date sont en italique, et leur taille de police, réglage gras et couleur d’origine restent intacts. Les étiquettes de texte ordinaires sont inchangées. La vérification lit la première portion des deux formes connues dans l’échantillon fourni.

## **Préserver la mise en forme du texte**

Travaillez avec la portion existante lors de l’ajout d’un champ, du changement de son type ou de sa suppression. Ces opérations conservent la mise en forme de cette portion. Utilisez [IPortion.getPortionFormat](https://reference.aspose.com/slides/fr/java/com.aspose.slides/iportion/#getPortionFormat--) pour modifier uniquement les propriétés requises, comme le font les exemples pour la couleur ou l’italique.

Évitez de reconstruire un cadre de texte complet uniquement pour mettre à jour un champ : cela peut perdre les limites originales des portions et leur mise en forme individuelle. Distinguiez également la mise en forme définie explicitement de celle héritée du paragraphe, de la mise en page ou du thème. Consultez [Text Formatting](/slides/fr/java/text-formatting/) pour des options de mise en forme plus étendues.

## **Champs et espaces réservés d’en‑tête/pied de page**

Un champ fait partie d’une portion de texte. Un espace réservé est une forme avec un rôle de présentation, comme un pied de page ou un numéro de diapositive. Ajouter un champ à une zone de texte ordinaire ne transforme pas cette forme en espace réservé.

Les gestionnaires d’en‑tête/pied de page contrôlent le texte et la visibilité des espaces réservés sur les diapositives, les mises en page et les maîtres, y compris la propagation aux diapositives dépendantes. Un champ numérique dans une zone de texte personnalisée peut donc être utile même si vous n’utilisez pas l’espace réservé du numéro de diapositive. Inversement, modifier la visibilité d’un espace réservé ne supprime pas un champ d’une zone de texte non liée.

Les types d’en‑tête et de pied de page prédéfinis ne créent pas les espaces réservés correspondants ni ne fournissent leur contenu. En particulier, une diapositive PowerPoint classique n’a pas d’espace réservé d’en‑tête ; les en‑têtes appartiennent aux pages de notes et aux prospectus. Ne supposez pas qu’un champ d’en‑tête ou de pied de page dans une forme quelconque obtienne automatiquement le texte configuré via un gestionnaire d’espaces réservés. Pour ce flux de travail, consultez [Presentation Headers and Footers](/slides/fr/java/presentation-header-and-footer/).

## **Limitations PPTX et PPT**

Vérifiez à la fois le type de champ et le texte résultant après l’enregistrement et la réouverture. Conserver un identifiant ne prouve pas qu’une application peut calculer ou afficher sa valeur.

| Format | Comportement du champ et limitations |
|---|---|
| PPTX | Stocke les identifiants internes des champs avec le texte du champ. Lors des vérifications aller‑retour, les types prédéfinis et l’identifiant personnalisé utilisé ci‑dessus ont survécu à l’enregistrement et à la réouverture. Le type personnalisé inconnu a conservé son texte de secours ; il n’a pas acquis de logique de calcul automatique. Une autre application peut gérer les identifiants non pris en charge différemment. |
| PPT | Utilise des représentations de champ héritées et a une compatibilité plus limitée. Lors des vérifications aller‑retour, les champs numéro de diapositive et les champs date/heure prédéfinis ont survécu à l’enregistrement et à la réouverture. Un champ personnalisé dans une zone de texte ordinaire d’une diapositive a été réouvert avec son identifiant mais avec `*` comme texte ; un champ d’en‑tête dans le même contexte a également produit `*`. Ne comptez pas sur le fait que les champs personnalisés ou les contextes de champ non pris en charge conservent leur texte visible. |

Pour une sortie portable et fixe, convertissez les champs non pris en charge en texte ordinaire et assignez explicitement la valeur souhaitée avant l’enregistrement. Cela préserve le texte choisi tout en arrêtant intentionnellement les mises à jour automatiques. Testez également l’application cible lorsque son propre recalcul de champ fait partie de votre flux de travail.

## **FAQ**

**Comment savoir si un nombre ou une date affichée est un champ ?**  
Inspectez [IPortion.getField](https://reference.aspose.com/slides/fr/java/com.aspose.slides/iportion/#getField--). Une valeur non nulle identifie un champ ; le texte affiché seul ne peut pas le déterminer.

**La suppression d’un champ supprime‑t‑elle son texte ou sa mise en forme ?**  
Non. [removeField](https://reference.aspose.com/slides/fr/java/com.aspose.slides/iportion/#removeField--) convertit la portion existante en texte ordinaire. Assignez une valeur explicite ensuite si vous avez besoin d’une date figée ou d’une valeur de secours particulière.

**Une chaîne interne peut‑elle définir un nouveau format de date ou une formule ?**  
Non. Elle identifie un type de champ. Un identifiant inconnu ne fournit pas d’évaluateur ni de modèle de format de date Java. Utilisez un type prédéfini supporté ou formatez vous‑même la valeur en texte ordinaire.

**Pourquoi vérifier de nouveau une présentation après l’avoir enregistrée ?**  
Les identifiants de champ, le texte calculé et la mise en forme sont des éléments distincts à vérifier. La conversion de format peut modifier le résultat visible même si l’identifiant du champ est toujours présent.