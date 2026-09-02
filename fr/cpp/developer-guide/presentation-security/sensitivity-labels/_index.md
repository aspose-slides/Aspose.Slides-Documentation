---
title: Gestion des étiquettes de sensibilité dans les présentations PowerPoint en C++
linktitle: Étiquettes de sensibilité
type: docs
weight: 50
url: /fr/cpp/sensitivity-labels/
keywords:
- étiquette de sensibilité
- Microsoft Purview
- Microsoft Information Protection
- métadonnées MIP
- marquage de contenu
- protection de l'information
- gouvernance des documents
- PowerPoint
- PPTX
- sécurité des présentations
- C++
- Aspose.Slides
description: "Lire, ajouter, mettre à jour, supprimer et migrer les étiquettes de sensibilité Microsoft Purview dans les présentations PowerPoint PPTX avec Aspose.Slides pour C++."
---
## **Vue d'ensemble**

Les étiquettes de sensibilité Microsoft Purview aident les organisations à classer et à gouverner les documents. Lors du traitement automatisé d’une présentation, une application peut devoir conserver une étiquette existante, appliquer une étiquette sélectionnée par une stratégie, mettre à jour son état ou migrer les métadonnées d’étiquette écrites par un ancien flux de travail Microsoft Information Protection (MIP).

