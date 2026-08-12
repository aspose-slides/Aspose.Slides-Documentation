---
title: Gérer les étiquettes de sensibilité dans les présentations PowerPoint en JavaScript
linktitle: Étiquettes de sensibilité
type: docs
weight: 50
url: /fr/nodejs-java/sensitivity-labels/
keywords:
- étiquette de sensibilité
- Microsoft Purview
- Microsoft Information Protection
- métadonnées MIP
- marquage de contenu
- protection de l’information
- gouvernance des documents
- PowerPoint
- PPTX
- sécurité des présentations
- Node.js
- JavaScript
- Aspose.Slides
description: "Lire, ajouter, mettre à jour, supprimer et migrer les étiquettes de sensibilité Microsoft Purview dans les présentations PowerPoint PPTX avec Aspose.Slides pour Node.js via Java."
---
## **Vue d'ensemble**

Microsoft Purview sensitivity labels aident les organisations à classifier et à gérer les documents. Lors du traitement automatisé de présentations, une application peut devoir conserver une étiquette existante, appliquer une étiquette sélectionnée par une stratégie, mettre à jour son état ou migrer les métadonnées d’étiquette écrites par un ancien workflow Microsoft Information Protection (MIP).

Aspose.Slides for Node.js via Java expose les métadonnées modernes d’étiquette de sensibilité via [Presentation.getSensitivityLabels](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/presentation/#getSensitivityLabels). Cette méthode renvoie une [SensitivityLabelCollection](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/sensitivitylabelcollection/) qui peut être inspectée et modifiée avant que la présentation ne soit enregistrée au format PPTX.

{{% alert color="primary" title="Remarque" %}}

Les identifiants d’étiquette de sensibilité et les informations de stratégie sont définis par votre configuration Microsoft Purview. Validez la disponibilité des étiquettes et les exigences de la stratégie dans votre environnement avant d’ajouter ou de migrer des métadonnées. Les valeurs de [SensitivityLabel.getContentMarkTypes](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/sensitivitylabel/#getContentMarkTypes) décrivent les marquages de contenu associés à une étiquette ; elles n’ajoutent pas, à elles seules, de texte ou de formes visibles aux diapositives.

{{% /alert %}}

## **Comprendre les propriétés des étiquettes de sensibilité**

Chaque [SensitivityLabel](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/sensitivitylabel/) contient les métadonnées suivantes :

| Méthodes | Objectif |
| --- | --- |
| [SensitivityLabel.getId](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/sensitivitylabel/#getId) et [SensitivityLabel.setId](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/sensitivitylabel/#setId) | Obtenir ou définir l’identifiant de l’étiquette de sensibilité dans la stratégie Purview. |
| [SensitivityLabel.getSiteId](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/sensitivitylabel/#getSiteId) et [SensitivityLabel.setSiteId](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/sensitivitylabel/#setSiteId) | Obtenir ou définir le site associé à la stratégie d’étiquette. |
| [SensitivityLabel.isEnabled](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/sensitivitylabel/#isEnabled) et [SensitivityLabel.setEnabled](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/sensitivitylabel/#setEnabled) | Obtenir ou définir si l’étiquette est activée. |
| [SensitivityLabel.isRemoved](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/sensitivitylabel/#isRemoved) et [SensitivityLabel.setRemoved](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/sensitivitylabel/#setRemoved) | Obtenir ou définir si l’étiquette a été supprimée. Définissez la valeur sur `true` lorsque l’état de suppression doit être conservé dans les métadonnées. |
| [SensitivityLabel.getAssignmentMethodType](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/sensitivitylabel/#getAssignmentMethodType) et [SensitivityLabel.setAssignmentMethodType](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/sensitivitylabel/#setAssignmentMethodType) | Obtenir ou définir si l’étiquette a été appliquée automatiquement ou par une décision utilisateur. |
| [SensitivityLabel.getContentMarkTypes](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/sensitivitylabel/#getContentMarkTypes) | Obtenir les types de marquage de contenu associés à l’étiquette. |

La classe [SensitivityLabelAssignmentType](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/sensitivitylabelassignmenttype/) définit comment une étiquette a été attribuée :

- [SensitivityLabelAssignmentType.Standard](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/sensitivitylabelassignmenttype/) représente une étiquette par défaut ou appliquée automatiquement.
- [SensitivityLabelAssignmentType.Privileged](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/sensitivitylabelassignmenttype/) représente une étiquette appliquée suite à une décision utilisateur, incluant les étiquettes appliquées manuellement, recommandées et obligatoires.

La classe [SensitivityLabelContentType](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/sensitivitylabelcontenttype/) définit le marquage associé à une étiquette :

| Valeur | Signification |
| --- | --- |
| [SensitivityLabelContentType.None](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/sensitivitylabelcontenttype/) | L’étiquette a été appliquée par défaut ou automatiquement. |
| [SensitivityLabelContentType.Header](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/sensitivitylabelcontenttype/) | Le marquage de contenu d’en‑tête est associé à l’étiquette. |
| [SensitivityLabelContentType.Footer](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/sensitivitylabelcontenttype/) | Le marquage de contenu de pied de page est associé à l’étiquette. |
| [SensitivityLabelContentType.Watermark](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/sensitivitylabelcontenttype/) | Le marquage de contenu de filigrane est associé à l’étiquette. |
| [SensitivityLabelContentType.Encryption](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/sensitivitylabelcontenttype/) | La protection par chiffrement est associée à l’étiquette. |

Plusieurs types de marquage peuvent être associés à une même étiquette.

## **Lister les étiquettes de sensibilité existantes**

Lisez la collection d’étiquettes modernes via [Presentation.getSensitivityLabels](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/presentation/#getSensitivityLabels) et parcourez‑la. L’exemple suivant répertorie chaque propriété et chaque marquage de contenu stockés pour chaque étiquette :

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    const sensitivityLabels = presentation.getSensitivityLabels();
    const labelCount = sensitivityLabels.getCount();

    for (let labelIndex = 0; labelIndex < labelCount; labelIndex++) {
        const sensitivityLabel = sensitivityLabels.get_Item(labelIndex);
        const labelIdentifier = sensitivityLabel.getId();
        const siteIdentifier = sensitivityLabel.getSiteId();
        const isEnabled = sensitivityLabel.isEnabled();
        const isRemoved = sensitivityLabel.isRemoved();
        const assignmentMethod = sensitivityLabel.getAssignmentMethodType();

        console.log("Label ID: " + labelIdentifier);
        console.log("Site ID: " + siteIdentifier);
        console.log("Enabled: " + isEnabled);
        console.log("Removed: " + isRemoved);
        console.log("Assignment method: " + assignmentMethod);

        const contentMarkTypes = sensitivityLabel.getContentMarkTypes();
        const contentMarkCount = contentMarkTypes.size();

        for (let contentMarkIndex = 0; contentMarkIndex < contentMarkCount; contentMarkIndex++) {
            const contentMarkType = contentMarkTypes.get_Item(contentMarkIndex);
            console.log("Content marking: " + contentMarkType);
        }
    }
} finally {
    presentation.dispose();
}
```

## **Ajouter une étiquette de sensibilité avec marquage de contenu**

Utilisez [SensitivityLabelCollection.add](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/sensitivitylabelcollection/#add) avec l’identifiant de l’étiquette, l’identifiant du site, l’état activé et la méthode d’attribution. Après le retour de la nouvelle [SensitivityLabel](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/sensitivitylabel/), ajoutez les valeurs de marquage requises via la liste renvoyée par [SensitivityLabel.getContentMarkTypes](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/sensitivitylabel/#getContentMarkTypes).

L’exemple suivant ajoute une étiquette sélectionnée manuellement, associée aux marquages de pied de page et de filigrane, puis enregistre le résultat au format PPTX :

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    const sensitivityLabels = presentation.getSensitivityLabels();

    const labelIdentifier = "{11111111-2222-3333-4444-555555555555}";
    const siteIdentifier = java.callStaticMethodSync(
        "java.util.UUID",
        "fromString",
        "aaaaaaaa-bbbb-cccc-dddd-eeeeeeeeeeee");
    const isEnabled = true;
    const assignmentMethod = aspose.slides.SensitivityLabelAssignmentType.Privileged;

    const sensitivityLabel = sensitivityLabels.add(
        labelIdentifier,
        siteIdentifier,
        isEnabled,
        assignmentMethod);

    const contentMarkTypes = sensitivityLabel.getContentMarkTypes();
    contentMarkTypes.addItem(aspose.slides.SensitivityLabelContentType.Footer);
    contentMarkTypes.addItem(aspose.slides.SensitivityLabelContentType.Watermark);

    presentation.save("presentation_with_label.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Mettre à jour une étiquette de sensibilité**

Les valeurs de [SensitivityLabel](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/sensitivitylabel/) sont en lecture/écriture, sauf que la liste renvoyée par [SensitivityLabel.getContentMarkTypes](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/sensitivitylabel/#getContentMarkTypes) est modifiée via ses opérations de liste. Après avoir localisé l’étiquette requise, vous pouvez mettre à jour son identifiant, l’identifiant du site, l’état activé, la méthode d’attribution, l’état de suppression et les types de marquage de contenu. Enregistrez la présentation pour persister les modifications.

L’exemple suivant met à jour l’état activé et la méthode d’attribution de la première étiquette :

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    const sensitivityLabels = presentation.getSensitivityLabels();
    const labelCount = sensitivityLabels.getCount();

    if (labelCount > 0) {
        const sensitivityLabel = sensitivityLabels.get_Item(0);
        sensitivityLabel.setEnabled(true);
        sensitivityLabel.setAssignmentMethodType(
            aspose.slides.SensitivityLabelAssignmentType.Privileged);
    }

    presentation.save("presentation_with_updated_label.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Marquer une étiquette de sensibilité comme supprimée**

Pour conserver le fait qu’une étiquette a été supprimée, trouvez l’étiquette et appelez [SensitivityLabel.setRemoved](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/sensitivitylabel/#setRemoved) avec `true`. Cela conserve l’entrée de l’étiquette tout en enregistrant son état supprimé. Si vous devez plutôt supprimer une entrée de la collection moderne, utilisez [SensitivityLabelCollection.removeAt](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/sensitivitylabelcollection/#removeAt) ; utilisez [SensitivityLabelCollection.clear](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/sensitivitylabelcollection/#clear) pour supprimer toutes les entrées.

L’exemple suivant marque une étiquette spécifique comme supprimée et enregistre la présentation mise à jour :

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    const sensitivityLabels = presentation.getSensitivityLabels();
    const targetLabelIdentifier = "{11111111-2222-3333-4444-555555555555}";
    const labelCount = sensitivityLabels.getCount();

    for (let labelIndex = 0; labelIndex < labelCount; labelIndex++) {
        const sensitivityLabel = sensitivityLabels.get_Item(labelIndex);
        const labelIdentifier = sensitivityLabel.getId();
        const isTargetLabel = labelIdentifier.toLowerCase() === targetLabelIdentifier.toLowerCase();

        if (isTargetLabel) {
            sensitivityLabel.setRemoved(true);
            break;
        }
    }

    presentation.save("presentation_with_removed_label.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Lire et migrer les anciennes étiquettes de sensibilité MIP**

Les anciens workflows basés sur MIP peuvent stocker les métadonnées d’étiquette de sensibilité dans des propriétés personnalisées du document plutôt que dans la collection d’étiquettes moderne. Lisez ces métadonnées avec [DocumentProperties.getSensitivityLabels](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/documentproperties/#getSensitivityLabels). La méthode analyse les propriétés personnalisées héritées et renvoie un tableau d’objets [SensitivityLabel](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/sensitivitylabel/).

Pour migrer les métadonnées, ajoutez chaque étiquette renvoyée à la [SensitivityLabelCollection](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/sensitivitylabelcollection/) moderne via [SensitivityLabelCollection.add](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/sensitivitylabelcollection/#add). Comme l’ajout d’un identifiant d’étiquette en double lève une exception, l’exemple vérifie la collection de destination avant de copier chaque étiquette. Vous pouvez ajouter une validation supplémentaire pour confirmer que chaque étiquette héritée existe toujours dans la stratégie Purview actuelle.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation("presentation_with_legacy_labels.pptx");
try {
    const legacySensitivityLabels = presentation.getDocumentProperties().getSensitivityLabels();
    const modernSensitivityLabels = presentation.getSensitivityLabels();

    for (let legacyLabelIndex = 0; legacyLabelIndex < legacySensitivityLabels.length; legacyLabelIndex++) {
        const legacySensitivityLabel = legacySensitivityLabels[legacyLabelIndex];
        const legacyLabelIdentifier = legacySensitivityLabel.getId();
        const modernLabelCount = modernSensitivityLabels.getCount();
        let labelAlreadyExists = false;

        for (let modernLabelIndex = 0; modernLabelIndex < modernLabelCount; modernLabelIndex++) {
            const modernSensitivityLabel = modernSensitivityLabels.get_Item(modernLabelIndex);
            const modernLabelIdentifier = modernSensitivityLabel.getId();

            labelAlreadyExists =
                modernLabelIdentifier.toLowerCase() === legacyLabelIdentifier.toLowerCase();

            if (labelAlreadyExists) {
                break;
            }
        }

        if (!labelAlreadyExists) {
            modernSensitivityLabels.add(legacySensitivityLabel);
        }
    }

    presentation.save("presentation_with_modern_labels.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

La migration copie les objets d’étiquette analysés dans la collection moderne. Elle ne nécessite pas de vider toutes les propriétés personnalisées du document, de sorte que les métadonnées du document non liées restent intactes. Utilisez [Presentation.save](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/presentation/#save) avec [SaveFormat.Pptx](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/saveformat/) pour écrire les métadonnées d’étiquettes modernes dans un fichier PPTX.

## **FAQ**

**L'ajout d'un type de marquage de contenu crée-t-il un en‑tête, un pied de page ou un filigrane visible sur les diapositives ?**

Non. Les valeurs ajoutées via la liste renvoyée par [SensitivityLabel.getContentMarkTypes](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/sensitivitylabel/#getContentMarkTypes) décrivent les marquages associés à l’étiquette de sensibilité. Elles ne créent pas de texte ou de formes visibles dans la présentation. Ajoutez séparément le contenu de diapositive correspondant si votre flux de travail doit les rendre visibles.

**Quelle est la différence entre marquer une étiquette comme supprimée et la supprimer de la collection ?**

Appeler [SensitivityLabel.setRemoved](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/sensitivitylabel/#setRemoved) avec `true` conserve l’entrée de l’étiquette et enregistre son état supprimé. Appeler [SensitivityLabelCollection.removeAt](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/sensitivitylabelcollection/#removeAt) supprime l’entrée de la collection moderne. Choisissez l’opération qui correspond aux exigences de rétention des métadonnées de votre organisation.

**Une présentation peut‑elle contenir à la fois des métadonnées MIP héritées et des étiquettes de sensibilité modernes ?**

Oui. Les anciennes étiquettes peuvent rester dans les propriétés personnalisées du document tandis que les étiquettes modernes sont accessibles via [Presentation.getSensitivityLabels](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/presentation/#getSensitivityLabels). Utilisez [DocumentProperties.getSensitivityLabels](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/documentproperties/#getSensitivityLabels) pour lire les métadonnées héritées et ne migrer que les étiquettes valides qui ne sont pas déjà présentes dans la collection moderne.

**Que se passe‑t‑il lorsqu’une étiquette portant le même identifiant est ajoutée plusieurs fois ?**

[SensitivityLabelCollection.add](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/sensitivitylabelcollection/#add) lève une exception lorsque la collection contient déjà une étiquette avec le même identifiant. Vérifiez les valeurs existantes renvoyées par [SensitivityLabel.getId](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/sensitivitylabel/#getId) avant d’ajouter ou de migrer des étiquettes.

**Quel format de sortie doit être utilisé pour conserver les étiquettes de sensibilité mises à jour ?**

Enregistrez la présentation au format PPTX en appelant [Presentation.save](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/presentation/#save) avec [SaveFormat.Pptx](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/saveformat/), comme illustré dans les exemples ci‑dessus.