---
title: Gérer les étiquettes de sensibilité dans les présentations PowerPoint en PHP
linktitle: Étiquettes de sensibilité
type: docs
weight: 50
url: /fr/php-java/sensitivity-labels/
keywords:
- étiquette de sensibilité
- Microsoft Purview
- Protection d'information Microsoft
- métadonnées MIP
- marquage de contenu
- protection de l'information
- gouvernance des documents
- PowerPoint
- PPTX
- sécurité des présentations
- PHP
- Aspose.Slides
description: "Lire, ajouter, mettre à jour, supprimer et migrer les étiquettes de sensibilité Microsoft Purview dans les présentations PPTX PowerPoint en PHP."
---
## **Vue d'ensemble**

Microsoft Purview sensitivity labels aident les organisations à classer et gouverner les documents. Lors du traitement automatisé des présentations, une application peut devoir conserver une étiquette existante, appliquer une étiquette sélectionnée par une politique, mettre à jour son état ou migrer les métadonnées d'étiquette écrites par un flux de travail Microsoft Information Protection (MIP) plus ancien.

Aspose.Slides for PHP via Java expose les métadonnées d'étiquettes de sensibilité modernes via [Presentation::getSensitivityLabels](https://reference.aspose.com/slides/fr/php-java/aspose.slides/presentation/#getSensitivityLabels). Cette méthode renvoie une [SensitivityLabelCollection](https://reference.aspose.com/slides/fr/php-java/aspose.slides/sensitivitylabelcollection/) qui peut être inspectée et modifiée avant que la présentation ne soit enregistrée au format PPTX.

