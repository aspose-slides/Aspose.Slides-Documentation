---
title: Gérer les champs de texte dans les présentations PowerPoint en C++
linktitle: Champs de texte
type: docs
weight: 52
url: /fr/cpp/text-fields/
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
- C++
- Aspose.Slides
description: "Créer, inspecter, modifier et supprimer les champs de texte dans les présentations PowerPoint avec Aspose.Slides pour C++. Conserver la mise en forme et vérifier les fichiers PPTX et PPT enregistrés."
---
## **Aperçu**

Un paragraphe de texte se compose de portions. Une [IPortion] ordinaire contient du texte littéral ; une portion de champ possède également un [IField] dont le type identifie une valeur mise à jour automatiquement, comme un numéro de diapositive ou une date. Deux portions peuvent afficher les mêmes caractères alors qu'une seule contient un champ.

Utilisez [IPortion::get_Field] pour les distinguer : il renvoie `nullptr` pour du texte ordinaire. [IPortion::AddField] convertit une portion existante en champ. Conservez une étiquette et sa valeur dynamique dans des portions distinctes afin que la conversion de la valeur ne remplace pas également l'étiquette.

Ce guide couvre les champs à l'intérieur du texte, leur mise en forme, et leur enregistrement au format PPTX et PPT. Pour les blocs de texte et les paragraphes, consultez [Manage Text](/slides/fr/cpp/manage-text/).

## **Créer un champ de numéro de diapositive**

L'exemple suivant crée une zone de texte contenant une étiquette littérale `Slide ` suivie d'un nombre mis à jour automatiquement. Il définit la taille, le poids et la couleur du nombre avant d'ajouter le champ, puis rouvre la présentation enregistrée et vérifie le type de champ, le texte et la mise en forme. Aucun fichier d'entrée n'est requis.

```cpp
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/IShapeCollection.h>
#include <DOM/IAutoShape.h>
#include <DOM/ShapeType.h>
#include <DOM/ITextFrame.h>
#include <DOM/IParagraph.h>
#include <DOM/IPortionCollection.h>
#include <DOM/Portion.h>
#include <DOM/IPortion.h>
#include <DOM/IPortionFormat.h>
#include <DOM/IFillFormat.h>
#include <DOM/IColorFormat.h>
#include <DOM/FillType.h>
#include <DOM/NullableBool.h>
#include <DOM/IField.h>
#include <DOM/IFieldType.h>
#include <DOM/FieldType.h>
#include <Export/SaveFormat.h>
#include <drawing/color.h>
#include <system/console.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);
auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 40, 40, 240, 50);
shape->AddTextFrame(u"Slide ");
auto paragraph = shape->get_TextFrame()->get_Paragraph(0);

auto numberPortion = System::MakeObject<Portion>();
numberPortion->get_PortionFormat()->set_FontHeight(24);
numberPortion->get_PortionFormat()->set_FontBold(NullableBool::True);
numberPortion->get_PortionFormat()->get_FillFormat()->set_FillType(FillType::Solid);
numberPortion->get_PortionFormat()->get_FillFormat()->get_SolidFillColor()->set_Color(System::Drawing::Color::get_DarkBlue());
paragraph->get_Portions()->Add(numberPortion);
numberPortion->AddField(FieldType::get_SlideNumber());

presentation->Save(u"slide_number.pptx", SaveFormat::Pptx);
presentation->Dispose();

auto reopened = System::MakeObject<Presentation>(u"slide_number.pptx");
auto savedShape = System::ExplicitCast<IAutoShape>(reopened->get_Slide(0)->get_Shape(0));
auto savedNumber = savedShape->get_TextFrame()->get_Paragraph(0)->get_Portion(1);
auto field = savedNumber->get_Field();
auto hasNumberField = field != nullptr && field->get_Type()->get_InternalString() == FieldType::get_SlideNumber()->get_InternalString();
auto format = savedNumber->get_PortionFormat();
auto formattingPreserved = format->get_FontHeight() == 24 && format->get_FontBold() == NullableBool::True;
formattingPreserved &= format->get_FillFormat()->get_SolidFillColor()->get_Color().ToArgb() == System::Drawing::Color::get_DarkBlue().ToArgb();

System::Console::WriteLine(u"Text: {0}", savedShape->get_TextFrame()->get_Text());
System::Console::WriteLine(u"Slide number field: {0}", hasNumberField);
System::Console::WriteLine(u"Formatting preserved: {0}", formattingPreserved);
reopened->Dispose();
```

La nouvelle présentation commence avec le numéro de diapositive 1, donc le texte attendu est `Slide 1`, et les deux vérifications doivent afficher `True`. Le nombre reste un champ après réouverture ; ce n'est pas un `1` littéral. Le transtypage et les indices dans la vérification font référence à la forme et aux portions créées par cet exemple.

