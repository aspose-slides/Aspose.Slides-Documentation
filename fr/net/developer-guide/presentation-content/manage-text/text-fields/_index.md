---
title: Gérer les champs de texte dans les présentations PowerPoint en .NET
linktitle: Champs de texte
type: docs
weight: 52
url: /fr/net/text-fields/
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
- C#
- Aspose.Slides
description: "Créer, inspecter, modifier et supprimer des champs de texte dans les présentations PowerPoint avec Aspose.Slides pour .NET. Conserver la mise en forme et vérifier les fichiers PPTX et PPT enregistrés."
---
## **Vue d'ensemble**

Un paragraphe de texte est composé de portions. Une [IPortion](https://reference.aspose.com/slides/fr/net/aspose.slides/iportion/) ordinaire contient du texte littéral ; une portion de champ possède également un [IField](https://reference.aspose.com/slides/fr/net/aspose.slides/ifield/) dont le type identifie une valeur mise à jour automatiquement, comme le numéro de diapositive ou la date. Deux portions peuvent afficher les mêmes caractères alors qu’une seule contient un champ.

Utilisez [IPortion.Field](https://reference.aspose.com/slides/fr/net/aspose.slides/iportion/field/) pour les distinguer : il est `null` pour le texte ordinaire. [IPortion.AddField](https://reference.aspose.com/slides/fr/net/aspose.slides/iportion/addfield/) convertit une portion existante en champ. Conservez une étiquette et sa valeur dynamique dans des portions distinctes afin que la conversion de la valeur ne remplace pas l’étiquette.

Ce guide couvre les champs dans le texte, leur mise en forme, et leur enregistrement en PPTX et PPT. Pour les cadres de texte et les paragraphes, consultez [Manage Text](/slides/fr/net/manage-text/).

## **Créer un champ de numéro de diapositive**

L’exemple complet suivant crée une zone de texte contenant une étiquette littérale `Slide ` suivie d’un numéro mis à jour automatiquement. Il définit la taille, le poids et la couleur du numéro avant d’ajouter le champ, puis rouvre la présentation enregistrée et vérifie le type, le texte et la mise en forme du champ. Aucun fichier d’entrée n’est requis.

```cs
using System;
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];
var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 40, 40, 240, 50);
shape.AddTextFrame("Slide ");
var paragraph = shape.TextFrame.Paragraphs[0];

var numberPortion = new Portion();
numberPortion.PortionFormat.FontHeight = 24;
numberPortion.PortionFormat.FontBold = NullableBool.True;
numberPortion.PortionFormat.FillFormat.FillType = FillType.Solid;
numberPortion.PortionFormat.FillFormat.SolidFillColor.Color = Color.DarkBlue;
paragraph.Portions.Add(numberPortion);
numberPortion.AddField(FieldType.SlideNumber);

presentation.Save("slide_number.pptx", SaveFormat.Pptx);

using var reopened = new Presentation("slide_number.pptx");
var savedShape = (IAutoShape)reopened.Slides[0].Shapes[0];
var savedNumber = savedShape.TextFrame.Paragraphs[0].Portions[1];
var hasNumberField = savedNumber.Field?.Type.InternalString == FieldType.SlideNumber.InternalString;
var format = savedNumber.PortionFormat;
var formattingPreserved = format.FontHeight == 24 && format.FontBold == NullableBool.True;
formattingPreserved &= format.FillFormat.SolidFillColor.Color.ToArgb() == Color.DarkBlue.ToArgb();

Console.WriteLine($"Text: {savedShape.TextFrame.Text}");
Console.WriteLine($"Slide number field: {hasNumberField}");
Console.WriteLine($"Formatting preserved: {formattingPreserved}");
```

La nouvelle présentation démarre avec le numéro de diapositive 1, ainsi le texte est `Slide 1`, et les deux vérifications affichent `True`. Le numéro reste un champ après la réouverture ; ce n’est pas le littéral `1`. Les conversions et indices dans la vérification font référence à la forme et aux portions créées par cet exemple.

## **Choisir un type de champ**

[FieldType](https://reference.aspose.com/slides/fr/net/aspose.slides/fieldtype/) implémente [IFieldType](https://reference.aspose.com/slides/fr/net/aspose.slides/ifieldtype/) et fournit les valeurs prédéfinies suivantes. Passez la valeur appropriée à [AddField](https://reference.aspose.com/slides/fr/net/aspose.slides/iportion/addfield/).

| Valeur | Objectif |
|---|---|
| [SlideNumber](https://reference.aspose.com/slides/fr/net/aspose.slides/fieldtype/slidenumber/) | Le numéro de diapositive actuel. |
| [DateTime](https://reference.aspose.com/slides/fr/net/aspose.slides/fieldtype/datetime/) | Date/heure au format par défaut de l’application de rendu. |
| [DateTime1](https://reference.aspose.com/slides/fr/net/aspose.slides/fieldtype/datetime1/)–[DateTime9](https://reference.aspose.com/slides/fr/net/aspose.slides/fieldtype/datetime9/) | Formats de date prédéfinis ou formats combinés date/heure. |
| [DateTime10](https://reference.aspose.com/slides/fr/net/aspose.slides/fieldtype/datetime10/)–[DateTime13](https://reference.aspose.com/slides/fr/net/aspose.slides/fieldtype/datetime13/) | Formats d’heure prédéfinis, avec options pour les secondes et une horloge 12 h. |
| [Header](https://reference.aspose.com/slides/fr/net/aspose.slides/fieldtype/header/) | Un champ d’en-tête ; voir les limites de l’espace réservé et du format ci‑dessous. |
| [Footer](https://reference.aspose.com/slides/fr/net/aspose.slides/fieldtype/footer/) | Un champ de pied de page. |

Par exemple, [DateTime3](https://reference.aspose.com/slides/fr/net/aspose.slides/fieldtype/datetime3/) représente le jour, le nom complet du mois et l’année en anglais. Il s’agit de formats de champ prédéfinis, pas de chaînes de format .NET arbitraires. L’[LanguageId](https://reference.aspose.com/slides/fr/net/aspose.slides/ibaseportionformat/languageid/) de la portion et l’application qui traite la présentation peuvent influencer le résultat affiché.

## **Créer un champ à partir d’une chaîne interne**

La surcharge de chaîne de [AddField](https://reference.aspose.com/slides/fr/net/aspose.slides/iportion/addfield/) accepte un identifiant de champ interne. Utilisez‑la lorsque vous devez préserver un identifiant fourni par une autre application qui n’a aucune valeur prédéfinie. Vous pouvez également créer un [FieldType](https://reference.aspose.com/slides/fr/net/aspose.slides/fieldtype/fieldtype/) à partir de cet identifiant. [IFieldType.InternalString](https://reference.aspose.com/slides/fr/net/aspose.slides/ifieldtype/internalstring/) expose cet identifiant pour inspection.

Cet exemple stocke un champ `custom-report-id` spécifique à l’application avec le texte de secours `Report-042`. L’identifiant n’entraîne aucun calcul : Aspose.Slides ne génère pas d’ID de rapport pour un type inconnu. L’application qui comprend cet identifiant doit en fournir la signification et mettre à jour sa valeur.

```cs
using System;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var shape = presentation.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle, 40, 40, 300, 50);
shape.AddTextFrame("Report-042");
var portion = shape.TextFrame.Paragraphs[0].Portions[0];
portion.AddField("custom-report-id");

presentation.Save("custom_field.pptx", SaveFormat.Pptx);

using var reopened = new Presentation("custom_field.pptx");
var savedShape = (IAutoShape)reopened.Slides[0].Shapes[0];
var savedPortion = savedShape.TextFrame.Paragraphs[0].Portions[0];
Console.WriteLine($"Type: {savedPortion.Field?.Type.InternalString}");
Console.WriteLine($"Text: {savedPortion.Text}");
```

Après ce aller‑retour PPTX, le type est `custom-report-id` et le texte est `Report-042`. Passer une chaîne telle que `yyyy-MM-dd` nommerait un type de champ ; cela ne configurerait pas un format de date personnalisé. Pour une date fixe dans un format arbitraire, utilisez du texte ordinaire.

## **Inspecter, modifier et supprimer les champs Date/Heure**

Lisez et modifiez un champ existant via [IField.Type](https://reference.aspose.com/slides/fr/net/aspose.slides/ifield/type/). Vérifiez que le champ existe avant d’accéder à son type. Pour arrêter les mises à jour automatiques, appelez [IPortion.RemoveField](https://reference.aspose.com/slides/fr/net/aspose.slides/iportion/removefield/). Cela conserve la portion et son texte actuel tout en supprimant l’association au champ. Si vous avez besoin d’une valeur fixe particulière, affectez ce texte après la suppression du champ.

Pour le paramètre d’API lié au traitement des champs date/heure, consultez [Presentation.CurrentDateTime](https://reference.aspose.com/slides/fr/net/aspose.slides/presentation/currentdatetime/). L’exemple ci‑dessous utilise une date d’approbation explicite lors de la conversion d’un champ en texte ordinaire.

Téléchargez [sample.pptx](sample.pptx) et placez‑le dans le répertoire de travail. Il contient deux formes texte nommées, `UpdatedAt` et `ApprovedDate`, chacune avec un champ date/heure, ainsi que des étiquettes de texte ordinaires. L’exemple suivant parcourt les formes texte de niveau supérieur sur les diapositives normales. Il convertit les champs date/heure en format de date longue et les met en italique, tout en conservant leur autre mise en forme. Seuls les champs dans `ApprovedDate` deviennent du texte figé.

Le script reconnaît les identifiants internes intégrés `datetime` et `datetime1` à `datetime13`. Les groupes, tableaux, notes, dispositions et maîtres nécessitent la traversée de leurs propres conteneurs de texte et sont hors du champ de cet exemple.

```cs
using System;
using System.Globalization;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("sample.pptx");
var approvalDate = new DateTime(2030, 4, 5);
var culture = CultureInfo.GetCultureInfo("en-US");

foreach (var slide in presentation.Slides)
{
    foreach (var shape in slide.Shapes)
    {
        if (shape is not IAutoShape textShape || textShape.TextFrame == null)
            continue;

        foreach (var paragraph in textShape.TextFrame.Paragraphs)
        {
            foreach (var portion in paragraph.Portions)
            {
                var field = portion.Field;
                if (field == null)
                    continue;

                var typeName = field.Type.InternalString;
                var isDateTime = typeName == "datetime";
                if (typeName.StartsWith("datetime", StringComparison.Ordinal))
                {
                    var hasFormatNumber = int.TryParse(typeName.Substring(8), out var formatNumber);
                    isDateTime |= hasFormatNumber && formatNumber >= 1 && formatNumber <= 13;
                }
                if (!isDateTime)
                    continue;

                field.Type = FieldType.DateTime3;
                portion.PortionFormat.LanguageId = "en-US";
                portion.PortionFormat.FontItalic = NullableBool.True;

                if (textShape.Name == "ApprovedDate")
                {
                    portion.RemoveField();
                    portion.Text = approvalDate.ToString("dd MMMM yyyy", culture);
                }
            }
        }
    }
}

presentation.Save("updated_dates.pptx", SaveFormat.Pptx);

using var reopened = new Presentation("updated_dates.pptx");
foreach (var shape in reopened.Slides[0].Shapes)
{
    if (shape is not IAutoShape textShape || textShape.TextFrame == null)
        continue;
    if (textShape.Name != "UpdatedAt" && textShape.Name != "ApprovedDate")
        continue;

    var portion = textShape.TextFrame.Paragraphs[0].Portions[0];
    var typeName = portion.Field?.Type.InternalString ?? "ordinary text";
    Console.WriteLine($"{textShape.Name}: {typeName}; {portion.Text}");
    Console.WriteLine($"Italic: {portion.PortionFormat.FontItalic}");
}
```

Après réouverture, `UpdatedAt` a le type `datetime3` et reste dynamique. `ApprovedDate` n’a plus de champ et contient `05 April 2030`. Les deux portions de date sont en italique, et leur taille de police, graisse et couleur d’origine restent intactes. Les étiquettes de texte ordinaires restent inchangées. La vérification lit la première portion des deux formes connues dans l’échantillon fourni.

## **Conserver la mise en forme du texte**

Travaillez avec la portion existante lors de l’ajout, du changement de type ou de la suppression d’un champ. Ces opérations conservent la mise en forme de cette portion. Utilisez [IPortion.PortionFormat](https://reference.aspose.com/slides/fr/net/aspose.slides/iportion/portionformat/) pour ne modifier que les propriétés nécessaires, comme le montrent les exemples pour la couleur ou l’italique.

Évitez de reconstruire tout le cadre de texte simplement pour mettre à jour un champ : cela peut entraîner la perte des limites de portions originales et de leur mise en forme individuelle. Distinguissez également la mise en forme explicitement définie de celle héritée du paragraphe, de la disposition ou du thème. Consultez [Text Formatting](/slides/fr/net/text-formatting/) pour des options de mise en forme plus larges.

## **Champs et espaces réservés En‑tête/Pied de page**

Un champ fait partie d’une portion de texte. Un espace réservé est une forme dotée d’un rôle de présentation, comme un pied de page ou un numéro de diapositive. Ajouter un champ à une zone de texte ordinaire ne transforme pas cette forme en espace réservé.

Les gestionnaires d’en‑tête/pied de page contrôlent le texte et la visibilité des espaces réservés sur les diapositives, les dispositions et les maîtres, y compris la propagation aux diapositives dépendantes. Un champ numéro dans une zone de texte personnalisée peut donc être utile même si vous n’utilisez pas l’espace réservé de numéro de diapositive. Inversement, modifier la visibilité d’un espace réservé ne supprime pas un champ d’une zone de texte non liée.

Les types prédéfinis d’en‑tête et de pied de page ne créent pas les espaces réservés correspondants ni ne fournissent leur contenu. En particulier, une diapositive PowerPoint standard n’a pas d’espace réservé d’en‑tête ; les en‑têtes appartiennent aux pages de notes et aux documents de distribution. Ne supposez pas qu’un champ en‑tête ou pied de page dans une forme quelconque obtiendra automatiquement le texte configuré via un gestionnaire d’espace réservé. Pour ce scénario, consultez [Presentation Headers and Footers](/slides/fr/net/presentation-header-and-footer/).

## **Limitations PPTX et PPT**

Vérifiez à la fois le type de champ et le texte résultant après enregistrement et réouverture. La préservation d’un identifiant ne prouve pas qu’une application peut calculer ou afficher sa valeur.

| Format | Comportement du champ et limitations |
|---|---|
| PPTX | Stocke les identifiants internes de champ à côté du texte du champ. Dans les vérifications aller‑retour, les types prédéfinis et l’identifiant personnalisé utilisé ci‑dessus ont survécu à l’enregistrement et à la réouverture. Le type personnalisé inconnu a conservé son texte de secours ; il n’a pas acquis de logique de calcul automatique. Une autre application peut traiter les identifiants non pris en charge différemment. |
| PPT | Utilise des représentations de champ héritées et est moins compatible. Dans les vérifications aller‑retour, les champs numéro de diapositive et date/heure prédéfinis ont survécu à l’enregistrement et à la réouverture. Un champ personnalisé dans une zone de texte ordinaire s’est rouvert avec son identifiant mais avec `*` comme texte ; un champ d’en‑tête dans le même contexte a également produit `*`. Ne comptez pas sur le fait que les champs personnalisés ou les contextes de champ non pris en charge conservent leur texte visible. |

Pour une sortie portable et fixe, convertissez les champs non pris en charge en texte ordinaire et affectez explicitement la valeur souhaitée avant d’enregistrer. Cela préserve le texte choisi tout en arrêtant intentionnellement les mises à jour automatiques. Testez également l’application cible lorsque son propre recalcul de champ fait partie de votre flux de travail.

## **FAQ**

**Comment savoir si un numéro ou une date affichée provient d’un champ ?**

Inspectez [IPortion.Field](https://reference.aspose.com/slides/fr/net/aspose.slides/iportion/field/). Une valeur non nulle identifie un champ ; le texte affiché seul ne permet pas de le déterminer.

**La suppression d’un champ supprime‑t‑elle son texte ou sa mise en forme ?**

Non. [RemoveField](https://reference.aspose.com/slides/fr/net/aspose.slides/iportion/removefield/) convertit la portion existante en texte ordinaire. Attribuez une valeur explicite ensuite si vous avez besoin d’une date figée ou d’une valeur de secours particulière.

**Une chaîne interne peut‑elle définir un nouveau format de date ou une formule ?**

Non. Elle identifie simplement un type de champ. Un identifiant inconnu ne fournit pas d’évaluateur ni de modèle de format de date .NET. Utilisez un type prédéfini pris en charge ou formatez vous‑même la valeur en texte ordinaire.

**Pourquoi vérifier à nouveau une présentation après l’avoir enregistrée ?**

Les identifiants de champ, le texte calculé et la mise en forme sont des éléments distincts à contrôler. La conversion de format peut modifier le résultat visible même lorsque l’identifiant de champ est toujours présent.