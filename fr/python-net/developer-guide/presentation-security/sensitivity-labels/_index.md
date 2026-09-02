---
title: Gestion des libellés de sensibilité dans les présentations PowerPoint en Python
linktitle: Libellés de sensibilité
type: docs
weight: 50
url: /fr/python-net/sensitivity-labels/
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
- Python
- Aspose.Slides
description: "Lire, ajouter, mettre à jour, supprimer et migrer les libellés de sensibilité Microsoft Purview dans les présentations PowerPoint PPTX avec Aspose.Slides pour Python via .NET."
---
## **Aperçu**

Les libellés de sensibilité Microsoft Purview aident les organisations à classer et à gérer les documents. Lors du traitement automatisé d’une présentation, une application peut devoir conserver un libellé existant, appliquer un libellé sélectionné par une stratégie, mettre à jour son état ou migrer les métadonnées de libellé écrites par un flux de travail Microsoft Information Protection (MIP) plus ancien.

Aspose.Slides for Python via .NET expose les métadonnées modernes de libellés de sensibilité via [Presentation.sensitivity_labels](https://reference.aspose.com/slides/fr/python-net/aspose.slides/presentation/sensitivity_labels/). Cette propriété renvoie une [SensitivityLabelCollection](https://reference.aspose.com/slides/fr/python-net/aspose.slides/sensitivitylabelcollection/) qui peut être inspectée et modifiée avant que la présentation soit enregistrée au format PPTX.

{{% alert color="primary" title="Note" %}}
Les identifiants de libellés de sensibilité et les informations de stratégie sont définis par votre configuration Microsoft Purview. Validez la disponibilité des libellés et les exigences de stratégie dans votre environnement avant d’ajouter ou de migrer les métadonnées. Les valeurs de [SensitivityLabel.content_mark_types](https://reference.aspose.com/slides/fr/python-net/aspose.slides/sensitivitylabel/content_mark_types/) décrivent les marquages de contenu associés à un libellé ; elles n’ajoutent pas elles‑mêmes de texte ou de formes visibles aux diapositives.
{{% /alert %}}

## **Comprendre les propriétés du libellé de sensibilité**

Chaque [SensitivityLabel](https://reference.aspose.com/slides/fr/python-net/aspose.slides/sensitivitylabel/) contient les métadonnées suivantes :

| Propriété | Objectif |
| --- | --- |
| [SensitivityLabel.id](https://reference.aspose.com/slides/fr/python-net/aspose.slides/sensitivitylabel/id/) | Identifie le libellé de sensibilité dans la stratégie Purview. |
| [SensitivityLabel.site_id](https://reference.aspose.com/slides/fr/python-net/aspose.slides/sensitivitylabel/site_id/) | Identifie le site associé à la stratégie du libellé. |
| [SensitivityLabel.is_enabled](https://reference.aspose.com/slides/fr/python-net/aspose.slides/sensitivitylabel/is_enabled/) | Indique si le libellé est activé. |
| [SensitivityLabel.is_removed](https://reference.aspose.com/slides/fr/python-net/aspose.slides/sensitivitylabel/is_removed/) | Indique que le libellé a été supprimé. Définissez cette propriété sur `True` lorsque l’état de suppression doit être conservé dans les métadonnées. |
| [SensitivityLabel.assignment_method_type](https://reference.aspose.com/slides/fr/python-net/aspose.slides/sensitivitylabel/assignment_method_type/) | Spécifie si le libellé a été appliqué automatiquement ou par décision d’un utilisateur. |
| [SensitivityLabel.content_mark_types](https://reference.aspose.com/slides/fr/python-net/aspose.slides/sensitivitylabel/content_mark_types/) | Liste les types de marquage de contenu associés au libellé. |

L’énumération [SensitivityLabelAssignmentType](https://reference.aspose.com/slides/fr/python-net/aspose.slides/sensitivitylabelassignmenttype/) décrit comment un libellé a été attribué :

- [SensitivityLabelAssignmentType.STANDARD](https://reference.aspose.com/slides/fr/python-net/aspose.slides/sensitivitylabelassignmenttype/) représente un libellé par défaut ou appliqué automatiquement.
- [SensitivityLabelAssignmentType.PRIVILEGED](https://reference.aspose.com/slides/fr/python-net/aspose.slides/sensitivitylabelassignmenttype/) représente un libellé appliqué par décision d’un utilisateur, incluant les libellés appliqués manuellement, recommandés et obligatoires.

L’énumération [SensitivityLabelContentType](https://reference.aspose.com/slides/fr/python-net/aspose.slides/sensitivitylabelcontenttype/) identifie le marquage associé à un libellé :

| Valeur | Signification |
| --- | --- |
| [SensitivityLabelContentType.NONE](https://reference.aspose.com/slides/fr/python-net/aspose.slides/sensitivitylabelcontenttype/) | Le libellé a été appliqué par défaut ou automatiquement. |
| [SensitivityLabelContentType.HEADER](https://reference.aspose.com/slides/fr/python-net/aspose.slides/sensitivitylabelcontenttype/) | Le marquage de contenu d’en‑tête est associé au libellé. |
| [SensitivityLabelContentType.FOOTER](https://reference.aspose.com/slides/fr/python-net/aspose.slides/sensitivitylabelcontenttype/) | Le marquage de contenu de pied‑de‑page est associé au libellé. |
| [SensitivityLabelContentType.WATERMARK](https://reference.aspose.com/slides/fr/python-net/aspose.slides/sensitivitylabelcontenttype/) | Le marquage de contenu de filigrane est associé au libellé. |
| [SensitivityLabelContentType.ENCRYPTION](https://reference.aspose.com/slides/fr/python-net/aspose.slides/sensitivitylabelcontenttype/) | La protection par chiffrement est associée au libellé. |

Plusieurs types de marquage peuvent être associés à un même libellé.

## **Lister les libellés de sensibilité existants**

Lisez la collection moderne de libellés depuis [Presentation.sensitivity_labels](https://reference.aspose.com/slides/fr/python-net/aspose.slides/presentation/sensitivity_labels/) et parcourez‑la. L’exemple suivant répertorie chaque propriété et marquage de contenu stockés pour chaque libellé :

```python
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    sensitivity_labels = presentation.sensitivity_labels

    for sensitivity_label in sensitivity_labels:
        print("Label ID:", sensitivity_label.id)
        print("Site ID:", sensitivity_label.site_id)
        print("Enabled:", sensitivity_label.is_enabled)
        print("Removed:", sensitivity_label.is_removed)
        print("Assignment method:", sensitivity_label.assignment_method_type)

        for content_mark_type in sensitivity_label.content_mark_types:
            print("Content marking:", content_mark_type)
```

## **Ajouter un libellé de sensibilité avec marquage de contenu**

Utilisez [SensitivityLabelCollection.add](https://reference.aspose.com/slides/fr/python-net/aspose.slides/sensitivitylabelcollection/add/) avec l’identifiant du libellé, l’identifiant du site, l’état d’activation et la méthode d’attribution. Passez l’identifiant du site en tant qu’objet Python `uuid.UUID`. Après que la méthode a renvoyé le nouveau [SensitivityLabel](https://reference.aspose.com/slides/fr/python-net/aspose.slides/sensitivitylabel/), ajoutez les valeurs de marquage requises à [SensitivityLabel.content_mark_types](https://reference.aspose.com/slides/fr/python-net/aspose.slides/sensitivitylabel/content_mark_types/).

L’exemple suivant ajoute un libellé sélectionné manuellement associé aux marquages de pied‑de‑page et de filigrane, puis enregistre le résultat au format PPTX :

```python
import uuid
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    sensitivity_labels = presentation.sensitivity_labels

    label_identifier = "{11111111-2222-3333-4444-555555555555}"
    site_identifier = uuid.UUID("aaaaaaaa-bbbb-cccc-dddd-eeeeeeeeeeee")
    is_enabled = True
    assignment_method = slides.SensitivityLabelAssignmentType.PRIVILEGED

    sensitivity_label = sensitivity_labels.add(
        label_identifier,
        site_identifier,
        is_enabled,
        assignment_method
    )

    sensitivity_label.content_mark_types.append(slides.SensitivityLabelContentType.FOOTER)
    sensitivity_label.content_mark_types.append(slides.SensitivityLabelContentType.WATERMARK)

    presentation.save("presentation_with_label.pptx", slides.export.SaveFormat.PPTX)
```

## **Mettre à jour un libellé de sensibilité**

Les propriétés du [SensitivityLabel](https://reference.aspose.com/slides/fr/python-net/aspose.slides/sensitivitylabel/) sont en lecture/écriture, sauf que la liste renvoyée par [SensitivityLabel.content_mark_types](https://reference.aspose.com/slides/fr/python-net/aspose.slides/sensitivitylabel/content_mark_types/) est modifiée via ses opérations de liste. Après avoir localisé le libellé requis, vous pouvez mettre à jour son identifiant, l’identifiant du site, l’état d’activation, la méthode d’attribution, l’état de suppression et les types de marquage de contenu. Enregistrez la présentation pour conserver les modifications.

L’exemple suivant met à jour l’état d’activation et la méthode d’attribution du premier libellé :

```python
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    sensitivity_labels = presentation.sensitivity_labels

    if sensitivity_labels.count > 0:
        sensitivity_label = sensitivity_labels[0]
        sensitivity_label.is_enabled = True
        sensitivity_label.assignment_method_type = (
            slides.SensitivityLabelAssignmentType.PRIVILEGED
        )

    presentation.save("presentation_with_updated_label.pptx", slides.export.SaveFormat.PPTX)
```

## **Marquer un libellé de sensibilité comme supprimé**

Pour conserver le fait qu’un libellé a été supprimé, trouvez le libellé et définissez [SensitivityLabel.is_removed](https://reference.aspose.com/slides/fr/python-net/aspose.slides/sensitivitylabel/is_removed/) sur `True`. Cela conserve l’entrée du libellé tout en enregistrant son état de suppression. Si vous devez plutôt supprimer une entrée de la collection moderne, utilisez [SensitivityLabelCollection.remove_at](https://reference.aspose.com/slides/fr/python-net/aspose.slides/sensitivitylabelcollection/remove_at/); utilisez [SensitivityLabelCollection.clear](https://reference.aspose.com/slides/fr/python-net/aspose.slides/sensitivitylabelcollection/clear/) pour supprimer toutes les entrées.

L’exemple suivant marque un libellé spécifique comme supprimé et enregistre la présentation mise à jour :

```python
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    sensitivity_labels = presentation.sensitivity_labels
    target_label_identifier = "{11111111-2222-3333-4444-555555555555}"

    for sensitivity_label in sensitivity_labels:
        identifiers_match = (
            sensitivity_label.id.casefold() == target_label_identifier.casefold()
        )

        if identifiers_match:
            sensitivity_label.is_removed = True
            break

    presentation.save("presentation_with_removed_label.pptx", slides.export.SaveFormat.PPTX)
```

## **Lire et migrer les libellés de sensibilité MIP hérités**

Les anciens flux de travail basés sur MIP peuvent stocker les métadonnées de libellés de sensibilité dans des propriétés de document personnalisées au lieu de la collection moderne de libellés. Lisez ces métadonnées avec [DocumentProperties.get_sensitivity_labels](https://reference.aspose.com/slides/fr/python-net/aspose.slides/documentproperties/get_sensitivity_labels/). La méthode analyse les propriétés personnalisées héritées et renvoie des objets [SensitivityLabel](https://reference.aspose.com/slides/fr/python-net/aspose.slides/sensitivitylabel/).

Pour migrer les métadonnées, ajoutez chaque libellé renvoyé à la [SensitivityLabelCollection](https://reference.aspose.com/slides/fr/python-net/aspose.slides/sensitivitylabelcollection/) moderne via [SensitivityLabelCollection.add](https://reference.aspose.com/slides/fr/python-net/aspose.slides/sensitivitylabelcollection/add/). Comme l’ajout d’un identifiant de libellé en double lève une exception, l’exemple vérifie la collection de destination avant de copier chaque libellé. Vous pouvez ajouter une validation supplémentaire pour confirmer que chaque libellé hérité existe toujours dans la stratégie Purview actuelle.

```python
import aspose.slides as slides

with slides.Presentation("presentation_with_legacy_labels.pptx") as presentation:
    legacy_sensitivity_labels = (
        presentation.document_properties.get_sensitivity_labels()
    )
    modern_sensitivity_labels = presentation.sensitivity_labels

    for legacy_sensitivity_label in legacy_sensitivity_labels:
        label_already_exists = False

        for modern_sensitivity_label in modern_sensitivity_labels:
            label_already_exists = (
                modern_sensitivity_label.id.casefold()
                == legacy_sensitivity_label.id.casefold()
            )

            if label_already_exists:
                break

        if not label_already_exists:
            modern_sensitivity_labels.add(legacy_sensitivity_label)

    presentation.save("presentation_with_modern_labels.pptx", slides.export.SaveFormat.PPTX)
```

La migration copie les objets de libellé analysés dans la collection moderne. Elle ne nécessite pas d’effacer toutes les propriétés personnalisées du document, de sorte que les métadonnées du document non liées restent intactes. Utilisez [Presentation.save](https://reference.aspose.com/slides/fr/python-net/aspose.slides/presentation/save/) avec [SaveFormat.PPTX](https://reference.aspose.com/slides/fr/python-net/aspose.slides.export/saveformat/) pour écrire les métadonnées modernes du libellé dans un fichier PPTX.

## **FAQ**

**L’ajout d’un type de marquage de contenu crée‑t‑il un en‑tête, un pied‑de‑page ou un filigrane visible sur les diapositives ?**

Non. Les valeurs ajoutées via [SensitivityLabel.content_mark_types](https://reference.aspose.com/slides/fr/python-net/aspose.slides/sensitivitylabel/content_mark_types/) décrivent les marquages associés au libellé de sensibilité. Elles ne créent pas de texte ou de formes visibles dans la présentation. Ajoutez séparément le contenu de diapositive correspondant si votre flux de travail doit rendre ces marquages.

**Quelle est la différence entre marquer un libellé comme supprimé et le supprimer de la collection ?**

Définir [SensitivityLabel.is_removed](https://reference.aspose.com/slides/fr/python-net/aspose.slides/sensitivitylabel/is_removed/) sur `True` conserve l’entrée du libellé et enregistre son état de suppression. Appeler [SensitivityLabelCollection.remove_at](https://reference.aspose.com/slides/fr/python-net/aspose.slides/sensitivitylabelcollection/remove_at/) supprime l’entrée de la collection moderne. Choisissez l’opération qui correspond aux exigences de conservation des métadonnées de votre organisation.

**Une présentation peut‑elle contenir à la fois des métadonnées MIP héritées et des libellés de sensibilité modernes ?**

Oui. Les libellés hérités peuvent demeurer dans les propriétés personnalisées du document tandis que les libellés modernes sont accessibles via [Presentation.sensitivity_labels](https://reference.aspose.com/slides/fr/python-net/aspose.slides/presentation/sensitivity_labels/). Utilisez [DocumentProperties.get_sensitivity_labels](https://reference.aspose.com/slides/fr/python-net/aspose.slides/documentproperties/get_sensitivity_labels/) pour lire les métadonnées héritées et ne migrer que les libellés valides qui ne sont pas déjà présents dans la collection moderne.

**Que se passe‑t‑il lorsqu’un libellé avec le même identifiant est ajouté plusieurs fois ?**

[SensitivityLabelCollection.add](https://reference.aspose.com/slides/fr/python-net/aspose.slides/sensitivitylabelcollection/add/) lève une exception lorsque la collection contient déjà un libellé avec le même identifiant. Vérifiez les valeurs existantes de [SensitivityLabel.id](https://reference.aspose.com/slides/fr/python-net/aspose.slides/sensitivitylabel/id/) avant d’ajouter ou de migrer des libellés.

**Quel format de sortie doit être utilisé pour conserver les libellés de sensibilité mis à jour ?**

Enregistrez la présentation au format PPTX en appelant [Presentation.save](https://reference.aspose.com/slides/fr/python-net/aspose.slides/presentation/save/) avec [SaveFormat.PPTX](https://reference.aspose.com/slides/fr/python-net/aspose.slides.export/saveformat/), comme illustré dans les exemples ci‑dessus.