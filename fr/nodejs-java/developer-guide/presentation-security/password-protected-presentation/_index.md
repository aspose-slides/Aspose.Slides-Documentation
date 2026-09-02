---
title: Sécuriser les présentations avec des mots de passe en JavaScript
linktitle: Protection par mot de passe
type: docs
weight: 20
url: /fr/nodejs-java/password-protected-presentation/
keywords:
- verrouiller PowerPoint
- verrouiller la présentation
- déverrouiller PowerPoint
- déverrouiller la présentation
- protéger PowerPoint
- protéger la présentation
- définir un mot de passe
- ajouter un mot de passe
- chiffrer PowerPoint
- chiffrer la présentation
- déchiffrer PowerPoint
- déchiffrer la présentation
- protection en écriture
- sécurité PowerPoint
- sécurité de la présentation
- supprimer le mot de passe
- supprimer la protection
- supprimer le chiffrement
- désactiver le mot de passe
- désactiver la protection
- supprimer la protection en écriture
- PowerPoint
- OpenDocument
- présentation
- Node.js
- JavaScript
- Aspose.Slides
description: "Verrouillez et déverrouillez sans effort les présentations PowerPoint et OpenDocument protégées par mot de passe avec Aspose.Slides pour Node.js via Java. Sécurisez vos présentations."
---
## **Introduction**

Lorsque vous protégez une présentation par mot de passe, cela signifie que vous définissez un mot de passe qui impose certaines restrictions à la présentation. Pour supprimer les restrictions, le mot de passe doit être saisi. Une présentation protégée par mot de passe est considérée comme une présentation verrouillée.

Typiquement, vous pouvez définir un mot de passe pour appliquer ces restrictions à une présentation :

- **Modification**

  Si vous souhaitez que seuls certains utilisateurs puissent modifier votre présentation, vous pouvez définir une restriction de modification. Cette restriction empêche les personnes de modifier, changer ou copier des éléments de votre présentation (à moins de fournir le mot de passe).

  Cependant, dans ce cas, même sans le mot de passe, un utilisateur pourra accéder à votre document et l’ouvrir. En mode lecture seule, l’utilisateur peut visualiser le contenu ou les éléments — hyperliens, animations, effets, etc. — à l’intérieur de votre présentation, mais il ne peut ni copier d’éléments ni enregistrer la présentation.

- **Ouverture**

  Si vous souhaitez que seuls certains utilisateurs puissent ouvrir votre présentation, vous pouvez définir une restriction d’ouverture. Cette restriction empêche les personnes de voir le contenu de votre présentation (à moins de fournir le mot de passe).

  Techniquement, la restriction d’ouverture empêche également les utilisateurs de modifier vos présentations : lorsqu’une présentation ne peut pas être ouverte, elle ne peut pas être modifiée.

  **Remarque** que lorsque vous protégez une présentation par mot de passe pour empêcher l’ouverture, le fichier de présentation devient chiffré.

## **Comment protéger par mot de passe une présentation en ligne**

