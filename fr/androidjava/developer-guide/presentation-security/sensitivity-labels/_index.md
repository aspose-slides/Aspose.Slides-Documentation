---
title: Gérer les étiquettes de sensibilité dans les présentations PowerPoint sur Android
linktitle: Étiquettes de sensibilité
type: docs
weight: 50
url: /fr/androidjava/sensitivity-labels/
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
- Android
- Java
- Aspose.Slides
description: "Lire, ajouter, mettre à jour, supprimer et migrer les étiquettes de sensibilité Microsoft Purview dans les présentations PowerPoint PPTX avec Aspose.Slides pour Android via Java."
---
## **Vue d’ensemble**

Les étiquettes de sensibilité Microsoft Purview aident les organisations à classer et à gouverner les documents. Lors du traitement automatisé d’une présentation, une application peut devoir préserver une étiquette existante, appliquer une étiquette sélectionnée par une stratégie, mettre à jour son état ou migrer les métadonnées d’étiquette écrites par un ancien flux de travail Microsoft Information Protection (MIP).

Aspose.Slides for Android via Java expose les métadonnées modernes d’étiquettes de sensibilité via [IPresentation.getSensitivityLabels](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/ipresentation/#getSensitivityLabels--). Cette méthode renvoie une [ISensitivityLabelCollection](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/isensitivitylabelcollection/) qui peut être inspectée et modifiée avant que la présentation ne soit enregistrée au format PPTX.

{{% alert color="primary" title="Remarque" %}}

Les identifiants d’étiquette de sensibilité et les informations de stratégie sont définis par votre configuration Microsoft Purview. Validez la disponibilité des étiquettes et les exigences de stratégie dans votre environnement avant d’ajouter ou de migrer des métadonnées. Les valeurs de [ISensitivityLabel.getContentMarkTypes](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/isensitivitylabel/#getContentMarkTypes--) décrivent les marquages de contenu associés à une étiquette ; elles n’ajoutent pas elles‑-mêmes du texte ou des formes visibles aux diapositives.

{{% /alert %}}

## **Comprendre les propriétés des étiquettes de sensibilité**

Chaque [ISensitivityLabel](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/isensitivitylabel/) contient les métadonnées suivantes :

| Méthodes | Objectif |
| --- | --- |
| [ISensitivityLabel.getId](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/isensitivitylabel/#getId--) et [ISensitivityLabel.setId](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/isensitivitylabel/#setId-java.lang.String-) | Obtient ou définit l’identifiant de l’étiquette de sensibilité dans la stratégie Purview. |
| [ISensitivityLabel.getSiteId](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/isensitivitylabel/#getSiteId--) et [ISensitivityLabel.setSiteId](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/isensitivitylabel/#setSiteId-java.util.UUID-) | Obtient ou définit le site associé à la stratégie d’étiquette. |
| [ISensitivityLabel.isEnabled](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/isensitivitylabel/#isEnabled--) et [ISensitivityLabel.setEnabled](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/isensitivitylabel/#setEnabled-boolean-) | Obtient ou définit si l’étiquette est activée. |
| [ISensitivityLabel.isRemoved](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/isensitivitylabel/#isRemoved--) et [ISensitivityLabel.setRemoved](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/isensitivitylabel/#setRemoved-boolean-) | Obtient ou définit si l’étiquette a été supprimée. Définissez la valeur sur `true` lorsque l’état de suppression doit être conservé dans les métadonnées. |
| [ISensitivityLabel.getAssignmentMethodType](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/isensitivitylabel/#getAssignmentMethodType--) et [ISensitivityLabel.setAssignmentMethodType](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/isensitivitylabel/#setAssignmentMethodType-int-) | Obtient ou définit si l’étiquette a été appliquée automatiquement ou par une décision utilisateur. |
| [ISensitivityLabel.getContentMarkTypes](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/isensitivitylabel/#getContentMarkTypes--) | Obtient les types de marquage de contenu associés à l’étiquette. |

La classe [SensitivityLabelAssignmentType](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/sensitivitylabelassignmenttype/) définit comment une étiquette a été assignée :

- [SensitivityLabelAssignmentType.Standard](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/sensitivitylabelassignmenttype/) représente une étiquette par défaut ou appliquée automatiquement.
- [SensitivityLabelAssignmentType.Privileged](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/sensitivitylabelassignmenttype/) représente une étiquette appliquée par décision utilisateur, y compris les étiquettes appliquées manuellement, recommandées et obligatoires.

La classe [SensitivityLabelContentType](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/sensitivitylabelcontenttype/) définit le marquage associé à une étiquette :

| Valeur | Signification |
| --- | --- |
| [SensitivityLabelContentType.None](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/sensitivitylabelcontenttype/) | L’étiquette a été appliquée par défaut ou automatiquement. |
| [SensitivityLabelContentType.Header](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/sensitivitylabelcontenttype/) | Un marquage de contenu d’en‑tête est associé à l’étiquette. |
| [SensitivityLabelContentType.Footer](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/sensitivitylabelcontenttype/) | Un marquage de contenu de pied‑de‑page est associé à l’étiquette. |
| [SensitivityLabelContentType.Watermark](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/sensitivitylabelcontenttype/) | Un marquage de contenu de filigrane est associé à l’étiquette. |
| [SensitivityLabelContentType.Encryption](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/sensitivitylabelcontenttype/) | Une protection de chiffrement est associée à l’étiquette. |

Plusieurs types de marquage peuvent être associés à une même étiquette.

## **Lister les étiquettes de sensibilité existantes**

Lisez la collection d’étiquettes modernes via [IPresentation.getSensitivityLabels](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/ipresentation/#getSensitivityLabels--) et parcourez‑la. L’exemple suivant répertorie chaque propriété et chaque marquage de contenu stockés pour chaque étiquette :

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("presentation.pptx");
try {
    ISensitivityLabelCollection sensitivityLabels = presentation.getSensitivityLabels();

    for (ISensitivityLabel sensitivityLabel : sensitivityLabels) {
        System.out.println("Label ID: " + sensitivityLabel.getId());
        System.out.println("Site ID: " + sensitivityLabel.getSiteId());
        System.out.println("Enabled: " + sensitivityLabel.isEnabled());
        System.out.println("Removed: " + sensitivityLabel.isRemoved());
        System.out.println("Assignment method: " + sensitivityLabel.getAssignmentMethodType());

        for (Integer contentMarkType : sensitivityLabel.getContentMarkTypes()) {
            System.out.println("Content marking: " + contentMarkType);
        }
    }
} finally {
    presentation.dispose();
}
```

## **Ajouter une étiquette de sensibilité avec marquage de contenu**

Utilisez [ISensitivityLabelCollection.add](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/isensitivitylabelcollection/#add-java.lang.String-java.util.UUID-boolean-int-) avec l’identifiant de l’étiquette, l’identifiant du site, l’état activé et la méthode d’attribution. Après le retour de la nouvelle [ISensitivityLabel](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/isensitivitylabel/), ajoutez les valeurs de marquage requises via la liste renvoyée par [ISensitivityLabel.getContentMarkTypes](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/isensitivitylabel/#getContentMarkTypes--).

L’exemple suivant ajoute une étiquette sélectionnée manuellement, associée aux marquages de pied‑de‑page et de filigrane, puis enregistre le résultat au format PPTX :

```java
import com.aspose.slides.*;
import java.util.UUID;

Presentation presentation = new Presentation("presentation.pptx");
try {
    ISensitivityLabelCollection sensitivityLabels = presentation.getSensitivityLabels();

    String labelIdentifier = "{11111111-2222-3333-4444-555555555555}";
    UUID siteIdentifier = UUID.fromString("aaaaaaaa-bbbb-cccc-dddd-eeeeeeeeeeee");
    boolean isEnabled = true;
    int assignmentMethod = SensitivityLabelAssignmentType.Privileged;

    ISensitivityLabel sensitivityLabel = sensitivityLabels.add(
            labelIdentifier,
            siteIdentifier,
            isEnabled,
            assignmentMethod);

    sensitivityLabel.getContentMarkTypes().addItem(SensitivityLabelContentType.Footer);
    sensitivityLabel.getContentMarkTypes().addItem(SensitivityLabelContentType.Watermark);

    presentation.save("presentation_with_label.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Mettre à jour une étiquette de sensibilité**

Les valeurs de [ISensitivityLabel](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/isensitivitylabel/) sont en lecture‑écriture, sauf que la liste renvoyée par [ISensitivityLabel.getContentMarkTypes](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/isensitivitylabel/#getContentMarkTypes--) est modifiée via ses opérations de liste. Après avoir localisé l’étiquette requise, vous pouvez mettre à jour son identifiant, son identifiant de site, son état activé, sa méthode d’attribution, son état de suppression et ses types de marquage de contenu. Enregistrez la présentation pour persister les modifications.

L’exemple suivant met à jour l’état activé et la méthode d’attribution de la première étiquette :

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("presentation.pptx");
try {
    ISensitivityLabelCollection sensitivityLabels = presentation.getSensitivityLabels();

    if (sensitivityLabels.getCount() > 0) {
        ISensitivityLabel sensitivityLabel = sensitivityLabels.get_Item(0);
        sensitivityLabel.setEnabled(true);
        sensitivityLabel.setAssignmentMethodType(SensitivityLabelAssignmentType.Privileged);
    }

    presentation.save("presentation_with_updated_label.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Marquer une étiquette de sensibilité comme supprimée**

Pour conserver le fait qu’une étiquette a été supprimée, trouvez l’étiquette et appelez [ISensitivityLabel.setRemoved](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/isensitivitylabel/#setRemoved-boolean-) avec `true`. Cette opération conserve l’entrée de l’étiquette tout en enregistrant son état de suppression. Si vous devez plutôt supprimer une entrée de la collection moderne, utilisez [ISensitivityLabelCollection.removeAt](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/isensitivitylabelcollection/#removeAt-int-); utilisez [ISensitivityLabelCollection.clear](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/isensitivitylabelcollection/#clear--) pour effacer toutes les entrées.

L’exemple suivant marque une étiquette spécifique comme supprimée et enregistre la présentation mise à jour :

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("presentation.pptx");
try {
    ISensitivityLabelCollection sensitivityLabels = presentation.getSensitivityLabels();
    String targetLabelIdentifier = "{11111111-2222-3333-4444-555555555555}";

    for (ISensitivityLabel sensitivityLabel : sensitivityLabels) {
        boolean isTargetLabel = sensitivityLabel.getId().equalsIgnoreCase(targetLabelIdentifier);

        if (isTargetLabel) {
            sensitivityLabel.setRemoved(true);
            break;
        }
    }

    presentation.save("presentation_with_removed_label.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Lire et migrer les anciennes étiquettes de sensibilité MIP**

Les flux de travail basés sur MIP plus anciens peuvent stocker les métadonnées d’étiquette de sensibilité dans les propriétés de document personnalisées au lieu de la collection d’étiquettes moderne. Lisez ces métadonnées avec [IDocumentProperties.getSensitivityLabels](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/idocumentproperties/#getSensitivityLabels--). La méthode analyse les propriétés personnalisées héritées et renvoie un tableau d’objets [ISensitivityLabel](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/isensitivitylabel/).

Pour migrer les métadonnées, ajoutez chaque étiquette renvoyée à la [ISensitivityLabelCollection](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/isensitivitylabelcollection/) moderne via [ISensitivityLabelCollection.add](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/isensitivitylabelcollection/#add-com.aspose.slides.ISensitivityLabel-). Comme l’ajout d’un identifiant d’étiquette en double lève une exception, l’exemple vérifie la collection de destination avant de copier chaque étiquette. Vous pouvez ajouter une validation supplémentaire pour confirmer que chaque étiquette héritée existe toujours dans la stratégie Purview actuelle.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("presentation_with_legacy_labels.pptx");
try {
    ISensitivityLabel[] legacySensitivityLabels = presentation.getDocumentProperties().getSensitivityLabels();
    ISensitivityLabelCollection modernSensitivityLabels = presentation.getSensitivityLabels();

    for (ISensitivityLabel legacySensitivityLabel : legacySensitivityLabels) {
        boolean labelAlreadyExists = false;

        for (ISensitivityLabel modernSensitivityLabel : modernSensitivityLabels) {
            labelAlreadyExists = modernSensitivityLabel.getId().equalsIgnoreCase(
                    legacySensitivityLabel.getId());

            if (labelAlreadyExists) {
                break;
            }
        }

        if (!labelAlreadyExists) {
            modernSensitivityLabels.add(legacySensitivityLabel);
        }
    }

    presentation.save("presentation_with_modern_labels.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

La migration copie les objets d’étiquette analysés dans la collection moderne. Elle ne nécessite pas d’effacer toutes les propriétés de document personnalisées, de sorte que les métadonnées de document non liées restent intactes. Utilisez [IPresentation.save](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/ipresentation/#save-java.lang.String-int-) avec [SaveFormat.Pptx](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/saveformat/) pour écrire les métadonnées d’étiquette modernes dans un fichier PPTX.

## **FAQ**

**L’ajout d’un type de marquage de contenu crée‑t‑il un en‑tête, un pied‑de‑page ou un filigrane visible sur les diapositives ?**

Non. Les valeurs ajoutées via la liste renvoyée par [ISensitivityLabel.getContentMarkTypes](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/isensitivitylabel/#getContentMarkTypes--) décrivent les marquages associés à l’étiquette de sensibilité. Elles ne créent pas de texte ou de formes visibles dans la présentation. Ajoutez le contenu de diapositive correspondant séparément si votre flux de travail doit rendre ces marquages.

**Quelle est la différence entre marquer une étiquette comme supprimée et la supprimer de la collection ?**

Appeler [ISensitivityLabel.setRemoved](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/isensitivitylabel/#setRemoved-boolean-) avec `true` conserve l’entrée de l’étiquette et enregistre son état de suppression. Appeler [ISensitivityLabelCollection.removeAt](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/isensitivitylabelcollection/#removeAt-int-) supprime l’entrée de la collection moderne. Choisissez l’opération qui correspond aux exigences de conservation des métadonnées de votre organisation.

**Une présentation peut‑elle contenir à la fois des métadonnées MIP héritées et des étiquettes de sensibilité modernes ?**

Oui. Les étiquettes héritées peuvent rester dans les propriétés de document personnalisées tandis que les étiquettes modernes sont accessibles via [IPresentation.getSensitivityLabels](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/ipresentation/#getSensitivityLabels--). Utilisez [IDocumentProperties.getSensitivityLabels](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/idocumentproperties/#getSensitivityLabels--) pour lire les métadonnées héritées et migrer uniquement les étiquettes valides qui ne sont pas déjà présentes dans la collection moderne.

**Que se passe‑t‑il lorsqu’une étiquette avec le même identifiant est ajoutée plusieurs fois ?**

[ISensitivityLabelCollection.add](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/isensitivitylabelcollection/#add-java.lang.String-java.util.UUID-boolean-int-) lève une exception lorsque la collection contient déjà une étiquette avec le même identifiant. Vérifiez les valeurs existantes renvoyées par [ISensitivityLabel.getId](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/isensitivitylabel/#getId--) avant d’ajouter ou de migrer des étiquettes.

**Quel format de sortie faut‑il utiliser pour préserver les étiquettes de sensibilité mises à jour ?**

Enregistrez la présentation au format PPTX en appelant [IPresentation.save](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/ipresentation/#save-java.lang.String-int-) avec [SaveFormat.Pptx](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/saveformat/), comme illustré dans les exemples ci‑dessus.