{{% alert color="primary" title="Note" %}}
Les identifiants d'étiquette de sensibilité et les informations de politique sont définis par votre configuration Microsoft Purview. Validez la disponibilité des étiquettes et les exigences de la politique dans votre environnement avant d'ajouter ou de migrer des métadonnées. Les valeurs de [SensitivityLabel::getContentMarkTypes](https://reference.aspose.com/slides/fr/php-java/aspose.slides/sensitivitylabel/#getContentMarkTypes) décrivent les marquages de contenu associés à une étiquette ; elles n'ajoutent pas, à elles seules, de texte ou de formes visibles aux diapositives.
{{% /alert %}}

## **Comprendre les propriétés des étiquettes de sensibilité**

Chaque [SensitivityLabel](https://reference.aspose.com/slides/fr/php-java/aspose.slides/sensitivitylabel/) contient les métadonnées suivantes :

| Méthodes | Objectif |
| --- | --- |
| [SensitivityLabel::getId](https://reference.aspose.com/slides/fr/php-java/aspose.slides/sensitivitylabel/#getId) et [SensitivityLabel::setId](https://reference.aspose.com/slides/fr/php-java/aspose.slides/sensitivitylabel/#setId) | Obtenir ou définir l'identifiant de l'étiquette de sensibilité dans la politique Purview. |
| [SensitivityLabel::getSiteId](https://reference.aspose.com/slides/fr/php-java/aspose.slides/sensitivitylabel/#getSiteId) et [SensitivityLabel::setSiteId](https://reference.aspose.com/slides/fr/php-java/aspose.slides/sensitivitylabel/#setSiteId) | Obtenir ou définir le site associé à la politique d'étiquette. |
| [SensitivityLabel::isEnabled](https://reference.aspose.com/slides/fr/php-java/aspose.slides/sensitivitylabel/#isEnabled) et [SensitivityLabel::setEnabled](https://reference.aspose.com/slides/fr/php-java/aspose.slides/sensitivitylabel/#setEnabled) | Obtenir ou définir si l'étiquette est activée. |
| [SensitivityLabel::isRemoved](https://reference.aspose.com/slides/fr/php-java/aspose.slides/sensitivitylabel/#isRemoved) et [SensitivityLabel::setRemoved](https://reference.aspose.com/slides/fr/php-java/aspose.slides/sensitivitylabel/#setRemoved) | Obtenir ou définir si l'étiquette a été supprimée. Définissez la valeur sur `true` lorsque l'état de suppression doit être conservé dans les métadonnées. |
| [SensitivityLabel::getAssignmentMethodType](https://reference.aspose.com/slides/fr/php-java/aspose.slides/sensitivitylabel/#getAssignmentMethodType) et [SensitivityLabel::setAssignmentMethodType](https://reference.aspose.com/slides/fr/php-java/aspose.slides/sensitivitylabel/#setAssignmentMethodType) | Obtenir ou définir si l'étiquette a été appliquée automatiquement ou par une décision utilisateur. |
| [SensitivityLabel::getContentMarkTypes](https://reference.aspose.com/slides/fr/php-java/aspose.slides/sensitivitylabel/#getContentMarkTypes) | Obtenir les types de marquage de contenu associés à l'étiquette. |

La classe [SensitivityLabelAssignmentType](https://reference.aspose.com/slides/fr/php-java/aspose.slides/sensitivitylabelassignmenttype/) définit comment une étiquette a été attribuée :

- [SensitivityLabelAssignmentType::Standard](https://reference.aspose.com/slides/fr/php-java/aspose.slides/sensitivitylabelassignmenttype/) représente une étiquette par défaut ou appliquée automatiquement.
- [SensitivityLabelAssignmentType::Privileged](https://reference.aspose.com/slides/fr/php-java/aspose.slides/sensitivitylabelassignmenttype/) représente une étiquette appliquée via une décision utilisateur, incluant les étiquettes appliquées manuellement, recommandées et obligatoires.

La classe [SensitivityLabelContentType](https://reference.aspose.com/slides/fr/php-java/aspose.slides/sensitivitylabelcontenttype/) définit le marquage associé à une étiquette :

| Valeur | Signification |
| --- | --- |
| [SensitivityLabelContentType::None](https://reference.aspose.com/slides/fr/php-java/aspose.slides/sensitivitylabelcontenttype/) | L'étiquette a été appliquée par défaut ou automatiquement. |
| [SensitivityLabelContentType::Header](https://reference.aspose.com/slides/fr/php-java/aspose.slides/sensitivitylabelcontenttype/) | Le marquage de contenu d'en-tête est associé à l'étiquette. |
| [SensitivityLabelContentType::Footer](https://reference.aspose.com/slides/fr/php-java/aspose.slides/sensitivitylabelcontenttype/) | Le marquage de contenu de pied de page est associé à l'étiquette. |
| [SensitivityLabelContentType::Watermark](https://reference.aspose.com/slides/fr/php-java/aspose.slides/sensitivitylabelcontenttype/) | Le marquage de contenu de filigrane est associé à l'étiquette. |
| [SensitivityLabelContentType::Encryption](https://reference.aspose.com/slides/fr/php-java/aspose.slides/sensitivitylabelcontenttype/) | La protection de chiffrement est associée à l'étiquette. |

Plusieurs types de marquage peuvent être associés à une même étiquette.

## **Lister les étiquettes de sensibilité existantes**

Lire la collection d'étiquettes modernes à partir de [Presentation::getSensitivityLabels](https://reference.aspose.com/slides/fr/php-java/aspose.slides/presentation/#getSensitivityLabels) et l'énumérer. L'exemple suivant répertorie chaque propriété et chaque marquage de contenu stockés pour chaque étiquette :

```php
$presentation = new Presentation("presentation.pptx");
try {
    $sensitivityLabels = $presentation->getSensitivityLabels();
    $sensitivityLabelCount = java_values($sensitivityLabels->getCount());

    for ($labelIndex = 0; $labelIndex < $sensitivityLabelCount; $labelIndex++) {
        $sensitivityLabel = $sensitivityLabels->get_Item($labelIndex);

        echo "Label ID: " . java_values($sensitivityLabel->getId()) . PHP_EOL;
        echo "Site ID: " . java_values($sensitivityLabel->getSiteId()->toString()) . PHP_EOL;
        echo "Enabled: " . (java_values($sensitivityLabel->isEnabled()) ? "true" : "false") . PHP_EOL;
        echo "Removed: " . (java_values($sensitivityLabel->isRemoved()) ? "true" : "false") . PHP_EOL;
        echo "Assignment method: " . java_values($sensitivityLabel->getAssignmentMethodType()) . PHP_EOL;

        $contentMarkIterator = $sensitivityLabel->getContentMarkTypes()->iterator();
        while (java_values($contentMarkIterator->hasNext())) {
            $contentMarkType = java_values($contentMarkIterator->next());
            echo "Content marking: " . $contentMarkType . PHP_EOL;
        }
    }
} finally {
    $presentation->dispose();
}
```

## **Ajouter une étiquette de sensibilité avec marquage de contenu**

Utilisez [SensitivityLabelCollection::add](https://reference.aspose.com/slides/fr/php-java/aspose.slides/sensitivitylabelcollection/#add) avec l'identifiant de l'étiquette, l'identifiant du site, l'état activé et la méthode d'attribution. Après que la méthode ait renvoyé le nouveau [SensitivityLabel](https://reference.aspose.com/slides/fr/php-java/aspose.slides/sensitivitylabel/), ajoutez les valeurs de marquage requises via la liste renvoyée par [SensitivityLabel::getContentMarkTypes](https://reference.aspose.com/slides/fr/php-java/aspose.slides/sensitivitylabel/#getContentMarkTypes).

L'exemple suivant ajoute une étiquette sélectionnée manuellement associée aux marquages de pied de page et de filigrane, puis enregistre le résultat au format PPTX :

```php
$presentation = new Presentation("presentation.pptx");
try {
    $sensitivityLabels = $presentation->getSensitivityLabels();

    $labelIdentifier = "{11111111-2222-3333-4444-555555555555}";
    $UUID = new JavaClass("java.util.UUID");
    $siteIdentifier = $UUID->fromString("aaaaaaaa-bbbb-cccc-dddd-eeeeeeeeeeee");
    $isEnabled = true;
    $assignmentMethod = SensitivityLabelAssignmentType::Privileged;

    $sensitivityLabel = $sensitivityLabels->add(
        $labelIdentifier,
        $siteIdentifier,
        $isEnabled,
        $assignmentMethod
    );

    $contentMarkTypes = $sensitivityLabel->getContentMarkTypes();
    $contentMarkTypes->addItem(SensitivityLabelContentType::Footer);
    $contentMarkTypes->addItem(SensitivityLabelContentType::Watermark);

    $presentation->save("presentation_with_label.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Mettre à jour une étiquette de sensibilité**

Les valeurs de [SensitivityLabel](https://reference.aspose.com/slides/fr/php-java/aspose.slides/sensitivitylabel/) sont en lecture/écriture, sauf que la liste renvoyée par [SensitivityLabel::getContentMarkTypes](https://reference.aspose.com/slides/fr/php-java/aspose.slides/sensitivitylabel/#getContentMarkTypes) est modifiée via ses opérations de liste. Après avoir localisé l'étiquette requise, vous pouvez mettre à jour son identifiant, son identifiant de site, son état activé, sa méthode d'attribution, son état de suppression et ses types de marquage de contenu. Enregistrez la présentation pour conserver les modifications.

L'exemple suivant met à jour l'état activé et la méthode d'attribution de la première étiquette :

```php
$presentation = new Presentation("presentation.pptx");
try {
    $sensitivityLabels = $presentation->getSensitivityLabels();
    $sensitivityLabelCount = java_values($sensitivityLabels->getCount());

    if ($sensitivityLabelCount > 0) {
        $sensitivityLabel = $sensitivityLabels->get_Item(0);
        $sensitivityLabel->setEnabled(true);
        $sensitivityLabel->setAssignmentMethodType(SensitivityLabelAssignmentType::Privileged);
    }

    $presentation->save("presentation_with_updated_label.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Marquer une étiquette de sensibilité comme supprimée**

Pour conserver le fait qu'une étiquette a été supprimée, trouvez l'étiquette et appelez [SensitivityLabel::setRemoved](https://reference.aspose.com/slides/fr/php-java/aspose.slides/sensitivitylabel/#setRemoved) avec `true`. Cela conserve l'entrée d'étiquette tout en enregistrant son état de suppression. Si vous devez plutôt supprimer une entrée de la collection moderne, utilisez [SensitivityLabelCollection::removeAt](https://reference.aspose.com/slides/fr/php-java/aspose.slides/sensitivitylabelcollection/#removeAt) ; utilisez [SensitivityLabelCollection::clear](https://reference.aspose.com/slides/fr/php-java/aspose.slides/sensitivitylabelcollection/#clear) pour supprimer toutes les entrées.

L'exemple suivant marque une étiquette spécifique comme supprimée et enregistre la présentation mise à jour :

```php
$presentation = new Presentation("presentation.pptx");
try {
    $sensitivityLabels = $presentation->getSensitivityLabels();
    $targetLabelIdentifier = "{11111111-2222-3333-4444-555555555555}";
    $sensitivityLabelCount = java_values($sensitivityLabels->getCount());

    for ($labelIndex = 0; $labelIndex < $sensitivityLabelCount; $labelIndex++) {
        $sensitivityLabel = $sensitivityLabels->get_Item($labelIndex);
        $labelIdentifier = java_values($sensitivityLabel->getId());
        $isTargetLabel = strcasecmp($labelIdentifier, $targetLabelIdentifier) === 0;

        if ($isTargetLabel) {
            $sensitivityLabel->setRemoved(true);
            break;
        }
    }

    $presentation->save("presentation_with_removed_label.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Lire et migrer les anciennes étiquettes de sensibilité MIP**

Les flux de travail plus anciens basés sur MIP peuvent stocker les métadonnées d'étiquettes de sensibilité dans des propriétés de document personnalisées au lieu de la collection d'étiquettes moderne. Lisez ces métadonnées avec [DocumentProperties::getSensitivityLabels](https://reference.aspose.com/slides/fr/php-java/aspose.slides/documentproperties/#getSensitivityLabels). La méthode analyse les propriétés personnalisées héritées et renvoie un tableau Java d'objets [SensitivityLabel](https://reference.aspose.com/slides/fr/php-java/aspose.slides/sensitivitylabel/).

Pour migrer les métadonnées, ajoutez chaque étiquette renvoyée à la [SensitivityLabelCollection](https://reference.aspose.com/slides/fr/php-java/aspose.slides/sensitivitylabelcollection/) moderne via [SensitivityLabelCollection::add](https://reference.aspose.com/slides/fr/php-java/aspose.slides/sensitivitylabelcollection/#add). Étant donné que l'ajout d'un identifiant d'étiquette en double déclenche une exception, l'exemple vérifie la collection de destination avant de copier chaque étiquette. Vous pouvez ajouter une validation supplémentaire pour confirmer que chaque étiquette héritée existe toujours dans la politique Purview actuelle.

```php
$presentation = new Presentation("presentation_with_legacy_labels.pptx");
try {
    $legacySensitivityLabels = $presentation->getDocumentProperties()->getSensitivityLabels();
    $modernSensitivityLabels = $presentation->getSensitivityLabels();

    $Array = new JavaClass("java.lang.reflect.Array");
    $legacyLabelCount = java_values($Array->getLength($legacySensitivityLabels));

    for ($legacyLabelIndex = 0; $legacyLabelIndex < $legacyLabelCount; $legacyLabelIndex++) {
        $legacySensitivityLabel = $legacySensitivityLabels[$legacyLabelIndex];
        $legacyLabelIdentifier = java_values($legacySensitivityLabel->getId());
        $labelAlreadyExists = false;
        $modernLabelCount = java_values($modernSensitivityLabels->getCount());

        for ($modernLabelIndex = 0; $modernLabelIndex < $modernLabelCount; $modernLabelIndex++) {
            $modernSensitivityLabel = $modernSensitivityLabels->get_Item($modernLabelIndex);
            $modernLabelIdentifier = java_values($modernSensitivityLabel->getId());
            $labelAlreadyExists = strcasecmp(
                $modernLabelIdentifier,
                $legacyLabelIdentifier
            ) === 0;

            if ($labelAlreadyExists) {
                break;
            }
        }

        if (!$labelAlreadyExists) {
            $modernSensitivityLabels->add($legacySensitivityLabel);
        }
    }

    $presentation->save("presentation_with_modern_labels.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

La migration copie les objets d'étiquette analysés dans la collection moderne. Elle ne nécessite pas d'effacer toutes les propriétés de document personnalisées, de sorte que les métadonnées de document non liées restent intactes. Utilisez [Presentation::save](https://reference.aspose.com/slides/fr/php-java/aspose.slides/presentation/#save) avec [SaveFormat::Pptx](https://reference.aspose.com/slides/fr/php-java/aspose.slides/saveformat/) pour écrire les métadonnées d'étiquettes modernes dans un fichier PPTX.

## **FAQ**

**Est‑ce que l’ajout d’un type de marquage de contenu crée un en‑tête, un pied de page ou un filigrane visible sur les diapositives ?**

Non. Les valeurs ajoutées via la liste renvoyée par [SensitivityLabel::getContentMarkTypes](https://reference.aspose.com/slides/fr/php-java/aspose.slides/sensitivitylabel/#getContentMarkTypes) décrivent les marquages associés à l'étiquette de sensibilité. Elles ne créent pas de texte ou de formes visibles dans la présentation. Ajoutez le contenu de diapositive correspondant séparément si votre flux de travail doit rendre ces marquages.

**Quelle est la différence entre marquer une étiquette comme supprimée et la supprimer de la collection ?**

Appeler [SensitivityLabel::setRemoved](https://reference.aspose.com/slides/fr/php-java/aspose.slides/sensitivitylabel/#setRemoved) avec `true` conserve l'entrée d'étiquette et enregistre son état de suppression. Appeler [SensitivityLabelCollection::removeAt](https://reference.aspose.com/slides/fr/php-java/aspose.slides/sensitivitylabelcollection/#removeAt) supprime l'entrée de la collection moderne. Choisissez l'opération qui correspond aux exigences de rétention des métadonnées de votre organisation.

**Une présentation peut‑elle contenir à la fois des métadonnées MIP héritées et des étiquettes de sensibilité modernes ?**

Oui. Les étiquettes héritées peuvent rester dans les propriétés de document personnalisées tandis que les étiquettes modernes sont disponibles via [Presentation::getSensitivityLabels](https://reference.aspose.com/slides/fr/php-java/aspose.slides/presentation/#getSensitivityLabels). Utilisez [DocumentProperties::getSensitivityLabels](https://reference.aspose.com/slides/fr/php-java/aspose.slides/documentproperties/#getSensitivityLabels) pour lire les métadonnées héritées et migrer uniquement les étiquettes valides qui ne sont pas déjà présentes dans la collection moderne.

**Que se passe‑t‑il lorsqu’une étiquette avec le même identifiant est ajoutée plusieurs fois ?**

[SensitivityLabelCollection::add](https://reference.aspose.com/slides/fr/php-java/aspose.slides/sensitivitylabelcollection/#add) lève une exception lorsque la collection contient déjà une étiquette avec le même identifiant. Vérifiez les valeurs existantes renvoyées par [SensitivityLabel::getId](https://reference.aspose.com/slides/fr/php-java/aspose.slides/sensitivitylabel/#getId) avant d’ajouter ou de migrer des étiquettes.

**Quel format de sortie doit‑il être utilisé pour préserver les étiquettes de sensibilité mises à jour ?**

Enregistrez la présentation au format PPTX en appelant [Presentation::save](https://reference.aspose.com/slides/fr/php-java/aspose.slides/presentation/#save) avec [SaveFormat::Pptx](https://reference.aspose.com/slides/fr/php-java/aspose.slides/saveformat/), comme illustré dans les exemples ci‑dessus.