1. Allez à notre page [**Aspose.Slides Lock**](https://products.aspose.app/slides/fr/lock).

   ![todo:image_alt_text](slides-lock.png)

2. Cliquez sur **Drop or upload your files**.

3. Sélectionnez le fichier que vous souhaitez protéger par mot de passe sur votre ordinateur.

4. Saisissez le mot de passe de votre choix pour la protection en modification ; saisissez le mot de passe de votre choix pour la protection en visualisation.

5. Si vous souhaitez que les utilisateurs voient votre présentation comme la copie finale, cochez la case **Mark as final**.

6. Cliquez sur **PROTECT NOW.**

7. Cliquez sur **DOWNLOAD NOW.**

## **Protection par mot de passe des présentations dans Aspose.Slides**
**Formats pris en charge**

Aspose.Slides prend en charge la protection par mot de passe, le chiffrement et des opérations similaires pour les présentations dans ces formats :

- PPTX et PPT - Microsoft PowerPoint Presentation 
- ODP - OpenDocument Presentation 
- OTP - OpenDocument Presentation Template 

**Opérations prises en charge**

Aspose.Slides vous permet d’utiliser la protection par mot de passe sur les présentations afin d’empêcher les modifications de ces manières :

- Chiffrer une présentation
- Définir une protection en écriture sur une présentation

**Autres opérations**

Aspose.Slides vous permet d’exécuter d’autres tâches liées à la protection par mot de passe et au chiffrement de ces manières :

- Déchiffrer une présentation ; ouvrir une présentation chiffrée
- Supprimer le chiffrement ; désactiver la protection par mot de passe
- Supprimer la protection en écriture d’une présentation
- Obtenir les propriétés d’une présentation chiffrée
- Vérifier si une présentation est chiffrée
- Vérifier si une présentation est protégée par mot de passe.

## **Chiffrer une présentation**

Vous pouvez chiffrer une présentation en définissant un mot de passe. Ensuite, pour modifier la présentation verrouillée, l’utilisateur doit fournir le mot de passe.

Pour chiffrer ou protéger par mot de passe une présentation, vous devez utiliser la méthode encrypt (de [ProtectionManager](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/ProtectionManager)) afin de définir un mot de passe pour la présentation. Vous transmettez le mot de passe à la méthode encrypt et utilisez la méthode save pour enregistrer la présentation désormais chiffrée.

Ce code d’exemple montre comment chiffrer une présentation :

```javascript
var presentation = new aspose.slides.Presentation("pres.pptx");
try {
    presentation.getProtectionManager().encrypt("123123");
    presentation.save("encrypted-pres.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (presentation != null) {
        presentation.dispose();
    }
}
```

## **Définir la protection en écriture d’une présentation**

Vous pouvez ajouter une mention « Ne pas modifier » à une présentation. Ainsi, vous indiquez aux utilisateurs que vous ne voulez pas qu’ils modifient la présentation.

**Remarque** que le processus de protection en écriture ne chiffre pas la présentation. Par conséquent, les utilisateurs—s’ils le souhaitent réellement—peuvent modifier la présentation, mais pour enregistrer les modifications, ils devront créer une présentation sous un autre nom.

Pour définir une protection en écriture, vous devez utiliser la méthode [setWriteProtection](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/ProtectionManager#setWriteProtection-java.lang.String-). Ce code d’exemple montre comment appliquer une protection en écriture à une présentation :

```javascript
var presentation = new aspose.slides.Presentation("pres.pptx");
try {
    presentation.getProtectionManager().setWriteProtection("123123");
    presentation.save("write-protected-pres.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (presentation != null) {
        presentation.dispose();
    }
}
```

## **Déchiffrer une présentation ; ouvrir une présentation chiffrée**

Aspose.Slides vous permet de charger un fichier chiffré en transmettant son mot de passe. Pour déchiffrer une présentation, vous devez appeler la méthode [removeEncryption](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/ProtectionManager#removeEncryption--) sans paramètres. Vous devrez alors entrer le bon mot de passe pour charger la présentation.

Ce code d’exemple montre comment déchiffrer une présentation :

```javascript
var loadOptions = new aspose.slides.LoadOptions();
loadOptions.setPassword("123123");
var presentation = new aspose.slides.Presentation("pres.pptx", loadOptions);
try {
    // travailler avec la présentation déchiffrée
} finally {
    if (presentation != null) {
        presentation.dispose();
    }
}
```

## **Supprimer le chiffrement ; désactiver la protection par mot de passe**

Vous pouvez supprimer le chiffrement ou la protection par mot de passe d’une présentation. Ainsi, les utilisateurs peuvent accéder à la présentation ou la modifier sans restrictions.

Pour supprimer le chiffrement ou la protection par mot de passe, vous devez appeler la méthode [removeEncryption](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/ProtectionManager#removeEncryption--). Ce code d’exemple montre comment supprimer le chiffrement d’une présentation :

```javascript
var loadOptions = new aspose.slides.LoadOptions();
loadOptions.setPassword("123123");
var presentation = new aspose.slides.Presentation("pres.pptx", loadOptions);
try {
    presentation.getProtectionManager().removeEncryption();
    presentation.save("encryption-removed.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (presentation != null) {
        presentation.dispose();
    }
}
```

## **Supprimer la protection en écriture d’une présentation**

Vous pouvez utiliser Aspose.Slides pour supprimer la protection en écriture appliquée à un fichier de présentation. Ainsi, les utilisateurs peuvent modifier à leur guise—et ils n’obtiennent aucun avertissement lorsqu’ils effectuent ces actions.

Vous pouvez supprimer la protection en écriture d’une présentation en utilisant la méthode [removeWriteProtection](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/ProtectionManager#removeWriteProtection--). Ce code d’exemple montre comment supprimer la protection en écriture d’une présentation :

```javascript
var presentation = new aspose.slides.Presentation("pres.pptx");
try {
    presentation.getProtectionManager().removeWriteProtection();
    presentation.save("write-protection-removed.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (presentation != null) {
        presentation.dispose();
    }
}
```

## **Obtenir les propriétés d’une présentation chiffrée**

Typiquement, les utilisateurs rencontrent des difficultés pour récupérer les propriétés du document d’une présentation chiffrée ou protégée par mot de passe. Cependant, Aspose.Slides propose un mécanisme qui vous permet de protéger une présentation tout en conservant la possibilité pour les utilisateurs d’accéder à ses propriétés.

**Remarque :** Par défaut, lorsqu’Aspose.Slides chiffre une présentation, les propriétés du document de la présentation sont également protégées par mot de passe. Si vous devez rendre les propriétés du document accessibles même après le chiffrement, Aspose.Slides vous permet de le faire.

Si vous voulez que les utilisateurs conservent la possibilité d’accéder aux propriétés d’une présentation chiffrée, transmettez `false` à `setEncryptDocumentProperties` sur [ProtectionManager](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/protectionmanager/). Ce code d’exemple montre comment chiffrer une présentation tout en offrant aux utilisateurs l’accès à ses propriétés de document :

```javascript
const presentation = new aspose.slides.Presentation("pres.pptx");
try {
    presentation.getProtectionManager().setEncryptDocumentProperties(false);
    presentation.getProtectionManager().encrypt("123123");
    presentation.save("encrypted-pres.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (presentation != null) {
        presentation.dispose();
    }
}
```

## **Charger uniquement les propriétés du document d’une présentation chiffrée**

Pour inspecter les métadonnées d’une présentation chiffrée sans charger ses diapositives ou autre contenu, créez un objet [LoadOptions](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/loadoptions/) et transmettez `true` à `setOnlyLoadDocumentProperties`. Dans ce mode, Aspose.Slides ignore le mot de passe et ne charge que les propriétés du document accessibles publiquement.

L’exemple de code suivant lit les propriétés intégrées et personnalisées du document via `getDocumentProperties` sur [Presentation](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/presentation/) :

```javascript
const loadOptions = new aspose.slides.LoadOptions();
loadOptions.setOnlyLoadDocumentProperties(true);

const presentation = new aspose.slides.Presentation("encrypted-pres.pptx", loadOptions);
try {
    const documentProperties = presentation.getDocumentProperties();

    // Lire les propriétés intégrées du document.
    console.log("Title: " + documentProperties.getTitle());
    console.log("Author: " + documentProperties.getAuthor());

    // Lire les propriétés personnalisées du document.
    const customPropertyCount = documentProperties.getCountOfCustomProperties();

    for (let propertyIndex = 0; propertyIndex < customPropertyCount; propertyIndex++) {
        const propertyName = documentProperties.getCustomPropertyName(propertyIndex);
        const propertyValue = documentProperties.get_Item(propertyName);

        console.log(propertyName + ": " + propertyValue);
    }
} finally {
    presentation.dispose();
}
```

Ce flux de travail fonctionne uniquement lorsque les propriétés du document ont été laissées non chiffrées (publiques) lors du chiffrement de la présentation. Si les propriétés du document sont chiffrées, transmettre `true` à `LoadOptions.setOnlyLoadDocumentProperties` déclenche une exception car le mot de passe est ignoré dans ce mode. Pour accéder aux propriétés du document chiffrées ou charger la présentation complète, y compris ses diapositives et autre contenu, fournissez le mot de passe correct via `LoadOptions.setPassword` sur [LoadOptions](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/loadoptions/).

## **Vérifier si une présentation est protégée par mot de passe avant de la charger**

Avant de charger une présentation, il peut être utile de vérifier et de confirmer que la présentation n’est pas protégée par un mot de passe. Ainsi, vous évitez les erreurs et les problèmes similaires qui surviennent lorsqu’une présentation protégée par mot de passe est chargée sans son mot de passe.

Ce code JavaScript montre comment examiner une présentation pour savoir si elle est protégée par mot de passe (sans charger la présentation elle‑même) :

```javascript
var presentationInfo = aspose.slides.PresentationFactory.getInstance().getPresentationInfo("example.pptx");
console.log("The presentation is password protected: " + presentationInfo.isPasswordProtected());
```

## **Vérifier si une présentation est chiffrée**

Aspose.Slides vous permet de vérifier si une présentation est chiffrée. Pour réaliser cette tâche, vous pouvez utiliser la propriété [isEncrypted](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/ProtectionManager#isEncrypted--) qui renvoie `true` si la présentation est chiffrée ou `false` si elle ne l’est pas.

Ce code d’exemple montre comment vérifier si une présentation est chiffrée :

```javascript
var presentation = new aspose.slides.Presentation("pres.pptx");
try {
    var isEncrypted = presentation.getProtectionManager().isEncrypted();
} finally {
    if (presentation != null) {
        presentation.dispose();
    }
}
```

## **Vérifier si une présentation est protégée en écriture**

Aspose.Slides vous permet de vérifier si une présentation est protégée en écriture. Pour réaliser cette tâche, vous pouvez utiliser la propriété [isWriteProtected](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/ProtectionManager#isWriteProtected--) qui renvoie `true` si la présentation est chiffrée ou `false` si elle ne l’est pas.

Ce code d’exemple montre comment vérifier si une présentation est protégée en écriture :

```javascript
var presentation = new aspose.slides.Presentation("pres.pptx");
try {
    var isEncrypted = presentation.getProtectionManager().isWriteProtected();
} finally {
    if (presentation != null) {
        presentation.dispose();
    }
}
```

## **Valider ou confirmer qu’un mot de passe spécifique a été utilisé pour protéger une présentation**

Il se peut que vous souhaitiez vérifier et confirmer qu’un mot de passe spécifique a été utilisé pour protéger un document de présentation. Aspose.Slides fournit les moyens de valider un mot de passe.

Ce code d’exemple montre comment valider un mot de passe :

```javascript
var presentation = new aspose.slides.Presentation("pres.pptx");
try {
    // vérifier si "pass" correspond
    var isWriteProtected = presentation.getProtectionManager().checkWriteProtection("my_password");
} finally {
    if (presentation != null) {
        presentation.dispose();
    }
}
```

Il renvoie `true` si la présentation a été chiffrée avec le mot de passe spécifié. Sinon, il renvoie `false`. 

{{% alert color="primary" title="See also" %}} 
- [Digital Signature in PowerPoint](/slides/fr/net/digital-signature-in-powerpoint/)
{{% /alert %}}

## **FAQ**

**Quelles méthodes de chiffrement sont prises en charge par Aspose.Slides ?**

Aspose.Slides prend en charge des méthodes de chiffrement modernes, y compris les algorithmes basés sur AES, garantissant un haut niveau de sécurité des données pour vos présentations.

**Que se passe-t-il si un mot de passe incorrect est saisi lors de la tentative d’ouverture d’une présentation ?**

Une exception est levée si un mot de passe incorrect est utilisé, vous informant que l’accès à la présentation est refusé. Cela aide à prévenir les accès non autorisés et protège le contenu de la présentation.

**Y a-t-il des implications de performances lors de la manipulation de présentations protégées par mot de passe ?**

Le processus de chiffrement et de déchiffrement peut entraîner un léger surcoût lors des opérations d’ouverture et d’enregistrement. Dans la plupart des cas, cet impact sur les performances est minime et n’affecte pas de manière significative le temps de traitement global de vos tâches de présentation.