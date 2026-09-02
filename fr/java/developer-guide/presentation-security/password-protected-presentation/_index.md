---
title: Présentations sécurisées avec des mots de passe en Java
linktitle: Protection par mot de passe
type: docs
weight: 20
url: /fr/java/password-protected-presentation/
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
- Java
- Aspose.Slides
description: "Apprenez comment verrouiller et déverrouiller facilement les présentations PowerPoint et OpenDocument protégées par mot de passe avec Aspose.Slides pour Java. Sécurisez vos présentations."
---
## **Introduction**

Lorsque vous protégez une présentation par mot de passe, vous définissez un mot de passe qui impose certaines restrictions à la présentation. Pour supprimer ces restrictions, le mot de passe doit être saisi. Une présentation protégée par mot de passe est considérée comme une présentation verrouillée.

En général, vous pouvez définir un mot de passe pour appliquer ces restrictions à une présentation :

- **Modification**

Si vous souhaitez que seuls certains utilisateurs puissent modifier votre présentation, vous pouvez définir une restriction de modification. Cette restriction empêche les personnes de modifier, changer ou copier des éléments de votre présentation sauf si elles fournissent le mot de passe.

Cependant, même sans le mot de passe, un utilisateur pourra toujours accéder à votre document et l’ouvrir. En mode lecture seule, l’utilisateur peut visualiser le contenu — y compris les hyperliens, animations, effets et autres éléments — de votre présentation, mais il ne peut pas copier les éléments ni enregistrer la présentation.

- **Ouverture**

Si vous voulez que seuls certains utilisateurs puissent ouvrir votre présentation, vous pouvez définir une restriction d’ouverture. Cette restriction empêche les personnes de même voir le contenu de votre présentation sauf si elles fournissent le mot de passe.

Techniquement, la restriction d’ouverture empêche également les utilisateurs de modifier vos présentations — si les gens ne peuvent pas ouvrir une présentation, ils ne peuvent pas la modifier ou y apporter des changements.

**Note :** Lorsque vous protégez une présentation par mot de passe pour empêcher l’ouverture, le fichier de la présentation devient chiffré.

## **Protection par mot de passe dans Aspose.Slides**
**Formats pris en charge**

Aspose.Slides prend en charge la protection par mot de passe, le chiffrement et des opérations similaires pour les présentations aux formats suivants :

- PPTX et PPT – Microsoft PowerPoint Presentation
- ODP – OpenDocument Presentation
- OTP – OpenDocument Presentation Template

**Opérations prises en charge**

Aspose.Slides vous permet d’utiliser la protection par mot de passe sur les présentations afin d’empêcher les modifications de ces manières :

- Chiffrer une présentation
- Définir une protection en écriture sur une présentation

**Autres opérations**

Aspose.Slides vous permet d’effectuer d’autres tâches liées à la protection par mot de passe et au chiffrement de ces façons :

- Déchiffrer une présentation ; ouvrir une présentation chiffrée
- Supprimer le chiffrement ; désactiver la protection par mot de passe
- Supprimer la protection en écriture d’une présentation
- Obtenir les propriétés d’une présentation chiffrée
- Vérifier si une présentation est chiffrée
- Vérifier si une présentation est protégée par mot de passe.

## **Protéger une présentation avec un mot de passe**

Vous pouvez chiffrer une présentation en définissant un mot de passe. Ensuite, pour modifier la présentation verrouillée, l’utilisateur doit fournir le mot de passe.

