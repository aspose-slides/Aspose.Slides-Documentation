---
title: Gérer les étiquettes de sensibilité dans les présentations PowerPoint en Python
linktitle: Étiquettes de sensibilité
type: docs
weight: 50
url: /fr/python-java/sensitivity-labels/
keywords:
- étiquette de sensibilité
- Microsoft Purview
- Microsoft Information Protection
- métadonnées MIP
- marquage de contenu
- protection de l'information
- gouvernance de documents
- PowerPoint
- PPTX
- sécurité des présentations
- Python
- Aspose.Slides
description: "Lire, ajouter, mettre à jour, supprimer et migrer les étiquettes de sensibilité Microsoft Purview dans les présentations PPTX PowerPoint avec Aspose.Slides pour Python via Java."
---
## **Vue d'ensemble**

Les étiquettes de sensibilité Microsoft Purview aident les organisations à classer et à gouverner les documents. Lors du traitement automatisé d’une présentation, une application peut devoir conserver une étiquette existante, appliquer une étiquette sélectionnée par une stratégie, mettre à jour son état ou migrer les métadonnées d’étiquette écrites par un flux de travail Microsoft Information Protection (MIP) plus ancien.

Aspose.Slides expose les métadonnées d’étiquette de sensibilité modernes via [Presentation.getSensitivityLabels](https://reference.aspose.com/slides/fr/python-java/aspose.slides/presentation/#getSensitivityLabels). Cette méthode renvoie une [SensitivityLabelCollection](https://reference.aspose.com/slides/fr/python-java/aspose.slides/sensitivitylabelcollection/) qui peut être inspectée et modifiée avant que la présentation ne soit enregistrée au format PPTX.

{{% alert color="info" title="Note" %}}
Les identifiants d’étiquette de sensibilité et les informations de stratégie sont définis par votre configuration Microsoft Purview. Validez la disponibilité des étiquettes et les exigences de stratégie dans votre environnement avant d’ajouter ou de migrer des métadonnées. Les valeurs de [SensitivityLabel.getContentMarkTypes](https://reference.aspose.com/slides/fr/python-java/aspose.slides/sensitivitylabel/#getContentMarkTypes) décrivent les marquages de contenu associés à une étiquette ; elles n’ajoutent pas, en elles-mêmes, de texte ou de formes visibles aux diapositives.
{{% /alert %}}

## **Comprendre les propriétés des étiquettes de sensibilité**

Chaque [SensitivityLabel](https://reference.aspose.com/slides/fr/python-java/aspose.slides/sensitivitylabel/) contient les métadonnées suivantes :

| Méthodes | Objectif |
| --- | --- |
| [getId](https://reference.aspose.com/slides/fr/python-java/aspose.slides/sensitivitylabel/#getId) et [setId](https://reference.aspose.com/slides/fr/python-java/aspose.slides/sensitivitylabel/#setId) | Obtenir ou définir l’identifiant de l’étiquette de sensibilité dans la stratégie Purview. |
| [getSiteId](https://reference.aspose.com/slides/fr/python-java/aspose.slides/sensitivitylabel/#getSiteId) et [setSiteId](https://reference.aspose.com/slides/fr/python-java/aspose.slides/sensitivitylabel/#setSiteId) | Obtenir ou définir le site associé à la stratégie d’étiquette. |
| [isEnabled](https://reference.aspose.com/slides/fr/python-java/aspose.slides/sensitivitylabel/#isEnabled) et [setEnabled](https://reference.aspose.com/slides/fr/python-java/aspose.slides/sensitivitylabel/#setEnabled) | Obtenir ou définir si l’étiquette est activée. |
| [isRemoved](https://reference.aspose.com/slides/fr/python-java/aspose.slides/sensitivitylabel/#isRemoved) et [setRemoved](https://reference.aspose.com/slides/fr/python-java/aspose.slides/sensitivitylabel/#setRemoved) | Obtenir ou définir si l’étiquette a été retirée. Définissez la valeur sur `True` lorsque l’état de retrait doit être conservé dans les métadonnées. |
| [getAssignmentMethodType](https://reference.aspose.com/slides/fr/python-java/aspose.slides/sensitivitylabel/#getAssignmentMethodType) et [setAssignmentMethodType](https://reference.aspose.com/slides/fr/python-java/aspose.slides/sensitivitylabel/#setAssignmentMethodType) | Obtenir ou définir si l’étiquette a été appliquée automatiquement ou par décision de l’utilisateur. |
| [getContentMarkTypes](https://reference.aspose.com/slides/fr/python-java/aspose.slides/sensitivitylabel/#getContentMarkTypes) | Obtenir les types de marquage de contenu associés à l’étiquette. |

La classe [SensitivityLabelAssignmentType](https://reference.aspose.com/slides/fr/python-java/aspose.slides/sensitivitylabelassignmenttype/) définit la manière dont une étiquette a été assignée :

- [Standard](https://reference.aspose.com/slides/fr/python-java/aspose.slides/sensitivitylabelassignmenttype/) représente une étiquette par défaut ou appliquée automatiquement.
- [Privileged](https://reference.aspose.com/slides/fr/python-java/aspose.slides/sensitivitylabelassignmenttype/) représente une étiquette appliquée par décision de l’utilisateur, y compris les étiquettes appliquées manuellement, recommandées et obligatoires.

La classe [SensitivityLabelContentType](https://reference.aspose.com/slides/fr/python-java/aspose.slides/sensitivitylabelcontenttype/) définit le marquage associé à une étiquette :

| Valeur | Signification |
| --- | --- |
| [None](https://reference.aspose.com/slides/fr/python-java/aspose.slides/sensitivitylabelcontenttype/) | L’étiquette a été appliquée par défaut ou automatiquement. |
| [Header](https://reference.aspose.com/slides/fr/python-java/aspose.slides/sensitivitylabelcontenttype/) | Un marquage de contenu d’en‑tête est associé à l’étiquette. |
| [Footer](https://reference.aspose.com/slides/fr/python-java/aspose.slides/sensitivitylabelcontenttype/) | Un marquage de contenu de pied‑de‑page est associé à l’étiquette. |
| [Watermark](https://reference.aspose.com/slides/fr/python-java/aspose.slides/sensitivitylabelcontenttype/) | Un marquage de contenu de filigrane est associé à l’étiquette. |
| [Encryption](https://reference.aspose.com/slides/fr/python-java/aspose.slides/sensitivitylabelcontenttype/) | Une protection par chiffrement est associée à l’étiquette. |

Plusieurs types de marquage peuvent être associés à une même étiquette.

## **Lister les étiquettes de sensibilité existantes**

Lisez la collection d’étiquettes modernes via [Presentation.getSensitivityLabels](https://reference.aspose.com/slides/fr/python-java/aspose.slides/presentation/#getSensitivityLabels) et énumérez‑les. L’exemple suivant répertorie chaque propriété et marquage de contenu stockés pour chaque étiquette :

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation("presentation.pptx")
try:
    sensitivity_labels = presentation.getSensitivityLabels()

    for sensitivity_label in sensitivity_labels:
        print("Label ID:", sensitivity_label.getId())
        print("Site ID:", sensitivity_label.getSiteId())
        print("Enabled:", sensitivity_label.isEnabled())
        print("Removed:", sensitivity_label.isRemoved())
        print("Assignment method:", sensitivity_label.getAssignmentMethodType())

        for content_mark_type in sensitivity_label.getContentMarkTypes():
            print("Content marking:", content_mark_type)
finally:
    presentation.dispose()
```

## **Ajouter une étiquette de sensibilité avec marquage de contenu**

Utilisez [SensitivityLabelCollection.add](https://reference.aspose.com/slides/fr/python-java/aspose.slides/sensitivitylabelcollection/#add) avec l’identifiant de l’étiquette, l’identifiant du site, l’état d’activation et la méthode d’assignation. Après le retour de la méthode, vous obtenez la nouvelle [SensitivityLabel](https://reference.aspose.com/slides/fr/python-java/aspose.slides/sensitivitylabel/); ajoutez les valeurs de marquage requises via la liste renvoyée par [SensitivityLabel.getContentMarkTypes](https://reference.aspose.com/slides/fr/python-java/aspose.slides/sensitivitylabel/#getContentMarkTypes).

L’exemple suivant ajoute une étiquette sélectionnée manuellement associée aux marquages de pied‑de‑page et de filigrane, puis enregistre le résultat au format PPTX :

```python
import jpile
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, SensitivityLabelAssignmentType, SensitivityLabelContentType
from java.util import UUID

presentation = Presentation("presentation.pptx")
try:
    sensitivity_labels = presentation.getSensitivityLabels()

    label_identifier = "{11111111-2222-3333-4444-555555555555}"
    site_identifier = UUID.fromString("aaaaaaaa-bbbb-cccc-dddd-eeeeeeeeeeee")
    is_enabled = True
    assignment_method = SensitivityLabelAssignmentType.Privileged

    sensitivity_label = sensitivity_labels.add(label_identifier, site_identifier, is_enabled, assignment_method)

    sensitivity_label.getContentMarkTypes().addItem(jpype.JInt(SensitivityLabelContentType.Footer))
    sensitivity_label.getContentMarkTypes().addItem(jpype.JInt(SensitivityLabelContentType.Watermark))

    presentation.save("presentation_with_label.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Mettre à jour une étiquette de sensibilité**

Les valeurs de [SensitivityLabel](https://reference.aspose.com/slides/fr/python-java/aspose.slides/sensitivitylabel/) sont en lecture/écriture, à l’exception de la liste renvoyée par [SensitivityLabel.getContentMarkTypes](https://reference.aspose.com/slides/fr/python-java/aspose.slides/sensitivitylabel/#getContentMarkTypes) qui est modifiée via ses opérations de liste. Après avoir localisé l’étiquette requise, vous pouvez mettre à jour son identifiant, son identifiant de site, son état d’activation, sa méthode d’assignation, son état de retrait et ses types de marquage de contenu. Enregistrez la présentation pour persister les modifications.

L’exemple suivant met à jour l’état d’activation et la méthode d’assignation de la première étiquette :

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, SensitivityLabelAssignmentType

presentation = Presentation("presentation.pptx")
try:
    sensitivity_labels = presentation.getSensitivityLabels()

    if sensitivity_labels.getCount() > 0:
        sensitivity_label = sensitivity_labels.get_Item(0)
        sensitivity_label.setEnabled(True)
        sensitivity_label.setAssignmentMethodType(SensitivityLabelAssignmentType.Privileged)

    presentation.save("presentation_with_updated_label.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Marquer une étiquette de sensibilité comme retirée**

Pour conserver le fait qu’une étiquette a été retirée, trouvez l’étiquette et appelez [SensitivityLabel.setRemoved](https://reference.aspose.com/slides/fr/python-java/aspose.slides/sensitivitylabel/#setRemoved) avec `True`. Cela conserve l’entrée d’étiquette tout en enregistrant son état retiré. Si vous devez plutôt supprimer une entrée de la collection moderne, utilisez [SensitivityLabelCollection.removeAt](https://reference.aspose.com/slides/fr/python-java/aspose.slides/sensitivitylabelcollection/#removeAt) ; utilisez [SensitivityLabelCollection.clear](https://reference.aspose.com/slides/fr/python-java/aspose.slides/sensitivitylabelcollection/#clear) pour supprimer toutes les entrées.

L’exemple suivant marque une étiquette spécifique comme retirée et enregistre la présentation mise à jour :

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("presentation.pptx")
try:
    sensitivity_labels = presentation.getSensitivityLabels()
    target_label_identifier = "{11111111-2222-3333-4444-555555555555}"

    for sensitivity_label in sensitivity_labels:
        is_target_label = str(sensitivity_label.getId()).casefold() == target_label_identifier.casefold()

        if is_target_label:
            sensitivity_label.setRemoved(True)
            break

    presentation.save("presentation_with_removed_label.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Lire et migrer les étiquettes de sensibilité MIP héritées**

Les flux de travail basés sur MIP plus anciens peuvent stocker les métadonnées d’étiquette de sensibilité dans les propriétés personnalisées du document au lieu de la collection d’étiquettes moderne. Lisez ces métadonnées avec [DocumentProperties.getSensitivityLabels](https://reference.aspose.com/slides/fr/python-java/aspose.slides/documentproperties/#getSensitivityLabels). La méthode analyse les propriétés personnalisées héritées et renvoie un tableau d’objets [SensitivityLabel](https://reference.aspose.com/slides/fr/python-java/aspose.slides/sensitivitylabel/).

Pour migrer les métadonnées, ajoutez chaque étiquette renvoyée à la collection moderne [SensitivityLabelCollection](https://reference.aspose.com/slides/fr/python-java/aspose.slides/sensitivitylabelcollection/) via [SensitivityLabelCollection.add](https://reference.aspose.com/slides/fr/python-java/aspose.slides/sensitivitylabelcollection/#add). Comme l’ajout d’un identifiant d’étiquette dupliqué lève une exception, l’exemple vérifie la collection de destination avant de copier chaque étiquette. Vous pouvez ajouter une validation supplémentaire pour confirmer que chaque étiquette héritée existe toujours dans la stratégie Purview actuelle.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("presentation_with_legacy_labels.pptx")
try:
    legacy_sensitivity_labels = presentation.getDocumentProperties().getSensitivityLabels()
    modern_sensitivity_labels = presentation.getSensitivityLabels()

    for legacy_sensitivity_label in legacy_sensitivity_labels:
        label_already_exists = False

        for modern_sensitivity_label in modern_sensitivity_labels:
            label_already_exists = str(modern_sensitivity_label.getId()).casefold() == str(legacy_sensitivity_label.getId()).casefold()

            if label_already_exists:
                break

        if not label_already_exists:
            modern_sensitivity_labels.add(legacy_sensitivity_label)

    presentation.save("presentation_with_modern_labels.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

La migration copie les objets d’étiquette analysés dans la collection moderne. Elle ne nécessite pas d’effacer toutes les propriétés personnalisées du document, de sorte que les métadonnées du document non liées restent intactes. Utilisez [Presentation.save](https://reference.aspose.com/slides/fr/python-java/aspose.slides/presentation/#save) avec [SaveFormat.Pptx](https://reference.aspose.com/slides/fr/python-java/aspose.slides/saveformat/) pour écrire les métadonnées d’étiquette modernes dans un fichier PPTX.

## **FAQ**

**L’ajout d’un type de marquage de contenu crée-t‑il un en‑tête, un pied‑de‑page ou un filigrane visible sur les diapositives ?**

Non. Les valeurs ajoutées via la liste renvoyée par [SensitivityLabel.getContentMarkTypes](https://reference.aspose.com/slides/fr/python-java/aspose.slides/sensitivitylabel/#getContentMarkTypes) décrivent les marquages associés à l’étiquette de sensibilité. Elles ne créent pas de texte ou de formes visibles dans la présentation. Ajoutez le contenu de diapositive correspondant séparément si votre flux de travail doit les rendre visibles.

**Quelle est la différence entre marquer une étiquette comme retirée et la supprimer de la collection ?**

Appeler [SensitivityLabel.setRemoved](https://reference.aspose.com/slides/fr/python-java/aspose.slides/sensitivitylabel/#setRemoved) avec `True` conserve l’entrée d’étiquette et enregistre son état retiré. Appeler [SensitivityLabelCollection.removeAt](https://reference.aspose.com/slides/fr/python-java/aspose.slides/sensitivitylabelcollection/#removeAt) supprime l’entrée de la collection moderne. Choisissez l’opération qui correspond aux exigences de conservation des métadonnées de votre organisation.

**Une présentation peut‑elle contenir à la fois des métadonnées MIP héritées et des étiquettes de sensibilité modernes ?**

Oui. Les étiquettes héritées peuvent rester dans les propriétés personnalisées du document tandis que les étiquettes modernes sont accessibles via [Presentation.getSensitivityLabels](https://reference.aspose.com/slides/fr/python-java/aspose.slides/presentation/#getSensitivityLabels). Utilisez [DocumentProperties.getSensitivityLabels](https://reference.aspose.com/slides/fr/python-java/aspose.slides/documentproperties/#getSensitivityLabels) pour lire les métadonnées héritées et migrer uniquement les étiquettes valides qui ne sont pas déjà présentes dans la collection moderne.

**Que se passe‑t‑il lorsqu’une étiquette avec le même identifiant est ajoutée plusieurs fois ?**

[SensitivityLabelCollection.add](https://reference.aspose.com/slides/fr/python-java/aspose.slides/sensitivitylabelcollection/#add) lève une exception lorsque la collection contient déjà une étiquette avec le même identifiant. Vérifiez les valeurs existantes renvoyées par [SensitivityLabel.getId](https://reference.aspose.com/slides/fr/python-java/aspose.slides/sensitivitylabel/#getId) avant d’ajouter ou de migrer des étiquettes.

**Quel format de sortie doit être utilisé pour conserver les étiquettes de sensibilité mises à jour ?**

Enregistrez la présentation au format PPTX en appelant [Presentation.save](https://reference.aspose.com/slides/fr/python-java/aspose.slides/presentation/#save) avec [SaveFormat.Pptx](https://reference.aspose.com/slides/fr/python-java/aspose.slides/saveformat/), comme illustré dans les exemples ci‑dessus.