---
title: Gérer les champs de texte dans les présentations PowerPoint en Python via Java
linktitle: Champs de texte
type: docs
weight: 52
url: /fr/python-java/text-fields/
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
- Python
- Java
- Aspose.Slides
description: "Créer, inspecter, modifier et supprimer les champs de texte dans les présentations PowerPoint avec Aspose.Slides pour Python via Java. Conserver la mise en forme et vérifier les fichiers PPTX et PPT enregistrés."
---
## **Vue d'ensemble**

Un paragraphe de texte se compose de portions. Une [Portion](https://reference.aspose.com/slides/fr/python-java/aspose.slides/portion/) ordinaire contient du texte brut ; une portion de champ possède également un [Field](https://reference.aspose.com/slides/fr/python-java/aspose.slides/field/) dont le type identifie une valeur automatiquement mise à jour, comme le numéro de diapositive ou la date. Deux portions peuvent afficher les mêmes caractères alors qu’une seule contient un champ.

Utilisez [Portion.getField](https://reference.aspose.com/slides/fr/python-java/aspose.slides/portion/#getField) pour les distinguer : il est `None` pour du texte ordinaire. [Portion.addField](https://reference.aspose.com/slides/fr/python-java/aspose.slides/portion/#addField) convertit une portion existante en champ. Conservez une étiquette et sa valeur dynamique dans des portions séparées afin que la conversion de la valeur ne remplace pas également l’étiquette.

Ce guide couvre les champs dans le texte, leur mise en forme et leur enregistrement en PPTX et PPT. Pour les cadres de texte et les paragraphes, voir [Gérer le texte](/slides/fr/python-java/manage-text/).

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, Portion, ShapeType, NullableBool, FillType, FieldType, SaveFormat
from java.awt import Color

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 40, 40, 240, 50)
    shape.addTextFrame("Slide ")
    paragraph = shape.getTextFrame().getParagraphs().get_Item(0)

    number_portion = Portion()
    number_color = Color(0, 0, 139)
    number_portion.getPortionFormat().setFontHeight(24)
    number_portion.getPortionFormat().setFontBold(NullableBool.True_)
    number_portion.getPortionFormat().getFillFormat().setFillType(FillType.Solid)
    number_portion.getPortionFormat().getFillFormat().getSolidFillColor().setColor(number_color)
    paragraph.getPortions().add(number_portion)
    number_portion.addField(FieldType.getSlideNumber())

    presentation.save("slide_number.pptx", SaveFormat.Pptx)

    reopened = Presentation("slide_number.pptx")
    try:
        saved_shape = reopened.getSlides().get_Item(0).getShapes().get_Item(0)
        saved_number = saved_shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(1)
        saved_field = saved_number.getField()
        has_number_field = saved_field is not None and saved_field.getType().getInternalString() == FieldType.getSlideNumber().getInternalString()
        portion_format = saved_number.getPortionFormat()
        formatting_preserved = portion_format.getFontHeight() == 24 and portion_format.getFontBold() == NullableBool.True_
        formatting_preserved = formatting_preserved and portion_format.getFillFormat().getSolidFillColor().getColor().getRGB() == number_color.getRGB()

        print(f"Text: {saved_shape.getTextFrame().getText()}")
        print(f"Slide number field: {has_number_field}")
        print(f"Formatting preserved: {formatting_preserved}")
    finally:
        reopened.dispose()
finally:
    presentation.dispose()
```

## **Créer un champ de numéro de diapositive**

L'exemple complet suivant crée une zone de texte contenant une étiquette littérale `Slide ` suivie d’un numéro mis à jour automatiquement. Il définit la taille, l'épaisseur et la couleur du numéro avant d’ajouter le champ, puis rouvre la présentation enregistrée et vérifie le type de champ, le texte et la mise en forme. Aucun fichier d'entrée n'est requis.

La nouvelle présentation commence avec le numéro de diapositive 1, ainsi le texte est `Slide 1`, et les deux vérifications affichent `True`. Le numéro reste un champ après la réouverture ; ce n’est pas le texte littéral `1`. Les index dans la vérification font référence à la forme et aux portions créées par cet exemple.

## **Choisir un type de champ**

[FieldType](https://reference.aspose.com/slides/fr/python-java/aspose.slides/fieldtype/) fournit les méthodes suivantes pour obtenir des valeurs prédéfinies. Transmettez la valeur appropriée à [addField](https://reference.aspose.com/slides/fr/python-java/aspose.slides/portion/#addField).

| Méthode | Objectif |
|---|---|
| [getSlideNumber](https://reference.aspose.com/slides/fr/python-java/aspose.slides/fieldtype/#getSlideNumber) | Le numéro de diapositive actuel. |
| [getDateTime](https://reference.aspose.com/slides/fr/python-java/aspose.slides/fieldtype/#getDateTime) | Date/heure dans le format par défaut de l'application de rendu. |
| [getDateTime1](https://reference.aspose.com/slides/fr/python-java/aspose.slides/fieldtype/#getDateTime1)–[getDateTime9](https://reference.aspose.com/slides/fr/python-java/aspose.slides/fieldtype/#getDateTime9) | Formats de date prédéfinis ou combinaisons date/heure. |
| [getDateTime10](https://reference.aspose.com/slides/fr/python-java/aspose.slides/fieldtype/#getDateTime10)–[getDateTime13](https://reference.aspose.com/slides/fr/python-java/aspose.slides/fieldtype/#getDateTime13) | Formats d'heure prédéfinis, avec options pour les secondes et une horloge 12 heures. |
| [getHeader](https://reference.aspose.com/slides/fr/python-java/aspose.slides/fieldtype/#getHeader) | Un champ d'en-tête ; voir les limites de l'espace réservé et du format ci-dessous. |
| [getFooter](https://reference.aspose.com/slides/fr/python-java/aspose.slides/fieldtype/#getFooter) | Un champ de pied de page. |

Par exemple, [getDateTime3](https://reference.aspose.com/slides/fr/python-java/aspose.slides/fieldtype/#getDateTime3) représente le jour, le nom complet du mois et l'année en anglais. Il s'agit de formats de champ prédéfinis, et non de chaînes de formatage de date Python arbitraires. La langue définie avec [setLanguageId](https://reference.aspose.com/slides/fr/python-java/aspose.slides/baseportionformat/#setLanguageId) et l'application qui traite la présentation peuvent influencer le résultat affiché.

## **Créer un champ à partir d'une chaîne interne**

La surcharge chaîne de [addField](https://reference.aspose.com/slides/fr/python-java/aspose.slides/portion/#addField) accepte un identifiant de champ interne. Utilisez‑la pour conserver un identifiant fourni par une autre application qui n’a pas de valeur prédéfinie. Vous pouvez également créer un [FieldType](https://reference.aspose.com/slides/fr/python-java/aspose.slides/fieldtype/#FieldType) à partir de l’identifiant. [FieldType.getInternalString](https://reference.aspose.com/slides/fr/python-java/aspose.slides/fieldtype/#getInternalString) expose cet identifiant pour inspection.

Cet exemple stocke un champ spécifique à l'application `custom-report-id` avec le texte de secours `Report-042`. L'identifiant n'enregistre aucune calcul : Aspose.Slides ne génère pas d'ID de rapport pour un type inconnu. L'application qui comprend cet identifiant doit fournir sa signification et mettre à jour sa valeur.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ShapeType, SaveFormat

presentation = Presentation()
try:
    shape = presentation.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 40, 40, 300, 50)
    shape.addTextFrame("Report-042")
    portion = shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0)
    portion.addField("custom-report-id")

    presentation.save("custom_field.pptx", SaveFormat.Pptx)

    reopened = Presentation("custom_field.pptx")
    try:
        saved_shape = reopened.getSlides().get_Item(0).getShapes().get_Item(0)
        saved_portion = saved_shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0)
        saved_field = saved_portion.getField()
        type_name = "ordinary text" if saved_field is None else saved_field.getType().getInternalString()
        print(f"Type: {type_name}")
        print(f"Text: {saved_portion.getText()}")
    finally:
        reopened.dispose()
finally:
    presentation.dispose()
```

Après ce cycle PPTX, le type est `custom-report-id` et le texte est `Report-042`. Fournir une chaîne telle que `yyyy-MM-dd` nommerait un type de champ ; cela ne configurerait pas un format de date personnalisé. Pour une date fixe dans un format arbitraire, utilisez du texte ordinaire.

## **Inspecter, modifier et supprimer les champs date/heure**

Modifiez un champ existant via [Field.setType](https://reference.aspose.com/slides/fr/python-java/aspose.slides/field/#setType). Vérifiez que le champ existe avant d’accéder à son type. Pour arrêter les mises à jour automatiques, appelez [Portion.removeField](https://reference.aspose.com/slides/fr/python-java/aspose.slides/portion/#removeField). Cela conserve la portion et son texte actuel tout en supprimant l’association du champ. Si vous avez besoin d’une valeur fixe spécifique, attribuez ce texte après la suppression du champ.

Pour le paramètre d’API associé au traitement des champs date/heure, voir [Presentation.setCurrentDateTime](https://reference.aspose.com/slides/fr/python-java/aspose.slides/presentation/#setCurrentDateTime). L’exemple ci‑dessous utilise une date d’approbation explicite lors de la conversion d’un champ en texte ordinaire.

Téléchargez [sample.pptx](sample.pptx) et placez‑le dans le répertoire de travail. Il contient deux formes de texte nommées, `UpdatedAt` et `ApprovedDate`, chacune avec un champ date/heure, ainsi que des étiquettes de texte ordinaire. L’exemple suivant parcourt les formes de texte de niveau supérieur sur les diapositives classiques. Il convertit les champs date/heure en format date longue et les met en italique, tout en préservant leurs autres mises en forme. Seuls les champs dans `ApprovedDate` deviennent du texte figé.

L’échantillon reconnaît les identifiants internes intégrés `datetime` et `datetime1` à `datetime13`. Les groupes, tableaux, notes, dispositions et maîtres nécessitent la traversée de leurs propres conteneurs de texte et sont hors du champ d’application de cet exemple.

```python
import re
from datetime import date

import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, AutoShape, FieldType, NullableBool, SaveFormat

presentation = Presentation("sample.pptx")
try:
    approval_date = date(2030, 4, 5)
    # Utilisez les noms de mois anglais indépendamment des paramètres régionaux du système.
    month_names = ("January", "February", "March", "April", "May", "June", "July", "August", "September", "October", "November", "December")
    fixed_date = f"{approval_date.day:02d} {month_names[approval_date.month - 1]} {approval_date.year}"

    for slide in presentation.getSlides():
        for shape in slide.getShapes():
            if not isinstance(shape, AutoShape):
                continue
            if shape.getTextFrame() is None:
                continue

            for paragraph in shape.getTextFrame().getParagraphs():
                for portion in paragraph.getPortions():
                    field = portion.getField()
                    if field is None:
                        continue

                    type_name = field.getType().getInternalString()
                    is_date_time = type_name is not None and re.fullmatch(r"datetime([1-9]|1[0-3])?", str(type_name)) is not None
                    if not is_date_time:
                        continue

                    field.setType(FieldType.getDateTime3())
                    portion.getPortionFormat().setLanguageId("en-US")
                    portion.getPortionFormat().setFontItalic(NullableBool.True_)

                    if shape.getName() == "ApprovedDate":
                        portion.removeField()
                        portion.setText(fixed_date)

    presentation.save("updated_dates.pptx", SaveFormat.Pptx)

    reopened = Presentation("updated_dates.pptx")
    try:
        for shape in reopened.getSlides().get_Item(0).getShapes():
            if not isinstance(shape, AutoShape):
                continue
            if shape.getTextFrame() is None:
                continue
            if shape.getName() not in ("UpdatedAt", "ApprovedDate"):
                continue

            portion = shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0)
            field = portion.getField()
            type_name = "ordinary text" if field is None else field.getType().getInternalString()
            print(f"{shape.getName()}: {type_name}; {portion.getText()}")
            print(f"Italic: {portion.getPortionFormat().getFontItalic()}")
    finally:
        reopened.dispose()
finally:
    presentation.dispose()
```

Après la réouverture, `UpdatedAt` a le type `datetime3` et reste dynamique. `ApprovedDate` n’a aucun champ et contient `05 April 2030`. Les deux portions de date sont en italique, et leur taille de police, réglage gras et couleur d’origine restent intacts. Les étiquettes de texte ordinaire sont inchangées. La vérification lit la première portion des deux formes connues dans l’échantillon fourni.

## **Conserver la mise en forme du texte**

Travaillez avec la portion existante lors de l’ajout d’un champ, du changement de son type ou de sa suppression. Ces opérations conservent la mise en forme de cette portion. Utilisez [Portion.getPortionFormat](https://reference.aspose.com/slides/fr/python-java/aspose.slides/portion/#getPortionFormat) pour modifier uniquement les propriétés requises, comme le montrent les exemples pour la couleur ou l’italique.

Évitez de reconstruire tout un cadre de texte simplement pour mettre à jour un champ : cela peut perdre les limites originales des portions et leur mise en forme individuelle. Distinguisez également la mise en forme définie explicitement de celle héritée du paragraphe, de la disposition ou du thème. Consultez [Formatage du texte](/slides/fr/python-java/text-formatting/) pour des options de mise en forme plus larges.

## **Champs et espaces réservés d’en-tête/pied de page**

Un champ fait partie d’une portion de texte. Un espace réservé est une forme avec un rôle de présentation, comme un pied de page ou un numéro de diapositive. Ajouter un champ à une zone de texte ordinaire ne transforme pas cette forme en espace réservé.

Les gestionnaires d’en‑tête/pied de page contrôlent le texte des espaces réservés et leur visibilité sur les diapositives, les dispositions et les maîtres, y compris la propagation aux diapositives dépendantes. Un champ numéro dans une zone de texte personnalisée peut donc être utile même si vous n’utilisez pas l’espace réservé du numéro de diapositive. Inversement, modifier la visibilité d’un espace réservé ne supprime pas un champ d’une zone de texte non liée.

Les types d’en‑tête et de pied de page prédéfinis ne créent pas les espaces réservés correspondants ni ne fournissent leur contenu. En particulier, une diapositive PowerPoint standard n’a pas d’espace réservé d’en‑tête ; les en‑têtes appartiennent aux pages de notes et aux prospectus. Ne supposez pas qu’un champ d’en‑tête ou de pied de page dans une forme quelconque obtienne automatiquement le texte configuré via un gestionnaire d’espace réservé. Pour ce flux de travail, voir [Presentation Headers and Footers](/slides/fr/python-java/presentation-header-and-footert/).

## **Limitations PPTX et PPT**

Vérifiez à la fois le type de champ et le texte résultant après l’enregistrement et la réouverture. Conserver un identifiant ne prouve pas qu’une application peut calculer ou afficher sa valeur.

| Format | Comportement du champ et limitations |
|---|---|
| PPTX | Stocke les identifiants de champ internes avec le texte du champ. Dans les vérifications de cycle complet, les types prédéfinis et l’identifiant personnalisé utilisé ci‑dessus ont survécu à l’enregistrement et à la réouverture. Le type personnalisé inconnu a conservé son texte de secours ; il n’a pas acquis de logique de calcul automatique. Une autre application peut traiter les identifiants non pris en charge différemment. |
| PPT | Utilise des représentations de champ héritées et possède une compatibilité plus limitée. Dans les vérifications de cycle complet, les champs numéro de diapositive et les champs date/heure prédéfinis ont survécu à l’enregistrement et à la réouverture. Un champ personnalisé dans une zone de texte de diapositive ordinaire a été réouvert avec son identifiant mais avec `*` comme texte ; un champ d’en‑tête dans le même contexte a également produit `*`. Ne comptez pas sur le fait que les champs personnalisés ou les contextes de champ non pris en charge conservent leur texte visible. |

Pour une sortie portable et fixe, convertissez les champs non pris en charge en texte ordinaire et attribuez explicitement la valeur souhaitée avant l’enregistrement. Cela conserve le texte choisi mais arrête intentionnellement les mises à jour automatiques. Testez également l’application cible lorsque son propre recalcul de champ fait partie de votre flux de travail.

## **FAQ**

**Comment savoir si un nombre ou une date affiché(e) est un champ ?**  
Inspectez [Portion.getField](https://reference.aspose.com/slides/fr/python-java/aspose.slides/portion/#getField). Une valeur différente de `None` identifie un champ ; le texte affiché seul ne peut pas le déterminer.

**La suppression d’un champ supprime‑t‑elle son texte ou sa mise en forme ?**  
Non. [removeField](https://reference.aspose.com/slides/fr/python-java/aspose.slides/portion/#removeField) convertit la portion existante en texte ordinaire. Attribuez une valeur explicite après la suppression si vous avez besoin d’une date figée ou d’une valeur de secours particulière.

**Une chaîne interne peut‑elle définir un nouveau format de date ou une formule ?**  
Non. Elle identifie un type de champ. Un identifiant inconnu ne fournit pas d’évaluateur ni de modèle de format de date Python. Utilisez un type prédéfini supporté ou formatez vous‑même la valeur en texte ordinaire.

**Pourquoi vérifier à nouveau une présentation après l’avoir enregistrée ?**  
Les identifiants de champ, le texte calculé et la mise en forme sont des éléments distincts à vérifier. La conversion de format peut modifier le résultat visible même si l’identifiant du champ est toujours présent.