Pour chiffrer ou protéger par mot de passe une présentation, vous devez utiliser la méthode encrypt (de [IProtectionManager](https://reference.aspose.com/slides/fr/java/com.aspose.slides/IProtectionManager)) pour définir un mot de passe pour la présentation. Vous transmettez le mot de passe à la méthode encrypt et utilisez la méthode save pour enregistrer la présentation désormais chiffrée.

Ce code d’exemple montre comment chiffrer une présentation :

```java
Presentation presentation = new Presentation("pres.pptx");
try {
    presentation.getProtectionManager().encrypt("123123");
    presentation.save("encrypted-pres.pptx", SaveFormat.Pptx);
} finally {
    if (presentation != null) presentation.dispose();
}
```

## **Définir une protection en écriture sur une présentation**

Vous pouvez ajouter une mention « Ne pas modifier » à une présentation. Ainsi, vous indiquez aux utilisateurs que vous ne voulez pas qu’ils modifient la présentation.

**Note** : le processus de protection en écriture ne chiffre pas la présentation. Par conséquent, les utilisateurs — s’ils le souhaitent réellement — peuvent modifier la présentation, mais pour enregistrer les modifications, ils devront enregistrer la présentation sous un nom différent.

Pour définir une protection en écriture, vous devez utiliser la méthode [setWriteProtection](https://reference.aspose.com/slides/fr/java/com.aspose.slides/IProtectionManager#setWriteProtection-java.lang.String-). Ce code d’exemple montre comment définir une protection en écriture sur une présentation :

```java
Presentation presentation = new Presentation("pres.pptx");
try {
    presentation.getProtectionManager().setWriteProtection("123123");
    presentation.save("write-protected-pres.pptx", SaveFormat.Pptx);
} finally {
    if (presentation != null) presentation.dispose();
}
```

## **Charger une présentation chiffrée**

Aspose.Slides vous permet de charger un fichier chiffré en transmettant son mot de passe. Pour déchiffrer une présentation, vous devez appeler la méthode [removeEncryption](https://reference.aspose.com/slides/fr/java/com.aspose.slides/IProtectionManager#removeEncryption--) sans paramètres. Vous devrez ensuite saisir le mot de passe correct pour charger la présentation.

Ce code d’exemple montre comment déchiffrer une présentation :

```java
LoadOptions loadOptions = new LoadOptions();
loadOptions.setPassword("123123");
Presentation presentation = new Presentation("pres.pptx", loadOptions);
try {
    // travailler avec la présentation déchiffrée
} finally {
    if (presentation != null) presentation.dispose();
}
```

## **Supprimer le chiffrement d’une présentation**

Vous pouvez supprimer le chiffrement ou la protection par mot de passe d’une présentation. Ainsi, les utilisateurs peuvent accéder à la présentation ou la modifier sans restrictions.

Pour supprimer le chiffrement ou la protection par mot de passe, vous devez appeler la méthode [removeEncryption](https://reference.aspose.com/slides/fr/java/com.aspose.slides/IProtectionManager#removeEncryption--). Ce code d’exemple montre comment supprimer le chiffrement d’une présentation :

```java
LoadOptions loadOptions = new LoadOptions();
loadOptions.setPassword("123123");
Presentation presentation = new Presentation("pres.pptx", loadOptions);
try {
    presentation.getProtectionManager().removeEncryption();
    presentation.save("encryption-removed.pptx", SaveFormat.Pptx);
} finally {
    if (presentation != null) presentation.dispose();
}
```

## **Supprimer la protection en écriture d’une présentation**

Vous pouvez utiliser Aspose.Slides pour supprimer la protection en écriture appliquée à un fichier de présentation. Ainsi, les utilisateurs peuvent modifier à leur guise et ne reçoivent aucun avertissement lorsqu’ils effectuent ces actions.

Vous pouvez supprimer la protection en écriture d’une présentation en utilisant la méthode [removeWriteProtection](https://reference.aspose.com/slides/fr/java/com.aspose.slides/IProtectionManager#removeWriteProtection--) . Ce code d’exemple montre comment supprimer la protection en écriture d’une présentation :

```java
Presentation presentation = new Presentation("pres.pptx");
try {
    presentation.getProtectionManager().removeWriteProtection();
    presentation.save("write-protection-removed.pptx", SaveFormat.Pptx);
} finally {
    if (presentation != null) presentation.dispose();
}
```

## **Obtenir les propriétés d’une présentation chiffrée**

En général, les utilisateurs ont du mal à récupérer les propriétés du document d’une présentation chiffrée ou protégée par mot de passe. Cependant, Aspose.Slides propose un mécanisme qui permet de protéger par mot de passe une présentation tout en conservant la possibilité pour les utilisateurs d’accéder à ses propriétés.

**Note :** Par défaut, lorsqu’Aspose.Slides chiffre une présentation, les propriétés du document de la présentation sont également protégées par mot de passe. Si vous devez rendre les propriétés du document accessibles même après le chiffrement, Aspose.Slides vous permet de le faire précisément.

Si vous voulez que les utilisateurs conservent la possibilité d’accéder aux propriétés d’une présentation chiffrée, transmettez `false` à [IProtectionManager.setEncryptDocumentProperties](https://reference.aspose.com/slides/fr/java/com.aspose.slides/iprotectionmanager/#setEncryptDocumentProperties-boolean-). Ce code d’exemple montre comment chiffrer une présentation tout en permettant aux utilisateurs d’accéder à ses propriétés de document :

```java
Presentation presentation = new Presentation("pres.pptx");
try {
    presentation.getProtectionManager().setEncryptDocumentProperties(false);
    presentation.getProtectionManager().encrypt("123123");
    presentation.save("encrypted-pres.pptx", SaveFormat.Pptx);
} finally {
    if (presentation != null) presentation.dispose();
}
```

## **Charger uniquement les propriétés du document d’une présentation chiffrée**

Pour examiner les métadonnées d’une présentation chiffrée sans charger ses diapositives ou autre contenu, créez un objet [LoadOptions](https://reference.aspose.com/slides/fr/java/com.aspose.slides/loadoptions/) et transmettez `true` à [setOnlyLoadDocumentProperties](https://reference.aspose.com/slides/fr/java/com.aspose.slides/iloadoptions/#setOnlyLoadDocumentProperties-boolean-). Dans ce mode, Aspose.Slides ignore le mot de passe et ne charge que les propriétés du document accessibles publiquement.

L’exemple de code suivant lit les propriétés intégrées et personnalisées du document via [IPresentation.getDocumentProperties](https://reference.aspose.com/slides/fr/java/com.aspose.slides/ipresentation/#getDocumentProperties--) :

```java
LoadOptions loadOptions = new LoadOptions();
loadOptions.setOnlyLoadDocumentProperties(true);

Presentation presentation = new Presentation("encrypted-pres.pptx", loadOptions);
try {
    IDocumentProperties documentProperties = presentation.getDocumentProperties();

    // Lire les propriétés intégrées du document.
    System.out.println("Title: " + documentProperties.getTitle());
    System.out.println("Author: " + documentProperties.getAuthor());

    // Lire les propriétés personnalisées du document.
    int customPropertyCount = documentProperties.getCountOfCustomProperties();

    for (int propertyIndex = 0; propertyIndex < customPropertyCount; propertyIndex++) {
        String propertyName = documentProperties.getCustomPropertyName(propertyIndex);
        Object propertyValue = documentProperties.get_Item(propertyName);

        System.out.println(propertyName + ": " + propertyValue);
    }
} finally {
    presentation.dispose();
}
```

Ce flux de travail ne fonctionne que lorsque les propriétés du document ont été laissées non chiffrées (publiques) lors du chiffrement de la présentation. Si les propriétés du document sont chiffrées, transmettre `true` à `loadOptions.setOnlyLoadDocumentProperties` provoque une exception parce que le mot de passe est ignoré dans ce mode. Pour accéder aux propriétés du document chiffrées ou charger la présentation complète, y compris ses diapositives et autres contenus, fournissez le mot de passe correct via [ILoadOptions.setPassword](https://reference.aspose.com/slides/fr/java/com.aspose.slides/iloadoptions/#setPassword-java.lang.String-).

## **Vérifier si une présentation est protégée par mot de passe**

Avant de charger une présentation, vous pouvez souhaiter vérifier et confirmer que la présentation n’est pas protégée par un mot de passe. Ainsi, vous évitez les erreurs et problèmes similaires qui surviennent lorsqu’une présentation protégée est chargée sans son mot de passe.

Ce code Java montre comment examiner une présentation pour déterminer si elle est protégée par mot de passe (sans charger la présentation elle‑même) :

```java
IPresentationInfo presentationInfo = PresentationFactory.getInstance().getPresentationInfo("example.pptx");
System.out.println("The presentation is password protected: " + presentationInfo.isPasswordProtected());
```

## **Vérifier si une présentation est chiffrée**

Aspose.Slides vous permet de vérifier si une présentation est chiffrée. Pour effectuer cette tâche, vous pouvez utiliser la propriété [isEncrypted](https://reference.aspose.com/slides/fr/java/com.aspose.slides/IProtectionManager#isEncrypted--) qui renvoie `true` si la présentation est chiffrée ou `false` sinon.

Ce code d’exemple montre comment vérifier si une présentation est chiffrée :

```java
Presentation presentation = new Presentation("pres.pptx");
try {
    boolean isEncrypted = presentation.getProtectionManager().isEncrypted();
} finally {
    if (presentation != null) presentation.dispose();
}
```

## **Vérifier si une présentation est protégée en écriture**

Aspose.Slides vous permet de vérifier si une présentation est protégée en écriture. Pour effectuer cette tâche, vous pouvez utiliser la propriété [isWriteProtected](https://reference.aspose.com/slides/fr/java/com.aspose.slides/IProtectionManager#isWriteProtected--) qui renvoie `true` si la présentation est protégée en écriture ou `false` sinon.

Ce code d’exemple montre comment vérifier si une présentation est protégée en écriture :

```java
Presentation presentation = new Presentation("pres.pptx");
try {
    boolean isEncrypted = presentation.getProtectionManager().isWriteProtected();
} finally {
    if (presentation != null) presentation.dispose();
}
```

## **Valider ou confirmer qu’un mot de passe spécifique a été utilisé**

Vous pouvez vouloir vérifier et confirmer qu’un mot de passe spécifique a été utilisé pour protéger le document d’une présentation. Aspose.Slides fournit les moyens de valider un mot de passe.

Ce code d’exemple montre comment valider un mot de passe :

```java
Presentation presentation = new Presentation("pres.pptx");
try {
    // vérifier si "pass" correspond
    boolean isWriteProtected = presentation.getProtectionManager().checkWriteProtection("my_password");
} finally {
    if (presentation != null) presentation.dispose();
}
```

Il renvoie `true` si la présentation a été chiffrée avec le mot de passe indiqué. Sinon, il renvoie `false`.

{{% alert color="primary" title="See also" %}} 
- [Digital Signature in PowerPoint](/slides/fr/java/digital-signature-in-powerpoint/)
{{% /alert %}}

## **FAQ**

**Quelles méthodes de chiffrement sont prises en charge par Aspose.Slides ?**

Aspose.Slides prend en charge les méthodes de chiffrement modernes, y compris les algorithmes basés sur AES, garantissant un niveau élevé de sécurité des données pour vos présentations.

**Que se passe‑t‑il si un mot de passe incorrect est saisi lors de la tentative d’ouverture d’une présentation ?**

Une exception est levée si un mot de passe incorrect est utilisé, vous signalant que l’accès à la présentation est refusé. Cela aide à empêcher les accès non autorisés et protège le contenu de la présentation.

**Y a‑t‑il des implications de performance lorsqu’on travaille avec des présentations protégées par mot de passe ?**

Le processus de chiffrement et de déchiffrement peut introduire un léger surcoût lors des opérations d’ouverture et d’enregistrement. Dans la plupart des cas, cet impact sur les performances est minime et n’affecte pas de manière significative le temps de traitement global de vos tâches de présentation.