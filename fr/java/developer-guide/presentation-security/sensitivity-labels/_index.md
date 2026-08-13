---
title: Gérer les libellés de sensibilité dans les présentations PowerPoint en Java
linktitle: Libellés de sensibilité
type: docs
weight: 50
url: /fr/java/sensitivity-labels/
keywords:
- libellé de sensibilité
- Microsoft Purview
- Microsoft Information Protection
- métadonnées MIP
- marquage de contenu
- protection de l'information
- gouvernance de documents
- PowerPoint
- PPTX
- sécurité des présentations
- Java
- Aspose.Slides
description: "Lire, ajouter, mettre à jour, supprimer et migrer les libellés de sensibilité Microsoft Purview dans les présentations PowerPoint PPTX avec Aspose.Slides pour Java."
---
## **Vue d'ensemble**

Microsoft Purview sensitivity labels aident les organisations à classer et à gérer les documents. Lors du traitement automatisé des présentations, une application peut devoir conserver un libellé existant, appliquer un libellé sélectionné par une stratégie, mettre à jour son état ou migrer les métadonnées de libellé écrites par un ancien flux de travail Microsoft Information Protection (MIP).

Aspose.Slides expose les métadonnées de libellés de sensibilité modernes via [IPresentation.getSensitivityLabels](https://reference.aspose.com/slides/fr/java/com.aspose.slides/ipresentation/#getSensitivityLabels--). Cette méthode renvoie une [ISensitivityLabelCollection](https://reference.aspose.com/slides/fr/java/com.aspose.slides/isensitivitylabelcollection/) qui peut être inspectée et modifiée avant que la présentation ne soit enregistrée au format PPTX.

{{% alert color="info" title="Note" %}}
Les identifiants des libellés de sensibilité et les informations de stratégie sont définis par votre configuration Microsoft Purview. Validez la disponibilité des libellés et les exigences de stratégie dans votre environnement avant d’ajouter ou de migrer des métadonnées. Les valeurs de [ISensitivityLabel.getContentMarkTypes](https://reference.aspose.com/slides/fr/java/com.aspose.slides/isensitivitylabel/#getContentMarkTypes--) décrivent les marquages de contenu associés à un libellé ; elles n’ajoutent pas, d’elles-mêmes, de texte visible ou de formes aux diapositives.
{{% /alert %}}

## **Comprendre les propriétés du libellé de sensibilité**

Chaque [ISensitivityLabel](https://reference.aspose.com/slides/fr/java/com.aspose.slides/isensitivitylabel/) contient les métadonnées suivantes :

| Méthodes | Objectif |
| --- | --- |
| [ISensitivityLabel.getId](https://reference.aspose.com/slides/fr/java/com.aspose.slides/isensitivitylabel/#getId--) et [ISensitivityLabel.setId](https://reference.aspose.com/slides/fr/java/com.aspose.slides/isensitivitylabel/#setId-java.lang.String-) | Obtenir ou définir l’identifiant du libellé de sensibilité dans la stratégie Purview. |
| [ISensitivityLabel.getSiteId](https://reference.aspose.com/slides/fr/java/com.aspose.slides/isensitivitylabel/#getSiteId--) et [ISensitivityLabel.setSiteId](https://reference.aspose.com/slides/fr/java/com.aspose.slides/isensitivitylabel/#setSiteId-java.util.UUID-) | Obtenir ou définir le site associé à la stratégie du libellé. |
| [ISensitivityLabel.isEnabled](https://reference.aspose.com/slides/fr/java/com.aspose.slides/isensitivitylabel/#isEnabled--) et [ISensitivityLabel.setEnabled](https://reference.aspose.com/slides/fr/java/com.aspose.slides/isensitivitylabel/#setEnabled-boolean-) | Obtenir ou définir si le libellé est activé. |
| [ISensitivityLabel.isRemoved](https://reference.aspose.com/slides/fr/java/com.aspose.slides/isensitivitylabel/#isRemoved--) et [ISensitivityLabel.setRemoved](https://reference.aspose.com/slides/fr/java/com.aspose.slides/isensitivitylabel/#setRemoved-boolean-) | Obtenir ou définir si le libellé a été supprimé. Définissez la valeur à `true` lorsque l’état de suppression doit être conservé dans les métadonnées. |
| [ISensitivityLabel.getAssignmentMethodType](https://reference.aspose.com/slides/fr/java/com.aspose.slides/isensitivitylabel/#getAssignmentMethodType--) et [ISensitivityLabel.setAssignmentMethodType](https://reference.aspose.com/slides/fr/java/com.aspose.slides/isensitivitylabel/#setAssignmentMethodType-int-) | Obtenir ou définir si le libellé a été appliqué automatiquement ou suite à une décision utilisateur. |
| [ISensitivityLabel.getContentMarkTypes](https://reference.aspose.com/slides/fr/java/com.aspose.slides/isensitivitylabel/#getContentMarkTypes--) | Obtenir les types de marquage de contenu associés au libellé. |

La classe [SensitivityLabelAssignmentType](https://reference.aspose.com/slides/fr/java/com.aspose.slides/sensitivitylabelassignmenttype/) définit comment un libellé a été assigné :

- [SensitivityLabelAssignmentType.Standard](https://reference.aspose.com/slides/fr/java/com.aspose.slides/sensitivitylabelassignmenttype/) représente un libellé par défaut ou appliqué automatiquement.
- [SensitivityLabelAssignmentType.Privileged](https://reference.aspose.com/slides/fr/java/com.aspose.slides/sensitivitylabelassignmenttype/) représente un libellé appliqué suite à une décision utilisateur, y compris les libellés appliqués manuellement, recommandés et obligatoires.

La classe [SensitivityLabelContentType](https://reference.aspose.com/slides/fr/java/com.aspose.slides/sensitivitylabelcontenttype/) définit le marquage associé à un libellé :

| Valeur | Signification |
| --- | --- |
| [SensitivityLabelContentType.None](https://reference.aspose.com/slides/fr/java/com.aspose.slides/sensitivitylabelcontenttype/) | Le libellé a été appliqué par défaut ou automatiquement. |
| [SensitivityLabelContentType.Header](https://reference.aspose.com/slides/fr/java/com.aspose.slides/sensitivitylabelcontenttype/) | Le marquage de contenu d’en‑tête est associé au libellé. |
| [SensitivityLabelContentType.Footer](https://reference.aspose.com/slides/fr/java/com.aspose.slides/sensitivitylabelcontenttype/) | Le marquage de contenu de pied de page est associé au libellé. |
| [SensitivityLabelContentType.Watermark](https://reference.aspose.com/slides/fr/java/com.aspose.slides/sensitivitylabelcontenttype/) | Le marquage de contenu de filigrane est associé au libellé. |
| [SensitivityLabelContentType.Encryption](https://reference.aspose.com/slides/fr/java/com.aspose.slides/sensitivitylabelcontenttype/) | La protection de chiffrement est associée au libellé. |

Plusieurs types de marquage peuvent être associés à un même libellé.

## **Lister les libellés de sensibilité existants**

Lisez la collection de libellés modernes via [IPresentation.getSensitivityLabels](https://reference.aspose.com/slides/fr/java/com.aspose.slides/ipresentation/#getSensitivityLabels--) et énumérez‑la. L’exemple suivant répertorie chaque propriété et chaque marquage de contenu stockés pour chaque libellé :

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

## **Ajouter un libellé de sensibilité avec marquage de contenu**

Utilisez [ISensitivityLabelCollection.add](https://reference.aspose.com/slides/fr/java/com.aspose.slides/isensitivitylabelcollection/#add-java.lang.String-java.util.UUID-boolean-int-) avec l’identifiant du libellé, l’identifiant du site, l’état d’activation et la méthode d’affectation. Après que la méthode ait renvoyé le nouveau [ISensitivityLabel](https://reference.aspose.com/slides/fr/java/com.aspose.slides/isensitivitylabel/), ajoutez les valeurs de marquage requises via la liste renvoyée par [ISensitivityLabel.getContentMarkTypes](https://reference.aspose.com/slides/fr/java/com.aspose.slides/isensitivitylabel/#getContentMarkTypes--).

L’exemple suivant ajoute un libellé sélectionné manuellement associé aux marquages de pied de page et de filigrane, puis enregistre le résultat au format PPTX :

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

## **Mettre à jour un libellé de sensibilité**

Les valeurs de [ISensitivityLabel](https://reference.aspose.com/slides/fr/java/com.aspose.slides/isensitivitylabel/) sont en lecture/écriture, sauf que la liste renvoyée par [ISensitivityLabel.getContentMarkTypes](https://reference.aspose.com/slides/fr/java/com.aspose.slides/isensitivitylabel/#getContentMarkTypes--) est modifiée via ses opérations de liste. Après avoir localisé le libellé requis, vous pouvez mettre à jour son identifiant, son identifiant de site, son état d’activation, sa méthode d’affectation, son état de suppression et ses types de marquage de contenu. Enregistrez la présentation pour persister les modifications.

L’exemple suivant met à jour l’état d’activation et la méthode d’affectation du premier libellé :

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

## **Marquer un libellé de sensibilité comme supprimé**

Pour conserver le fait qu’un libellé a été supprimé, trouvez le libellé et appelez [ISensitivityLabel.setRemoved](https://reference.aspose.com/slides/fr/java/com.aspose.slides/isensitivitylabel/#setRemoved-boolean-) avec `true`. Cela conserve l’entrée du libellé tout en enregistrant son état de suppression. Si vous devez plutôt supprimer une entrée de la collection moderne, utilisez [ISensitivityLabelCollection.removeAt](https://reference.aspose.com/slides/fr/java/com.aspose.slides/isensitivitylabelcollection/#removeAt-int-); utilisez [ISensitivityLabelCollection.clear](https://reference.aspose.com/slides/fr/java/com.aspose.slides/isensitivitylabelcollection/#clear--) pour supprimer toutes les entrées.

L’exemple suivant marque un libellé spécifique comme supprimé et enregistre la présentation mise à jour :

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

## **Lire et migrer les libellés de sensibilité MIP hérités**

Les anciens flux de travail basés sur MIP peuvent stocker les métadonnées de libellés de sensibilité dans des propriétés de document personnalisées plutôt que dans la collection de libellés moderne. Lisez ces métadonnées avec [IDocumentProperties.getSensitivityLabels](https://reference.aspose.com/slides/fr/java/com.aspose.slides/idocumentproperties/#getSensitivityLabels--). La méthode analyse les propriétés personnalisées héritées et renvoie un tableau d’objets [ISensitivityLabel](https://reference.aspose.com/slides/fr/java/com.aspose.slides/isensitivitylabel/).

Pour migrer les métadonnées, ajoutez chaque libellé renvoyé à la [ISensitivityLabelCollection](https://reference.aspose.com/slides/fr/java/com.aspose.slides/isensitivitylabelcollection/) moderne via [ISensitivityLabelCollection.add](https://reference.aspose.com/slides/fr/java/com.aspose.slides/isensitivitylabelcollection/#add-com.aspose.slides.ISensitivityLabel-). Comme l’ajout d’un identifiant de libellé en double déclenche une exception, l’exemple vérifie la collection de destination avant de copier chaque libellé. Vous pouvez ajouter une validation supplémentaire pour confirmer que chaque libellé hérité existe toujours dans la stratégie Purview actuelle.

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

La migration copie les objets de libellés analysés dans la collection moderne. Elle ne nécessite pas de nettoyer toutes les propriétés de document personnalisées, de sorte que les métadonnées de document non liées restent intactes. Utilisez [IPresentation.save](https://reference.aspose.com/slides/fr/java/com.aspose.slides/ipresentation/#save-java.lang.String-int-) avec [SaveFormat.Pptx](https://reference.aspose.com/slides/fr/java/com.aspose.slides/saveformat/) pour écrire les métadonnées de libellés modernes dans un fichier PPTX.

## **FAQ**

**L’ajout d’un type de marquage de contenu crée‑t‑il un en‑tête, un pied de page ou un filigrane visible sur les diapositives ?**

Non. Les valeurs ajoutées via la liste renvoyée par [ISensitivityLabel.getContentMarkTypes](https://reference.aspose.com/slides/fr/java/com.aspose.slides/isensitivitylabel/#getContentMarkTypes--) décrivent les marquages associés au libellé de sensibilité. Elles ne créent pas de texte ou de formes visibles dans la présentation. Ajoutez le contenu de diapositive correspondant séparément si votre flux de travail doit rendre ces marquages.

**Quelle est la différence entre marquer un libellé comme supprimé et le supprimer de la collection ?**

Appeler [ISensitivityLabel.setRemoved](https://reference.aspose.com/slides/fr/java/com.aspose.slides/isensitivitylabel/#setRemoved-boolean-) avec `true` conserve l’entrée du libellé et enregistre son état de suppression. Appeler [ISensitivityLabelCollection.removeAt](https://reference.aspose.com/slides/fr/java/com.aspose.slides/isensitivitylabelcollection/#removeAt-int-) supprime l’entrée de la collection moderne. Choisissez l’opération qui correspond aux exigences de conservation des métadonnées de votre organisation.

**Une présentation peut‑elle contenir à la fois des métadonnées MIP héritées et des libellés de sensibilité modernes ?**

Oui. Les libellés hérités peuvent rester dans les propriétés de document personnalisées tandis que les libellés modernes sont accessibles via [IPresentation.getSensitivityLabels](https://reference.aspose.com/slides/fr/java/com.aspose.slides/ipresentation/#getSensitivityLabels--). Utilisez [IDocumentProperties.getSensitivityLabels](https://reference.aspose.com/slides/fr/java/com.aspose.slides/idocumentproperties/#getSensitivityLabels--) pour lire les métadonnées héritées et ne migrer que les libellés valides qui ne sont pas déjà présents dans la collection moderne.

**Que se passe‑t‑il lorsqu’un libellé avec le même identifiant est ajouté plusieurs fois ?**

[ISensitivityLabelCollection.add](https://reference.aspose.com/slides/fr/java/com.aspose.slides/isensitivitylabelcollection/#add-java.lang.String-java.util.UUID-boolean-int-) lève une exception lorsque la collection contient déjà un libellé avec le même identifiant. Vérifiez les valeurs existantes renvoyées par [ISensitivityLabel.getId](https://reference.aspose.com/slides/fr/java/com.aspose.slides/isensitivitylabel/#getId--) avant d’ajouter ou de migrer des libellés.

**Quel format de sortie doit être utilisé pour conserver les libellés de sensibilité mis à jour ?**

Enregistrez la présentation au format PPTX en appelant [IPresentation.save](https://reference.aspose.com/slides/fr/java/com.aspose.slides/ipresentation/#save-java.lang.String-int-) avec [SaveFormat.Pptx](https://reference.aspose.com/slides/fr/java/com.aspose.slides/saveformat/), comme illustré dans les exemples ci‑dessus.