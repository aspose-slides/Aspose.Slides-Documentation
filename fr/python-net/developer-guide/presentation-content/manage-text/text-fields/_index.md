---
title: Gérer les champs de texte dans les présentations PowerPoint en Python
linktitle: Champs de texte
type: docs
weight: 52
url: /fr/python-net/text-fields/
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
- Aspose.Slides
description: "Créer, inspecter, modifier et supprimer les champs de texte dans les présentations PowerPoint avec Aspose.Slides pour Python via .NET. Conserver le formatage et vérifier les fichiers PPTX et PPT enregistrés."
---
## **Vue d'ensemble**

Un paragraphe de texte se compose de portions. Une [Portion](https://reference.aspose.com/slides/fr/python-net/aspose.slides/portion/) ordinaire contient du texte littéral ; une portion de [Champ](https://reference.aspose.com/slides/fr/python-net/aspose.slides/field/) possède également un [Champ](https://reference.aspose.com/slides/fr/python-net/aspose.slides/field/) dont le type identifie une valeur mise à jour automatiquement, comme un numéro de diapositive ou une date. Deux portions peuvent afficher les mêmes caractères alors qu'une seule contient un champ.

Utilisez [Portion.field](https://reference.aspose.com/slides/fr/python-net/aspose.slides/portion/field/) pour les distinguer : il vaut `None` pour du texte ordinaire. [Portion.add_field](https://reference.aspose.com/slides/fr/python-net/aspose.slides/portion/add_field/) convertit une portion existante en champ. Conservez une étiquette et sa valeur dynamique dans des portions séparées afin que la conversion de la valeur ne remplace pas également l'étiquette.

Ce guide couvre les champs dans le texte, leur formatage, et leur enregistrement au format PPTX et PPT. Pour les cadres de texte et les paragraphes, voir [Gestion du texte](/slides/fr/python-net/manage-text/).

## **Créer un champ de numéro de diapositive**

L'exemple complet suivant crée une zone de texte contenant une étiquette littérale `Slide ` suivie d'un numéro mis à jour automatiquement. Il définit la taille, l'épaisseur et la couleur du numéro avant d'ajouter le champ, puis rouvre la présentation enregistrée et vérifie le type du champ, le texte et le formatage. Aucun fichier d'entrée n'est requis.

```python
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 40, 40, 240, 50)
    shape.add_text_frame("Slide ")
    paragraph = shape.text_frame.paragraphs[0]

    number_portion = slides.Portion()
    number_portion.portion_format.font_height = 24
    number_portion.portion_format.font_bold = slides.NullableBoolTRUE
    number_portion.portion_format.fill_format.fill_type = slides.FillType.SOLID
    number_portion.portion_format.fill_format.solid_fill_color.color = draw.Color.dark_blue
    paragraph.portions.add(number_portion)
    number_portion.add_field(slides.FieldType.slide_number)

    presentation.save("slide_number.pptx", slides.export.SaveFormat.PPTX)

with slides.Presentation("slide_number.pptx") as reopened:
    saved_shape = reopened.slides[0].shapes[0]
    saved_number = saved_shape.text_frame.paragraphs[0].portions[1]
    has_number_field = saved_number.field is not None and saved_number.field.type.internal_string == slides.FieldType.slide_number.internal_string
    portion_format = saved_number.portion_format
    formatting_preserved = portion_format.font_height == 24 and portion_format.font_bold == slides.NullableBoolTRUE
    formatting_preserved &= portion_format.fill_format.solid_fill_color.color.to_argb() == draw.Color.dark_blue.to_argb()

    print(f"Text: {saved_shape.text_frame.text}")
    print(f"Slide number field: {has_number_field}")
    print(f"Formatting preserved: {formatting_preserved}")
```

La nouvelle présentation commence avec le numéro de diapositive 1, donc le texte est `Slide 1`, et les deux vérifications affichent `True`. Le numéro reste un champ après la réouverture ; ce n'est pas le littéral `1`. Les indices dans la vérification se réfèrent à la forme et aux portions créées par cet exemple.

## **Choisir un type de champ**

[FieldType](https://reference.aspose.com/slides/fr/python-net/aspose.slides/fieldtype/) fournit les valeurs prédéfinies suivantes. Transmettez la valeur appropriée à [add_field](https://reference.aspose.com/slides/fr/python-net/aspose.slides/portion/add_field/).

| Valeur | Objectif |
|---|---|
| [slide_number](https://reference.aspose.com/slides/fr/python-net/aspose.slides/fieldtype/slide_number/) | Le numéro de diapositive actuel. |
| [date_time](https://reference.aspose.com/slides/fr/python-net/aspose.slides/fieldtype/date_time/) | Date/heure au format par défaut de l'application de rendu. |
| [date_time1](https://reference.aspose.com/slides/fr/python-net/aspose.slides/fieldtype/date_time1/)–[date_time9](https://reference.aspose.com/slides/fr/python-net/aspose.slides/fieldtype/date_time9/) | Formats de date ou combinaisons date/heure prédéfinis. |
| [date_time10](https://reference.aspose.com/slides/fr/python-net/aspose.slides/fieldtype/date_time10/)–[date_time13](https://reference.aspose.com/slides/fr/python-net/aspose.slides/fieldtype/date_time13/) | Formats d'heure prédéfinis, avec options pour les secondes et une horloge 12 heures. |
| [header](https://reference.aspose.com/slides/fr/python-net/aspose.slides/fieldtype/header/) | Un champ d'en-tête ; voir les limites de l'espace réservé et du format ci‑dessous. |
| [footer](https://reference.aspose.com/slides/fr/python-net/aspose.slides/fieldtype/footer/) | Un champ de pied de page. |

Par exemple, [date_time3](https://reference.aspose.com/slides/fr/python-net/aspose.slides/fieldtype/date_time3/) représente un jour, le nom complet du mois et l'année en anglais. Ce sont des formats de champ prédéfinis, pas des chaînes de format de date Python arbitraires. L'[language_id](https://reference.aspose.com/slides/fr/python-net/aspose.slides/baseportionformat/language_id/) de la portion et l'application qui traite la présentation peuvent influencer le résultat affiché.

## **Créer un champ à partir d'une chaîne interne**

La surcharge de chaîne de [add_field](https://reference.aspose.com/slides/fr/python-net/aspose.slides/portion/add_field/) accepte un identifiant de champ interne. Utilisez‑le lorsqu'il faut préserver un identifiant fourni par une autre application qui n'a pas de valeur prédéfinie. Vous pouvez également créer un [FieldType](https://reference.aspose.com/slides/fr/python-net/aspose.slides/fieldtype/__init__) à partir de cet identifiant. [FieldType.internal_string](https://reference.aspose.com/slides/fr/python-net/aspose.slides/fieldtype/internal_string/) expose cet identifiant pour inspection.

Cet exemple stocke un champ spécifique à l'application `custom-report-id` avec le texte de secours `Report-042`. L'identifiant n'enregistre aucune calcul : Aspose.Slides ne génère pas d'ID de rapport pour un type inconnu. L'application qui comprend cet identifiant doit fournir sa signification et mettre à jour sa valeur.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    shape = presentation.slides[0].shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 40, 40, 300, 50)
    shape.add_text_frame("Report-042")
    portion = shape.text_frame.paragraphs[0].portions[0]
    portion.add_field("custom-report-id")

    presentation.save("custom_field.pptx", slides.export.SaveFormat.PPTX)

with slides.Presentation("custom_field.pptx") as reopened:
    saved_shape = reopened.slides[0].shapes[0]
    saved_portion = saved_shape.text_frame.paragraphs[0].portions[0]
    type_name = saved_portion.field.type.internal_string if saved_portion.field is not None else "ordinary text"
    print(f"Type: {type_name}")
    print(f"Text: {saved_portion.text}")
```

Après ce aller‑retour PPTX, le type est `custom-report-id` et le texte est `Report-042`. Passer une chaîne comme `%Y-%m-%d` nommerait un type de champ ; cela ne configurerait pas un format de date personnalisé. Pour une date fixe dans un format arbitraire, utilisez du texte ordinaire.

## **Inspecter, modifier et supprimer les champs Date/Heure**

Lisez et modifiez un champ existant via [Field.type](https://reference.aspose.com/slides/fr/python-net/aspose.slides/field/type/). Vérifiez que le champ existe avant d'accéder à son type. Pour arrêter les mises à jour automatiques, appelez [Portion.remove_field](https://reference.aspose.com/slides/fr/python-net/aspose.slides/portion/remove_field/). Cela conserve la portion et son texte actuel tout en supprimant l'association du champ. Si vous avez besoin d'une valeur fixe précise, assignez ce texte après avoir supprimé le champ.

Pour le réglage d'API lié au traitement des champs date/heure, voir [Presentation.current_date_time](https://reference.aspose.com/slides/fr/python-net/aspose.slides/presentation/current_date_time/). L'exemple ci‑dessous utilise une date d'approbation explicite lors de la conversion d'un champ en texte ordinaire. Un tuple de noms de mois anglais maintient la date fixe indépendante du paramètre régional du système.

Téléchargez [sample.pptx](sample.pptx) et placez‑le dans le répertoire de travail. Il contient deux formes de texte nommées, `UpdatedAt` et `ApprovedDate`, chacune avec un champ date/heure, ainsi que des étiquettes de texte ordinaires. L'exemple suivant parcourt les formes de texte de niveau supérieur sur les diapositives normales. Il convertit les champs date/heure en un format date longue et les met en italique, tout en préservant leur autre formatage. Seuls les champs dans `ApprovedDate` deviennent du texte fixe.

L'échantillon reconnaît les identifiants internes intégrés `datetime` et `datetime1` à `datetime13`. Les groupes, tableaux, notes, dispositions et maîtres nécessitent le parcours de leurs propres conteneurs de texte et sont hors du champ de cet exemple.

```python
from datetime import date

import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    approval_date = date(2030, 4, 5)
    english_months = ("January", "February", "March", "April", "May", "June", "July", "August", "September", "October", "November", "December")
    approval_text = f"{approval_date.day:02d} {english_months[approval_date.month - 1]} {approval_date.year}"
    date_time_types = {"datetime"} | {f"datetime{index}" for index in range(1, 14)}

    for slide in presentation.slides:
        for shape in slide.shapes:
            if not isinstance(shape, slides.AutoShape) or shape.text_frame is None:
                continue

            for paragraph in shape.text_frame.paragraphs:
                for portion in paragraph.portions:
                    field = portion.field
                    if field is None:
                        continue

                    if field.type.internal_string not in date_time_types:
                        continue

                    field.type = slides.FieldType.date_time3
                    portion.portion_format.language_id = "en-US"
                    portion.portion_format.font_italic = slides.NullableBool.TRUE

                    if shape.name == "ApprovedDate":
                        portion.remove_field()
                        portion.text = approval_text

    presentation.save("updated_dates.pptx", slides.export.SaveFormat.PPTX)

with slides.Presentation("updated_dates.pptx") as reopened:
    for shape in reopened.slides[0].shapes:
        if not isinstance(shape, slides.AutoShape) or shape.text_frame is None:
            continue
        if shape.name not in {"UpdatedAt", "ApprovedDate"}:
            continue

        portion = shape.text_frame.paragraphs[0].portions[0]
        type_name = portion.field.type.internal_string if portion.field is not None else "ordinary text"
        print(f"{shape.name}: {type_name}; {portion.text}")
        print(f"Italic: {portion.portion_format.font_italic == slides.NullableBool.TRUE}")
```

Après la réouverture, `UpdatedAt` a le type `datetime3` et reste dynamique. `ApprovedDate` n'a pas de champ et contient `05 April 2030`. Les deux portions de date sont en italique, et leur taille de police, réglage gras et couleur d'origine restent intacts. Les étiquettes de texte ordinaire sont inchangées. La vérification lit la première portion des deux formes connues dans l'échantillon fourni.

## **Préserver le formatage du texte**

Travaillez avec la portion existante lors de l'ajout d'un champ, du changement de son type ou de sa suppression. Ces opérations conservent le formatage de cette portion. Utilisez [Portion.portion_format](https://reference.aspose.com/slides/fr/python-net/aspose.slides/portion/portion_format/) pour ne modifier que les propriétés requises, comme le font les exemples pour la couleur ou l'italique.

Évitez de reconstruire tout un cadre de texte simplement pour mettre à jour un champ : cela peut perdre les limites originales des portions et leur formatage individuel. Distinguiez également le formatage explicitement défini du formatage hérité du paragraphe, de la disposition ou du thème. Consultez [Text Formatting](/slides/fr/python-net/text-formatting/) pour des options de formatage plus larges.

## **Champs et espaces réservés d'en-tête/pied de page**

Un champ fait partie d'une portion de texte. Un espace réservé est une forme avec un rôle de présentation, comme un pied de page ou un numéro de diapositive. Ajouter un champ à une zone de texte ordinaire ne transforme pas cette forme en espace réservé.

Les gestionnaires d'en‑tête/pied de page contrôlent le texte des espaces réservés et leur visibilité sur les diapositives, les dispositions et les maîtres, y compris la propagation aux diapositives dépendantes. Un champ de numéro dans une zone de texte personnalisée peut donc être utile même si vous n'utilisez pas l'espace réservé du numéro de diapositive. Inversement, modifier la visibilité d'un espace réservé ne supprime pas un champ d'une zone de texte non liée.

Les types d'en‑tête et de pied de page prédéfinis ne créent pas les espaces réservés correspondants ni ne fournissent leur contenu. En particulier, une diapositive PowerPoint ordinaire n'a pas d'espace réservé d'en‑tête ; les en‑têtes appartiennent aux pages de notes et aux prospectus. Ne supposez pas qu'un champ d'en‑tête ou de pied de page dans une forme arbitraire obtienne automatiquement le texte configuré via un gestionnaire d'espace réservé. Pour ce flux de travail, voir [Presentation Headers and Footers](/slides/fr/python-net/presentation-header-and-footer/).

## **Limitations PPTX et PPT**

Vérifiez à la fois le type de champ et le texte résultant après l'enregistrement et la réouverture. Préserver un identifiant ne prouve pas qu'une application peut calculer ou afficher sa valeur.

| Format | Comportement du champ et limitations |
|---|---|
| PPTX | Stocke les identifiants internes de champ avec le texte du champ. Dans les vérifications d'aller‑retour, les types prédéfinis et l'identifiant personnalisé utilisé ci‑dessus ont survécu à l'enregistrement et à la réouverture. Le type personnalisé inconnu a conservé son texte de secours ; il n'a pas acquis de logique de calcul automatique. Une autre application peut traiter les identifiants non pris en charge différemment. |
| PPT | Utilise des représentations de champ héritées et possède une compatibilité plus limitée. Dans les vérifications d'aller‑retour, les champs numéro de diapositive et les champs date/heure prédéfinis ont survécu à l'enregistrement et à la réouverture. Un champ personnalisé dans une zone de texte de diapositive ordinaire s'est rouvert avec son identifiant mais avec `*` comme texte ; un champ d'en‑tête dans le même contexte a également produit `*`. Ne comptez pas sur les champs personnalisés ou les contextes de champ non pris en charge pour conserver leur texte visible. |

Pour une sortie portable et fixe, convertissez les champs non pris en charge en texte ordinaire et assignez explicitement la valeur souhaitée avant l'enregistrement. Cela préserve le texte choisi mais arrête intentionnellement les mises à jour automatiques. Testez également l'application cible lorsque son propre recalcul de champ fait partie de votre flux de travail.

## **FAQ**

**Comment savoir si un numéro ou une date affiché(e) est un champ ?**  
Inspectez [Portion.field](https://reference.aspose.com/slides/fr/python-net/aspose.slides/portion/field/). Une valeur différente de `None` identifie un champ ; le texte affiché seul ne peut pas le révéler.

**Supprimer un champ supprime‑t‑il son texte ou son formatage ?**  
Non. [remove_field](https://reference.aspose.com/slides/fr/python-net/aspose.slides/portion/remove_field/) convertit la portion existante en texte ordinaire. Assignez une valeur explicite après si vous avez besoin d'une date figée particulière ou d'une valeur de secours.

**Une chaîne interne peut‑elle définir un nouveau format de date ou une formule ?**  
Non. Elle identifie un type de champ. Un identifiant inconnu ne fournit pas d'évaluateur ni de modèle de format de date Python. Utilisez un type prédéfini pris en charge ou formatez vous‑même la valeur en texte ordinaire.

**Pourquoi vérifier à nouveau une présentation après l'avoir enregistrée ?**  
Les identifiants de champ, le texte calculé et le formatage sont des éléments distincts à vérifier. La conversion de format peut modifier le résultat visible même si l'identifiant de champ est toujours présent.