## **Choisir un type de champ**

[FieldType] implémente [IFieldType] et fournit les valeurs prédéfinies suivantes. Passez la valeur appropriée à [AddField].

| Accesseur | Objectif |
|---|---|
| [get_SlideNumber](https://reference.aspose.com/slides/fr/cpp/aspose.slides/fieldtype/get_slidenumber/) | Le numéro de diapositive actuel. |
| [get_DateTime](https://reference.aspose.com/slides/fr/cpp/aspose.slides/fieldtype/get_datetime/) | Date/heure au format par défaut de l'application de rendu. |
| [get_DateTime1](https://reference.aspose.com/slides/fr/cpp/aspose.slides/fieldtype/get_datetime1/)–[get_DateTime9](https://reference.aspose.com/slides/fr/cpp/aspose.slides/fieldtype/get_datetime9/) | Formats de date prédéfinis ou formats combinés date/heure. |
| [get_DateTime10](https://reference.aspose.com/slides/fr/cpp/aspose.slides/fieldtype/get_datetime10/)–[get_DateTime13](https://reference.aspose.com/slides/fr/cpp/aspose.slides/fieldtype/get_datetime13/) | Formats d'heure prédéfinis, avec options pour les secondes et une horloge 12 heures. |
| [get_Header](https://reference.aspose.com/slides/fr/cpp/aspose.slides/fieldtype/get_header/) | Un champ d'en‑tête ; voir les limitations de l'espace réservé et du format ci‑dessous. |
| [get_Footer](https://reference.aspose.com/slides/fr/cpp/aspose.slides/fieldtype/get_footer/) | Un champ de pied de page. |

Par exemple, [get_DateTime3] fournit le jour, le nom complet du mois et l'année en anglais. Il s'agit de formats de champ prédéfinis, pas de chaînes de format de date arbitraires. La langue de la portion, définie avec [IBasePortionFormat::set_LanguageId], ainsi que l'application qui traite la présentation peuvent influencer le résultat affiché.

## **Créer un champ à partir d'une chaîne interne**

La surcharge chaîne de [AddField] accepte un identifiant de champ interne. Utilisez‑la pour conserver un identifiant fourni par une autre application qui n'a pas de valeur prédéfinie. Vous pouvez également créer un [FieldType] à partir de l'identifiant. [IFieldType::get_InternalString] expose cet identifiant pour inspection.

Cet exemple enregistre un champ spécifique à l'application `custom-report-id` avec le texte de secours `Report-042`. Aucun fichier d'entrée n'est requis. L'identifiant n'enregistre aucune calcul : Aspose.Slides ne génère pas d'IDs de rapport pour un type inconnu. L'application qui comprend cet identifiant doit fournir sa signification et mettre à jour sa valeur.

```cpp
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/IShapeCollection.h>
#include <DOM/IAutoShape.h>
#include <DOM/ShapeType.h>
#include <DOM/ITextFrame.h>
#include <DOM/IParagraph.h>
#include <DOM/IPortion.h>
#include <DOM/IField.h>
#include <DOM/IFieldType.h>
#include <Export/SaveFormat.h>
#include <system/console.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>();
auto shape = presentation->get_Slide(0)->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 40, 40, 300, 50);
shape->AddTextFrame(u"Report-042");
auto portion = shape->get_TextFrame()->get_Paragraph(0)->get_Portion(0);
portion->AddField(u"custom-report-id");
presentation->Save(u"custom_field.pptx", SaveFormat::Pptx);
presentation->Dispose();

auto reopened = System::MakeObject<Presentation>(u"custom_field.pptx");
auto savedShape = System::ExplicitCast<IAutoShape>(reopened->get_Slide(0)->get_Shape(0));
auto savedPortion = savedShape->get_TextFrame()->get_Paragraph(0)->get_Portion(0);
auto field = savedPortion->get_Field();
auto typeName = field != nullptr ? field->get_Type()->get_InternalString() : u"ordinary text";
System::Console::WriteLine(u"Type: {0}", typeName);
System::Console::WriteLine(u"Text: {0}", savedPortion->get_Text());
reopened->Dispose();
```

Après ce aller‑retour PPTX, le type attendu est `custom-report-id` et le texte attendu est `Report-042`. Passer une chaîne comme `yyyy-MM-dd` nommerait un type de champ ; cela ne configurerait pas un format de date personnalisé. Pour une date fixe dans un format arbitraire, utilisez du texte ordinaire.

## **Inspecter, modifier et supprimer les champs Date/Heure**

Lisez un type de champ existant via [IField::get_Type] et modifiez‑le via [IField::set_Type]. Vérifiez que le champ existe avant d'accéder à son type. Pour arrêter les mises à jour automatiques, appelez [IPortion::RemoveField]. Cela conserve la portion et son texte actuel tout en supprimant l'association au champ. Si vous avez besoin d'une valeur fixe spécifique, attribuez ce texte après avoir supprimé le champ.

Pour le paramètre d'API associé au traitement des champs date/heure, consultez [Presentation::set_CurrentDateTime]. L'exemple ci‑dessus utilise une date d'approbation explicite lors de la conversion d'un champ en texte ordinaire.

Téléchargez [sample.pptx](sample.pptx) et placez‑le dans le répertoire de travail. Il contient deux formes de texte nommées, `UpdatedAt` et `ApprovedDate`, chacune avec un champ date/heure, ainsi que des étiquettes de texte ordinaires. L'exemple suivant parcourt les formes de texte de niveau supérieur sur les diapositives normales. Il transforme les champs date/heure en un format de date longue et les rend italiques, tout en conservant leur autre mise en forme. Seuls les champs de `ApprovedDate` deviennent du texte fixe.

L'échantillon reconnaît les identifiants internes intégrés `datetime` et `datetime1` à `datetime13`. Les groupes, tableaux, notes, dispositions et maîtres nécessitent la traversée de leurs propres conteneurs de texte et sont hors du périmètre de cet exemple.

```cpp
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/IShapeCollection.h>
#include <DOM/IAutoShape.h>
#include <DOM/ITextFrame.h>
#include <DOM/IParagraph.h>
#include <DOM/IParagraphCollection.h>
#include <DOM/IPortion.h>
#include <DOM/IPortionCollection.h>
#include <DOM/IPortionFormat.h>
#include <DOM/NullableBool.h>
#include <DOM/IField.h>
#include <DOM/IFieldType.h>
#include <DOM/FieldType.h>
#include <Export/SaveFormat.h>
#include <system/console.h>
#include <system/date_time.h>
#include <system/globalization/culture_info.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>(u"sample.pptx");
auto approvalDate = System::DateTime(2030, 4, 5);
auto culture = System::Globalization::CultureInfo::GetCultureInfo(u"en-US");

for (auto slide : presentation->get_Slides())
{
    for (auto shape : slide->get_Shapes())
    {
        auto textShape = System::DynamicCast<IAutoShape>(shape);
        if (textShape == nullptr || textShape->get_TextFrame() == nullptr)
            continue;

        for (auto paragraph : textShape->get_TextFrame()->get_Paragraphs())
        {
            for (auto portion : paragraph->get_Portions())
            {
                auto field = portion->get_Field();
                if (field == nullptr)
                    continue;

                auto typeName = field->get_Type()->get_InternalString();
                auto isDateTime = typeName == u"datetime";
                for (auto formatNumber = 1; formatNumber <= 13; ++formatNumber)
                {
                    auto identifier = System::String::Format(u"datetime{0}", formatNumber);
                    isDateTime |= typeName == identifier;
                }
                if (!isDateTime)
                    continue;

                field->set_Type(FieldType::get_DateTime3());
                portion->get_PortionFormat()->set_LanguageId(u"en-US");
                portion->get_PortionFormat()->set_FontItalic(NullableBool::True);

                if (textShape->get_Name() == u"ApprovedDate")
                {
                    portion->RemoveField();
                    auto fixedDate = approvalDate.ToString(u"dd MMMM yyyy", culture);
                    portion->set_Text(fixedDate);
                }
            }
        }
    }
}

presentation->Save(u"updated_dates.pptx", SaveFormat::Pptx);
presentation->Dispose();

auto reopened = System::MakeObject<Presentation>(u"updated_dates.pptx");
for (auto shape : reopened->get_Slide(0)->get_Shapes())
{
    auto textShape = System::DynamicCast<IAutoShape>(shape);
    if (textShape == nullptr || textShape->get_TextFrame() == nullptr)
        continue;
    if (textShape->get_Name() != u"UpdatedAt" && textShape->get_Name() != u"ApprovedDate")
        continue;

    auto portion = textShape->get_TextFrame()->get_Paragraph(0)->get_Portion(0);
    auto field = portion->get_Field();
    auto typeName = field != nullptr ? field->get_Type()->get_InternalString() : u"ordinary text";
    System::Console::WriteLine(u"{0}: {1}; {2}", textShape->get_Name(), typeName, portion->get_Text());
    auto isItalic = portion->get_PortionFormat()->get_FontItalic() == NullableBool::True;
    System::Console::WriteLine(u"Italic: {0}", isItalic);
}
reopened->Dispose();
```

Après réouverture, `UpdatedAt` doit avoir le type `datetime3` et rester dynamique. `ApprovedDate` ne doit plus avoir de champ et contenir `05 April 2030`. Les deux portions de date sont en italique, et leur taille de police, gras et couleur d'origine restent intacts. Les étiquettes de texte ordinaire restent inchangées. La vérification lit la première portion des deux formes connues dans l'échantillon fourni.

## **Conserver la mise en forme du texte**

Travaillez avec la portion existante lors de l'ajout, la modification ou la suppression d'un champ. Ces opérations conservent la mise en forme de cette portion. Utilisez [IPortion::get_PortionFormat] pour ne modifier que les propriétés requises, comme le font les exemples pour la couleur ou l'italique.

Évitez de reconstruire tout un cadre de texte simplement pour mettre à jour un champ : cela peut perdre les limites originales des portions et leur mise en forme individuelle. Distinguez également la mise en forme définie explicitement de celle héritée du paragraphe, de la disposition ou du thème. Consultez [Text Formatting](/slides/fr/cpp/text-formatting/) pour des options de mise en forme plus larges.

## **Champs et espaces réservés d'en‑tête/pied de page**

Un champ fait partie d'une portion de texte. Un espace réservé est une forme avec un rôle de présentation, comme un pied de page ou un numéro de diapositive. Ajouter un champ à une zone de texte ordinaire ne transforme pas cette forme en espace réservé.

Les gestionnaires d'en‑tête/pied de page contrôlent le texte et la visibilité des espaces réservés sur les diapositives, dispositions et maîtres, y compris la propagation aux diapositives dépendantes. Un champ de numéro dans une zone de texte personnalisée peut donc être utile même si vous n'utilisez pas l'espace réservé du numéro de diapositive. Inversement, modifier la visibilité d'un espace réservé ne supprime pas un champ d'une zone de texte non liée.

Les types d'en‑tête et de pied de page prédéfinis ne créent pas les espaces réservés correspondants ni ne fournissent leur contenu. En particulier, une diapositive PowerPoint standard n'a pas d'espace réservé d'en‑tête ; les en‑têtes appartiennent aux pages de notes et aux documents de distribution. Ne supposez pas qu'un champ d'en‑tête ou de pied de page dans une forme quelconque obtienne automatiquement le texte configuré via un gestionnaire d'espace réservé. Pour ce flux de travail, consultez [Presentation Headers and Footers](/slides/fr/cpp/presentation-header-and-footer/).

## **Limitations PPTX et PPT**

Vérifiez à la fois le type de champ et le texte résultant après l'enregistrement et la réouverture. Conserver un identifiant ne prouve pas qu'une application peut calculer ou afficher sa valeur.

| Format | Comportement du champ et limitations |
|---|---|
| PPTX | Stocke les identifiants de champ internes avec le texte du champ. Utilisez les exemples ci‑dessus pour vérifier les types prédéfinis et les identifiants personnalisés après l'enregistrement et la réouverture. Un type personnalisé inconnu n'acquiert pas de logique de calcul automatique. Une autre application peut traiter les identifiants non pris en charge différemment. |
| PPT | Utilise des représentations de champ héritées et offre une compatibilité plus limitée. Les champs numéro de diapositive et les champs date/heure prédéfinis ont des représentations héritées. Les champs personnalisés non pris en charge ou les champs d'en‑tête dans une zone de texte de diapositive ordinaire peuvent produire `*` comme texte. Ne comptez pas sur le fait que les champs personnalisés ou les contextes de champ non pris en charge conservent leur texte visible. |

Pour une sortie portable et fixe, convertissez les champs non pris en charge en texte ordinaire et attribuez explicitement la valeur souhaitée avant l'enregistrement. Cela préserve le texte choisi tout en arrêtant intentionnellement les mises à jour automatiques. Testez également l'application cible lorsqu'une recalcul du champ propre à celle‑ci fait partie de votre flux de travail.

## **FAQ**

**Comment savoir si un nombre ou une date affichée est un champ ?**  
Inspectez [IPortion::get_Field]. Une valeur non nulle identifie un champ ; le texte affiché seul ne peut pas le déterminer.

**La suppression d'un champ supprime‑t‑elle son texte ou sa mise en forme ?**  
Non. [RemoveField] convertit la portion existante en texte ordinaire. Attribuez une valeur explicite après si vous avez besoin d'une date figée particulière ou d'une valeur de secours.

**Une chaîne interne peut‑elle définir un nouveau format de date ou une formule ?**  
Non. Elle identifie un type de champ. Un identifiant inconnu ne fournit pas d'évaluateur ni de motif de format de date. Utilisez un type prédéfini supporté ou formatez vous‑même la valeur en texte ordinaire.

**Pourquoi vérifier de nouveau une présentation après l'avoir enregistrée ?**  
Les identifiants de champ, le texte calculé et la mise en forme sont des éléments distincts à vérifier. La conversion de format peut modifier le résultat visible même si l'identifiant de champ est toujours présent.