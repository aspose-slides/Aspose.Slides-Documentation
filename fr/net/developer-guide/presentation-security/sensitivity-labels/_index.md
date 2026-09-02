---
title: Gestion des libellés de sensibilité dans les présentations PowerPoint en .NET
linktitle: Libellés de sensibilité
type: docs
weight: 50
url: /fr/net/sensitivity-labels/
keywords:
- libellé de sensibilité
- Microsoft Purview
- Microsoft Information Protection
- métadonnées MIP
- marquage de contenu
- protection de l'information
- gouvernance des documents
- PowerPoint
- PPTX
- sécurité des présentations
- .NET
- C#
- Aspose.Slides
description: "Lire, ajouter, mettre à jour, supprimer et migrer les libellés de sensibilité Microsoft Purview dans les présentations PowerPoint PPTX avec Aspose.Slides pour .NET."
---
## **Vue d'ensemble**

Les libellés de sensibilité Microsoft Purview aident les organisations à classer et à gérer les documents. Lors du traitement automatisé d’une présentation, une application peut devoir conserver un libellé existant, appliquer un libellé sélectionné par une stratégie, mettre à jour son état ou migrer les métadonnées de libellé écrites par un workflow Microsoft Information Protection (MIP) plus ancien.

Aspose.Slides expose les métadonnées modernes des libellés de sensibilité via [Presentation.SensitivityLabels](https://reference.aspose.com/slides/fr/net/aspose.slides/presentation/sensitivitylabels/). Cette propriété renvoie une [ISensitivityLabelCollection](https://reference.aspose.com/slides/fr/net/aspose.slides/isensitivitylabelcollection/) qui peut être inspectée et modifiée avant que la présentation ne soit enregistrée au format PPTX.

{{% alert color="primary" title="Remarque" %}}
Les identifiants des libellés de sensibilité et les informations de stratégie sont définis par votre configuration Microsoft Purview. Validez la disponibilité des libellés et les exigences de stratégie dans votre environnement avant d’ajouter ou de migrer les métadonnées. Les valeurs de [ISensitivityLabel.ContentMarkTypes](https://reference.aspose.com/slides/fr/net/aspose.slides/isensitivitylabel/contentmarktypes/) décrivent les marquages de contenu associés à un libellé ; elles n’ajoutent pas, à elles seules, de texte ou de formes visibles aux diapositives.
{{% /alert %}}

## **Comprendre les propriétés du libellé de sensibilité**

Chaque [ISensitivityLabel](https://reference.aspose.com/slides/fr/net/aspose.slides/isensitivitylabel/) contient les métadonnées suivantes :

| Propriété | Objectif |
| --- | --- |
| [ISensitivityLabel.Id](https://reference.aspose.com/slides/fr/net/aspose.slides/isensitivitylabel/id/) | Identifie le libellé de sensibilité dans la stratégie Purview. |
| [ISensitivityLabel.SiteId](https://reference.aspose.com/slides/fr/net/aspose.slides/isensitivitylabel/siteid/) | Identifie le site associé à la stratégie du libellé. |
| [ISensitivityLabel.IsEnabled](https://reference.aspose.com/slides/fr/net/aspose.slides/isensitivitylabel/isenabled/) | Indique si le libellé est activé. |
| [ISensitivityLabel.IsRemoved](https://reference.aspose.com/slides/fr/net/aspose.slides/isensitivitylabel/isremoved/) | Indique que le libellé a été supprimé. Définissez cette propriété sur `true` lorsque l’état de suppression doit être conservé dans les métadonnées. |
| [ISensitivityLabel.AssignmentMethodType](https://reference.aspose.com/slides/fr/net/aspose.slides/isensitivitylabel/assignmentmethodtype/) | Spécifie si le libellé a été appliqué automatiquement ou par décision de l’utilisateur. |
| [ISensitivityLabel.ContentMarkTypes](https://reference.aspose.com/slides/fr/net/aspose.slides/isensitivitylabel/contentmarktypes/) | Répertorie les types de marquage de contenu associés au libellé. |

L’énumération [SensitivityLabelAssignmentType](https://reference.aspose.com/slides/fr/net/aspose.slides/sensitivitylabelassignmenttype/) décrit comment un libellé a été attribué :

- [SensitivityLabelAssignmentType.Standard](https://reference.aspose.com/slides/fr/net/aspose.slides/sensitivitylabelassignmenttype/) représente un libellé par défaut ou appliqué automatiquement.  
- [SensitivityLabelAssignmentType.Privileged](https://reference.aspose.com/slides/fr/net/aspose.slides/sensitivitylabelassignmenttype/) représente un libellé appliqué par décision de l’utilisateur, incluant les libellés appliqués manuellement, recommandés et obligatoires.

L’énumération [SensitivityLabelContentType](https://reference.aspose.com/slides/fr/net/aspose.slides/sensitivitylabelcontenttype/) identifie le marquage associé à un libellé :

| Valeur | Signification |
| --- | --- |
| [SensitivityLabelContentType.None](https://reference.aspose.com/slides/fr/net/aspose.slides/sensitivitylabelcontenttype/) | Le libellé a été appliqué par défaut ou automatiquement. |
| [SensitivityLabelContentType.Header](https://reference.aspose.com/slides/fr/net/aspose.slides/sensitivitylabelcontenttype/) | Le marquage de contenu d’en‑tête est associé au libellé. |
| [SensitivityLabelContentType.Footer](https://reference.aspose.com/slides/fr/net/aspose.slides/sensitivitylabelcontenttype/) | Le marquage de contenu de pied de page est associé au libellé. |
| [SensitivityLabelContentType.Watermark](https://reference.aspose.com/slides/fr/net/aspose.slides/sensitivitylabelcontenttype/) | Le marquage de contenu de filigrane est associé au libellé. |
| [SensitivityLabelContentType.Encryption](https://reference.aspose.com/slides/fr/net/aspose.slides/sensitivitylabelcontenttype/) | La protection par chiffrement est associée au libellé. |

Plusieurs types de marquage peuvent être associés à un même libellé.

## **Lister les libellés de sensibilité existants**

Lisez la collection moderne de libellés via [Presentation.SensitivityLabels](https://reference.aspose.com/slides/fr/net/aspose.slides/presentation/sensitivitylabels/) et parcourez‑la. L’exemple suivant répertorie chaque propriété et chaque marquage de contenu stockés pour chaque libellé :

```csharp
using System;
using Aspose.Slides;

using var presentation = new Presentation("presentation.pptx");
var sensitivityLabels = presentation.SensitivityLabels;

foreach (var sensitivityLabel in sensitivityLabels)
{
    Console.WriteLine("Label ID: " + sensitivityLabel.Id);
    Console.WriteLine("Site ID: " + sensitivityLabel.SiteId);
    Console.WriteLine("Enabled: " + sensitivityLabel.IsEnabled);
    Console.WriteLine("Removed: " + sensitivityLabel.IsRemoved);
    Console.WriteLine("Assignment method: " + sensitivityLabel.AssignmentMethodType);

    foreach (var contentMarkType in sensitivityLabel.ContentMarkTypes)
    {
        Console.WriteLine("Content marking: " + contentMarkType);
    }
}
```

## **Ajouter un libellé de sensibilité avec marquage de contenu**

Utilisez [ISensitivityLabelCollection.Add](https://reference.aspose.com/slides/fr/net/aspose.slides/isensitivitylabelcollection/add/) avec l’identifiant du libellé, l’identifiant du site, l’état activé et la méthode d’attribution. Après que la méthode a renvoyé le nouvel [ISensitivityLabel](https://reference.aspose.com/slides/fr/net/aspose.slides/isensitivitylabel/), ajoutez les valeurs de marquage requises via [ISensitivityLabel.ContentMarkTypes](https://reference.aspose.com/slides/fr/net/aspose.slides/isensitivitylabel/contentmarktypes/).

L’exemple suivant ajoute un libellé sélectionné manuellement, associé aux marquages de pied de page et de filigrane, puis enregistre le résultat au format PPTX :

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("presentation.pptx");
var sensitivityLabels = presentation.SensitivityLabels;

var labelIdentifier = "{11111111-2222-3333-4444-555555555555}";
var siteIdentifier = Guid.Parse("{aaaaaaaa-bbbb-cccc-dddd-eeeeeeeeeeee}");
var isEnabled = true;
var assignmentMethod = SensitivityLabelAssignmentType.Privileged;

var sensitivityLabel = sensitivityLabels.Add(
    labelIdentifier,
    siteIdentifier,
    isEnabled,
    assignmentMethod);

sensitivityLabel.ContentMarkTypes.Add(SensitivityLabelContentType.Footer);
sensitivityLabel.ContentMarkTypes.Add(SensitivityLabelContentType.Watermark);

presentation.Save("presentation_with_label.pptx", SaveFormat.Pptx);
```

## **Mettre à jour un libellé de sensibilité**

Les propriétés de [ISensitivityLabel](https://reference.aspose.com/slides/fr/net/aspose.slides/isensitivitylabel/) sont en lecture/écriture, sauf que la collection renvoyée par [ISensitivityLabel.ContentMarkTypes](https://reference.aspose.com/slides/fr/net/aspose.slides/isensitivitylabel/contentmarktypes/) est modifiée via ses opérations de liste. Après avoir trouvé le libellé requis, vous pouvez mettre à jour son identifiant, son identifiant de site, son état activé, sa méthode d’attribution, son état de suppression et ses types de marquage de contenu. Enregistrez la présentation pour conserver les modifications.

L’exemple suivant met à jour l’état activé et la méthode d’attribution du premier libellé :

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("presentation.pptx");
var sensitivityLabels = presentation.SensitivityLabels;

if (sensitivityLabels.Count > 0)
{
    var sensitivityLabel = sensitivityLabels[0];
    sensitivityLabel.IsEnabled = true;
    sensitivityLabel.AssignmentMethodType = SensitivityLabelAssignmentType.Privileged;
}

presentation.Save("presentation_with_updated_label.pptx", SaveFormat.Pptx);
```

## **Marquer un libellé de sensibilité comme supprimé**

Pour conserver le fait qu’un libellé a été supprimé, trouvez le libellé et définissez [ISensitivityLabel.IsRemoved](https://reference.aspose.com/slides/fr/net/aspose.slides/isensitivitylabel/isremoved/) sur `true`. Cela conserve l’entrée du libellé tout en enregistrant son état de suppression. Si vous devez plutôt supprimer une entrée de la collection moderne, utilisez [ISensitivityLabelCollection.RemoveAt](https://reference.aspose.com/slides/fr/net/aspose.slides/isensitivitylabelcollection/removeat/) ; utilisez [ISensitivityLabelCollection.Clear](https://reference.aspose.com/slides/fr/net/aspose.slides/isensitivitylabelcollection/clear/) pour supprimer toutes les entrées.

L’exemple suivant marque un libellé précis comme supprimé et enregistre la présentation mise à jour :

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("presentation.pptx");
var sensitivityLabels = presentation.SensitivityLabels;
var targetLabelIdentifier = "{11111111-2222-3333-4444-555555555555}";

foreach (var sensitivityLabel in sensitivityLabels)
{
    var isTargetLabel = string.Equals(
        sensitivityLabel.Id,
        targetLabelIdentifier,
        StringComparison.OrdinalIgnoreCase);

    if (isTargetLabel)
    {
        sensitivityLabel.IsRemoved = true;
        break;
    }
}

presentation.Save("presentation_with_removed_label.pptx", SaveFormat.Pptx);
```

## **Lire et migrer les libellés de sensibilité MIP hérités**

Les workflows plus anciens basés sur MIP peuvent stocker les métadonnées des libellés de sensibilité dans des propriétés personnalisées du document au lieu de la collection moderne de libellés. Lisez ces métadonnées avec [IDocumentProperties.GetSensitivityLabels](https://reference.aspose.com/slides/fr/net/aspose.slides/idocumentproperties/getsensitivitylabels/). La méthode analyse les propriétés personnalisées héritées et renvoie un tableau d’objets [ISensitivityLabel](https://reference.aspose.com/slides/fr/net/aspose.slides/isensitivitylabel/).

Pour migrer les métadonnées, ajoutez chaque libellé renvoyé à la [ISensitivityLabelCollection](https://reference.aspose.com/slides/fr/net/aspose.slides/isensitivitylabelcollection/) moderne via [ISensitivityLabelCollection.Add](https://reference.aspose.com/slides/fr/net/aspose.slides/isensitivitylabelcollection/add/). Comme l’ajout d’un identifiant de libellé en double génère une exception, l’exemple vérifie la collection de destination avant de copier chaque libellé. Vous pouvez ajouter une validation supplémentaire pour confirmer que chaque libellé hérité existe toujours dans la stratégie Purview actuelle.

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("presentation_with_legacy_labels.pptx");
var legacySensitivityLabels = presentation.DocumentProperties.GetSensitivityLabels();
var modernSensitivityLabels = presentation.SensitivityLabels;

foreach (var legacySensitivityLabel in legacySensitivityLabels)
{
    var labelAlreadyExists = false;

    foreach (var modernSensitivityLabel in modernSensitivityLabels)
    {
        labelAlreadyExists = string.Equals(
            modernSensitivityLabel.Id,
            legacySensitivityLabel.Id,
            StringComparison.OrdinalIgnoreCase);

        if (labelAlreadyExists)
        {
            break;
        }
    }

    if (!labelAlreadyExists)
    {
        modernSensitivityLabels.Add(legacySensitivityLabel);
    }
}

presentation.Save("presentation_with_modern_labels.pptx", SaveFormat.Pptx);
```

La migration copie les objets de libellé analysés dans la collection moderne. Elle ne nécessite pas de supprimer toutes les propriétés personnalisées du document, de sorte que les métadonnées du document non liées restent intactes. Utilisez [IPresentation.Save](https://reference.aspose.com/slides/fr/net/aspose.slides/ipresentation/save/) avec [SaveFormat.Pptx](https://reference.aspose.com/slides/fr/net/aspose.slides.export/saveformat/) pour écrire les métadonnées modernes des libellés dans un fichier PPTX.

## **FAQ**

**L’ajout d’un type de marquage de contenu crée-t-il un en‑tête, un pied de page ou un filigrane visible sur les diapositives ?**

Non. Les valeurs ajoutées via [ISensitivityLabel.ContentMarkTypes](https://reference.aspose.com/slides/fr/net/aspose.slides/isensitivitylabel/contentmarktypes/) décrivent les marquages associés au libellé de sensibilité. Elles ne créent pas de texte ou de formes visibles dans la présentation. Ajoutez le contenu de diapositive correspondant séparément si votre workflow doit rendre ces marquages.

**Quelle est la différence entre marquer un libellé comme supprimé et le supprimer de la collection ?**

Définir [ISensitivityLabel.IsRemoved](https://reference.aspose.com/slides/fr/net/aspose.slides/isensitivitylabel/isremoved/) sur `true` conserve l’entrée du libellé et enregistre son état de suppression. Appeler [ISensitivityLabelCollection.RemoveAt](https://reference.aspose.com/slides/fr/net/aspose.slides/isensitivitylabelcollection/removeat/) supprime l’entrée de la collection moderne. Choisissez l’opération qui correspond aux exigences de conservation des métadonnées de votre organisation.

**Une présentation peut-elle contenir à la fois des métadonnées MIP héritées et des libellés de sensibilité modernes ?**

Oui. Les libellés hérités peuvent rester dans les propriétés personnalisées du document tandis que les libellés modernes sont disponibles via [Presentation.SensitivityLabels](https://reference.aspose.com/slides/fr/net/aspose.slides/presentation/sensitivitylabels/). Utilisez [IDocumentProperties.GetSensitivityLabels](https://reference.aspose.com/slides/fr/net/aspose.slides/idocumentproperties/getsensitivitylabels/) pour lire les métadonnées héritées et ne migrer que les libellés valides qui ne sont pas déjà présents dans la collection moderne.

**Que se passe-t-il lorsqu’un libellé avec le même identifiant est ajouté plusieurs fois ?**

[ISensitivityLabelCollection.Add](https://reference.aspose.com/slides/fr/net/aspose.slides/isensitivitylabelcollection/add/) lève une `ArgumentException` lorsque la collection contient déjà un libellé avec le même identifiant. Vérifiez les valeurs de [ISensitivityLabel.Id](https://reference.aspose.com/slides/fr/net/aspose.slides/isensitivitylabel/id/) existantes avant d’ajouter ou de migrer des libellés.

**Quel format de sortie doit être utilisé pour conserver les libellés de sensibilité mis à jour ?**

Enregistrez la présentation au format PPTX en appelant [IPresentation.Save](https://reference.aspose.com/slides/fr/net/aspose.slides/ipresentation/save/) avec [SaveFormat.Pptx](https://reference.aspose.com/slides/fr/net/aspose.slides.export/saveformat/), comme indiqué dans les exemples ci‑dessus.