Aspose.Slides expose les métadonnées d’étiquettes de sensibilité modernes via [IPresentation::get_SensitivityLabels](https://reference.aspose.com/slides/fr/cpp/aspose.slides/ipresentation/get_sensitivitylabels/). Cette méthode renvoie une [ISensitivityLabelCollection](https://reference.aspose.com/slides/fr/cpp/aspose.slides/isensitivitylabelcollection/) qui peut être inspectée et modifiée avant que la présentation ne soit enregistrée au format PPTX.

{{% alert color="primary" title="Remarque" %}}
Les identifiants d’étiquette de sensibilité et les informations de stratégie sont définis par votre configuration Microsoft Purview. Validez la disponibilité des étiquettes et les exigences de stratégie dans votre environnement avant d’ajouter ou de migrer des métadonnées. Les valeurs de [ISensitivityLabel::get_ContentMarkTypes](https://reference.aspose.com/slides/fr/cpp/aspose.slides/isensitivitylabel/get_contentmarktypes/) décrivent les marquages de contenu associés à une étiquette ; elles n’ajoutent pas, d’elles seules, de texte ou de formes visibles aux diapositives.
{{% /alert %}}

## **Comprendre les propriétés des étiquettes de sensibilité**

Chaque [ISensitivityLabel](https://reference.aspose.com/slides/fr/cpp/aspose.slides/isensitivitylabel/) contient les métadonnées suivantes :

| Accesseurs | Objectif |
| --- | --- |
| [ISensitivityLabel::get_Id](https://reference.aspose.com/slides/fr/cpp/aspose.slides/isensitivitylabel/get_id/), [ISensitivityLabel::set_Id](https://reference.aspose.com/slides/fr/cpp/aspose.slides/isensitivitylabel/set_id/) | Identifie l’étiquette de sensibilité dans la stratégie Purview. |
| [ISensitivityLabel::get_SiteId](https://reference.aspose.com/slides/fr/cpp/aspose.slides/isensitivitylabel/get_siteid/), [ISensitivityLabel::set_SiteId](https://reference.aspose.com/slides/fr/cpp/aspose.slides/isensitivitylabel/set_siteid/) | Identifie le site associé à la stratégie d’étiquette. |
| [ISensitivityLabel::get_IsEnabled](https://reference.aspose.com/slides/fr/cpp/aspose.slides/isensitivitylabel/get_isenabled/), [ISensitivityLabel::set_IsEnabled](https://reference.aspose.com/slides/fr/cpp/aspose.slides/isensitivitylabel/set_isenabled/) | Indique si l’étiquette est activée. |
| [ISensitivityLabel::get_IsRemoved](https://reference.aspose.com/slides/fr/cpp/aspose.slides/isensitivitylabel/get_isremoved/), [ISensitivityLabel::set_IsRemoved](https://reference.aspose.com/slides/fr/cpp/aspose.slides/isensitivitylabel/set_isremoved/) | Indique que l’étiquette a été supprimée. Définissez la valeur à `true` lorsque l’état de suppression doit être conservé dans les métadonnées. |
| [ISensitivityLabel::get_AssignmentMethodType](https://reference.aspose.com/slides/fr/cpp/aspose.slides/isensitivitylabel/get_assignmentmethodtype/), [ISensitivityLabel::set_AssignmentMethodType](https://reference.aspose.com/slides/fr/cpp/aspose.slides/isensitivitylabel/set_assignmentmethodtype/) | Spécifie si l’étiquette a été appliquée automatiquement ou suite à une décision utilisateur. |
| [ISensitivityLabel::get_ContentMarkTypes](https://reference.aspose.com/slides/fr/cpp/aspose.slides/isensitivitylabel/get_contentmarktypes/) | Répertorie les types de marquage de contenu associés à l’étiquette. |

L’énumération [SensitivityLabelAssignmentType](https://reference.aspose.com/slides/fr/cpp/aspose.slides/sensitivitylabelassignmenttype/) décrit comment une étiquette a été attribuée :

- [SensitivityLabelAssignmentType::Standard](https://reference.aspose.com/slides/fr/cpp/aspose.slides/sensitivitylabelassignmenttype/) représente une étiquette par défaut ou appliquée automatiquement.  
- [SensitivityLabelAssignmentType::Privileged](https://reference.aspose.com/slides/fr/cpp/aspose.slides/sensitivitylabelassignmenttype/) représente une étiquette appliquée suite à une décision utilisateur, incluant les étiquettes appliquées manuellement, recommandées et obligatoires.

L’énumération [SensitivityLabelContentType](https://reference.aspose.com/slides/fr/cpp/aspose.slides/sensitivitylabelcontenttype/) identifie le marquage associé à une étiquette :

| Valeur | Signification |
| --- | --- |
| [SensitivityLabelContentType::None](https://reference.aspose.com/slides/fr/cpp/aspose.slides/sensitivitylabelcontenttype/) | L’étiquette a été appliquée par défaut ou automatiquement. |
| [SensitivityLabelContentType::Header](https://reference.aspose.com/slides/fr/cpp/aspose.slides/sensitivitylabelcontenttype/) | Un marquage de contenu d’en‑tête est associé à l’étiquette. |
| [SensitivityLabelContentType::Footer](https://reference.aspose.com/slides/fr/cpp/aspose.slides/sensitivitylabelcontenttype/) | Un marquage de contenu de pied de page est associé à l’étiquette. |
| [SensitivityLabelContentType::Watermark](https://reference.aspose.com/slides/fr/cpp/aspose.slides/sensitivitylabelcontenttype/) | Un marquage de contenu de filigrane est associé à l’étiquette. |
| [SensitivityLabelContentType::Encryption](https://reference.aspose.com/slides/fr/cpp/aspose.slides/sensitivitylabelcontenttype/) | Une protection de chiffrement est associée à l’étiquette. |

Plusieurs types de marquage peuvent être associés à une même étiquette.

## **Lister les étiquettes de sensibilité existantes**

Lisez la collection d’étiquettes modernes via [IPresentation::get_SensitivityLabels](https://reference.aspose.com/slides/fr/cpp/aspose.slides/ipresentation/get_sensitivitylabels/) et parcourez‑la. L’exemple suivant répertorie chaque propriété et chaque marquage de contenu stockés pour chaque étiquette :

```cpp
#include <DOM/Presentation.h>
#include <DOM/ISensitivityLabel.h>
#include <DOM/ISensitivityLabelCollection.h>
#include <DOM/SensitivityLabelAssignmentType.h>
#include <DOM/SensitivityLabelContentType.h>
#include <system/collections/ilist.h>
#include <system/console.h>
#include <system/guid.h>
#include <system/shared_ptr.h>
#include <system/string.h>

using Aspose::Slides::Presentation;
using System::Console;
using System::MakeObject;

auto presentation = MakeObject<Presentation>(u"presentation.pptx");
auto sensitivityLabels = presentation->get_SensitivityLabels();

for (auto&& sensitivityLabel : sensitivityLabels)
{
    auto labelIdentifier = sensitivityLabel->get_Id();
    auto siteIdentifier = sensitivityLabel->get_SiteId();
    auto isEnabled = sensitivityLabel->get_IsEnabled();
    auto isRemoved = sensitivityLabel->get_IsRemoved();
    auto assignmentMethod = sensitivityLabel->get_AssignmentMethodType();

    Console::WriteLine(u"Label ID: {0}", labelIdentifier);
    Console::WriteLine(u"Site ID: {0}", siteIdentifier);
    Console::WriteLine(u"Enabled: {0}", isEnabled);
    Console::WriteLine(u"Removed: {0}", isRemoved);
    Console::WriteLine(u"Assignment method: {0}", assignmentMethod);

    for (auto contentMarkType : sensitivityLabel->get_ContentMarkTypes())
    {
        Console::WriteLine(u"Content marking: {0}", contentMarkType);
    }
}

presentation->Dispose();
```

## **Ajouter une étiquette de sensibilité avec marquage de contenu**

Utilisez [ISensitivityLabelCollection::Add](https://reference.aspose.com/slides/fr/cpp/aspose.slides/isensitivitylabelcollection/add/) avec l’identifiant de l’étiquette, l’identifiant du site, l’état activé et la méthode d’attribution. Après que la méthode renvoie la nouvelle [ISensitivityLabel](https://reference.aspose.com/slides/fr/cpp/aspose.slides/isensitivitylabel/), ajoutez les valeurs de marquage requises via [ISensitivityLabel::get_ContentMarkTypes](https://reference.aspose.com/slides/fr/cpp/aspose.slides/isensitivitylabel/get_contentmarktypes/).

L’exemple suivant ajoute une étiquette sélectionnée manuellement associée aux marquages de pied de page et de filigrane, puis enregistre le résultat au format PPTX :

```cpp
#include <DOM/Presentation.h>
#include <DOM/ISensitivityLabel.h>
#include <DOM/ISensitivityLabelCollection.h>
#include <DOM/SensitivityLabelAssignmentType.h>
#include <DOM/SensitivityLabelContentType.h>
#include <Export/SaveFormat.h>
#include <system/collections/ilist.h>
#include <system/guid.h>
#include <system/shared_ptr.h>

using Aspose::Slides::Presentation;
using Aspose::Slides::SensitivityLabelAssignmentType;
using Aspose::Slides::SensitivityLabelContentType;
using Aspose::Slides::Export::SaveFormat;
using System::Guid;
using System::MakeObject;

auto presentation = MakeObject<Presentation>(u"presentation.pptx");
auto sensitivityLabels = presentation->get_SensitivityLabels();

auto labelIdentifier = u"{11111111-2222-3333-4444-555555555555}";
auto siteIdentifier = Guid::Parse(u"{aaaaaaaa-bbbb-cccc-dddd-eeeeeeeeeeee}");
bool isEnabled = true;
auto assignmentMethod = SensitivityLabelAssignmentType::Privileged;

auto sensitivityLabel = sensitivityLabels->Add(
    labelIdentifier,
    siteIdentifier,
    isEnabled,
    assignmentMethod);

sensitivityLabel->get_ContentMarkTypes()->Add(SensitivityLabelContentType::Footer);
sensitivityLabel->get_ContentMarkTypes()->Add(SensitivityLabelContentType::Watermark);

presentation->Save(u"presentation_with_label.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **Mettre à jour une étiquette de sensibilité**

Les valeurs de [ISensitivityLabel](https://reference.aspose.com/slides/fr/cpp/aspose.slides/isensitivitylabel/) sont en lecture/écriture via leurs méthodes d’accès et de modification, à l’exception de la collection renvoyée par [ISensitivityLabel::get_ContentMarkTypes](https://reference.aspose.com/slides/fr/cpp/aspose.slides/isensitivitylabel/get_contentmarktypes/) qui est modifiée via ses opérations de liste. Après avoir localisé l’étiquette requise, vous pouvez mettre à jour son identifiant, son identifiant de site, son état activé, sa méthode d’attribution, son état de suppression et ses types de marquage de contenu. Enregistrez la présentation pour persister les modifications.

L’exemple suivant met à jour l’état activé et la méthode d’attribution de la première étiquette :

```cpp
#include <DOM/Presentation.h>
#include <DOM/ISensitivityLabel.h>
#include <DOM/ISensitivityLabelCollection.h>
#include <DOM/SensitivityLabelAssignmentType.h>
#include <Export/SaveFormat.h>
#include <system/shared_ptr.h>

using Aspose::Slides::Presentation;
using Aspose::Slides::SensitivityLabelAssignmentType;
using Aspose::Slides::Export::SaveFormat;
using System::MakeObject;

auto presentation = MakeObject<Presentation>(u"presentation.pptx");
auto sensitivityLabels = presentation->get_SensitivityLabels();
int labelCount = sensitivityLabels->get_Count();

if (labelCount > 0)
{
    auto sensitivityLabel = sensitivityLabels->idx_get(0);
    sensitivityLabel->set_IsEnabled(true);
    sensitivityLabel->set_AssignmentMethodType(SensitivityLabelAssignmentType::Privileged);
}

presentation->Save(u"presentation_with_updated_label.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **Marquer une étiquette de sensibilité comme supprimée**

Pour conserver le fait qu’une étiquette a été supprimée, trouvez l’étiquette et appelez [ISensitivityLabel::set_IsRemoved](https://reference.aspose.com/slides/fr/cpp/aspose.slides/isensitivitylabel/set_isremoved/) avec `true`. Cela conserve l’entrée d’étiquette tout en enregistrant son état de suppression. Si vous devez plutôt supprimer une entrée de la collection moderne, utilisez [ISensitivityLabelCollection::RemoveAt](https://reference.aspose.com/slides/fr/cpp/aspose.slides/isensitivitylabelcollection/removeat/); utilisez [ISensitivityLabelCollection::Clear](https://reference.aspose.com/slides/fr/cpp/aspose.slides/isensitivitylabelcollection/clear/) pour supprimer toutes les entrées.

L’exemple suivant marque une étiquette spécifique comme supprimée et enregistre la présentation mise à jour :

```cpp
#include <DOM/Presentation.h>
#include <DOM/ISensitivityLabel.h>
#include <DOM/ISensitivityLabelCollection.h>
#include <Export/SaveFormat.h>
#include <system/shared_ptr.h>
#include <system/string.h>
#include <system/string_comparison.h>

using Aspose::Slides::Presentation;
using Aspose::Slides::Export::SaveFormat;
using System::MakeObject;
using System::String;
using System::StringComparison;

auto presentation = MakeObject<Presentation>(u"presentation.pptx");
auto sensitivityLabels = presentation->get_SensitivityLabels();
auto targetLabelIdentifier = u"{11111111-2222-3333-4444-555555555555}";

for (auto&& sensitivityLabel : sensitivityLabels)
{
    auto labelIdentifier = sensitivityLabel->get_Id();
    bool isTargetLabel = String::Equals(
        labelIdentifier,
        targetLabelIdentifier,
        StringComparison::OrdinalIgnoreCase);

    if (isTargetLabel)
    {
        sensitivityLabel->set_IsRemoved(true);
        break;
    }
}

presentation->Save(u"presentation_with_removed_label.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **Lire et migrer les anciennes étiquettes de sensibilité MIP**

Les anciens flux de travail basés sur MIP peuvent stocker les métadonnées d’étiquettes de sensibilité dans les propriétés personnalisées du document au lieu de la collection d’étiquettes moderne. Lisez ces métadonnées avec [IDocumentProperties::GetSensitivityLabels](https://reference.aspose.com/slides/fr/cpp/aspose.slides/idocumentproperties/getsensitivitylabels/). La méthode analyse les propriétés personnalisées héritées et renvoie un tableau d’objets [ISensitivityLabel](https://reference.aspose.com/slides/fr/cpp/aspose.slides/isensitivitylabel/).

Pour migrer les métadonnées, ajoutez chaque étiquette renvoyée à la [ISensitivityLabelCollection] moderne via [ISensitivityLabelCollection::Add](https://reference.aspose.com/slides/fr/cpp/aspose.slides/isensitivitylabelcollection/add/). Étant donné que l’ajout d’un identifiant d’étiquette dupliqué déclenche une exception, l’exemple vérifie la collection de destination avant de copier chaque étiquette. Vous pouvez ajouter une validation supplémentaire pour confirmer que chaque étiquette héritée existe encore dans la stratégie Purview actuelle.

```cpp
#include <DOM/Presentation.h>
#include <DOM/IDocumentProperties.h>
#include <DOM/ISensitivityLabel.h>
#include <DOM/ISensitivityLabelCollection.h>
#include <Export/SaveFormat.h>
#include <system/array.h>
#include <system/shared_ptr.h>
#include <system/string.h>
#include <system/string_comparison.h>

using Aspose::Slides::Presentation;
using Aspose::Slides::Export::SaveFormat;
using System::MakeObject;
using System::String;
using System::StringComparison;

auto presentation = MakeObject<Presentation>(u"presentation_with_legacy_labels.pptx");
auto documentProperties = presentation->get_DocumentProperties();
auto legacySensitivityLabels = documentProperties->GetSensitivityLabels();
auto modernSensitivityLabels = presentation->get_SensitivityLabels();

for (auto&& legacySensitivityLabel : legacySensitivityLabels)
{
    bool labelAlreadyExists = false;
    auto legacyLabelIdentifier = legacySensitivityLabel->get_Id();

    for (auto&& modernSensitivityLabel : modernSensitivityLabels)
    {
        auto modernLabelIdentifier = modernSensitivityLabel->get_Id();
        labelAlreadyExists = String::Equals(
            modernLabelIdentifier,
            legacyLabelIdentifier,
            StringComparison::OrdinalIgnoreCase);

        if (labelAlreadyExists)
        {
            break;
        }
    }

    if (!labelAlreadyExists)
    {
        modernSensitivityLabels->Add(legacySensitivityLabel);
    }
}

presentation->Save(u"presentation_with_modern_labels.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

La migration copie les objets d’étiquette analysés dans la collection moderne. Elle ne nécessite pas de vider toutes les propriétés personnalisées du document, de sorte que les métadonnées du document non liées restent intactes. Utilisez [IPresentation::Save](https://reference.aspose.com/slides/fr/cpp/aspose.slides/ipresentation/save/) avec [SaveFormat::Pptx](https://reference.aspose.com/slides/fr/cpp/aspose.slides.export/saveformat/) pour écrire les métadonnées d’étiquette modernes dans un fichier PPTX.

## **FAQ**

**L’ajout d’un type de marquage de contenu crée‑t‑il un en‑tête, un pied de page ou un filigrane visible sur les diapositives ?**

Non. Les valeurs ajoutées via [ISensitivityLabel::get_ContentMarkTypes](https://reference.aspose.com/slides/fr/cpp/aspose.slides/isensitivitylabel/get_contentmarktypes/) décrivent les marquages associés à l’étiquette de sensibilité. Elles ne créent pas de texte ou de formes visibles dans la présentation. Ajoutez séparément le contenu de diapositive correspondant si votre flux de travail doit rendre ces marquages.

**Quelle est la différence entre marquer une étiquette comme supprimée et la supprimer de la collection ?**

Appeler [ISensitivityLabel::set_IsRemoved](https://reference.aspose.com/slides/fr/cpp/aspose.slides/isensitivitylabel/set_isremoved/) avec `true` conserve l’entrée d’étiquette et enregistre son état de suppression. Appeler [ISensitivityLabelCollection::RemoveAt](https://reference.aspose.com/slides/fr/cpp/aspose.slides/isensitivitylabelcollection/removeat/) supprime l’entrée de la collection moderne. Choisissez l’opération qui correspond aux exigences de conservation des métadonnées de votre organisation.

**Une présentation peut‑elle contenir à la fois des métadonnées MIP héritées et des étiquettes de sensibilité modernes ?**

Oui. Les étiquettes héritées peuvent rester dans les propriétés personnalisées du document tandis que les étiquettes modernes sont accessibles via [IPresentation::get_SensitivityLabels](https://reference.aspose.com/slides/fr/cpp/aspose.slides/ipresentation/get_sensitivitylabels/). Utilisez [IDocumentProperties::GetSensitivityLabels](https://reference.aspose.com/slides/fr/cpp/aspose.slides/idocumentproperties/getsensitivitylabels/) pour lire les métadonnées héritées et ne migrer que les étiquettes valides qui ne sont pas déjà présentes dans la collection moderne.

**Que se passe‑t‑il lorsqu’une étiquette avec le même identifiant est ajoutée plusieurs fois ?**

[ISensitivityLabelCollection::Add](https://reference.aspose.com/slides/fr/cpp/aspose.slides/isensitivitylabelcollection/add/) déclenche une exception d’argument lorsque la collection contient déjà une étiquette avec le même identifiant. Vérifiez les valeurs existantes de [ISensitivityLabel::get_Id](https://reference.aspose.com/slides/fr/cpp/aspose.slides/isensitivitylabel/get_id/) avant d’ajouter ou de migrer des étiquettes.

**Quel format de sortie doit être utilisé pour conserver les étiquettes de sensibilité mises à jour ?**

Enregistrez la présentation au format PPTX en appelant [IPresentation::Save](https://reference.aspose.com/slides/fr/cpp/aspose.slides/ipresentation/save/) avec [SaveFormat::Pptx](https://reference.aspose.com/slides/fr/cpp/aspose.slides.export/saveformat/), comme indiqué dans les exemples ci‑dessus.