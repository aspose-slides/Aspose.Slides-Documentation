---
title: Sécuriser les présentations avec des mots de passe en Java
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
description: "Apprenez à verrouiller et déverrouiller facilement les présentations PowerPoint et OpenDocument protégées par mot de passe avec Aspose.Slides pour Java. Sécurisez vos présentations."
---
## **Introduction**

Lorsque vous protégez une présentation par mot de passe, vous définissez un mot de passe qui impose certaines restrictions à la présentation. Pour supprimer ces restrictions, le mot de passe doit être saisi. Une présentation protégée par mot de passe est considérée comme une présentation verrouillée.

Typiquement, vous pouvez définir un mot de passe pour appliquer ces restrictions à une présentation :

- **Modification**

Si vous voulez que seuls certains utilisateurs puissent modifier votre présentation, vous pouvez définir une restriction de modification. Cette restriction empêche les personnes de modifier, changer ou copier des éléments de votre présentation à moins de fournir le mot de passe. 

Cependant, même sans le mot de passe, un utilisateur pourra toujours accéder à votre document et l'ouvrir. En mode lecture seule, l'utilisateur peut consulter le contenu — y compris les hyperliens, animations, effets et autres éléments — de votre présentation, mais il ne peut pas copier d'éléments ni enregistrer la présentation.

- **Ouverture**

Si vous voulez que seuls certains utilisateurs puissent ouvrir votre présentation, vous pouvez définir une restriction d'ouverture. Cette restriction empêche les personnes même de visualiser le contenu de votre présentation à moins de fournir le mot de passe.

Techniquement, la restriction d'ouverture empêche également les utilisateurs de modifier vos présentations : si les gens ne peuvent pas ouvrir une présentation, ils ne peuvent pas la modifier ou y apporter des changements.

**Remarque :** Lorsque vous protégez une présentation par mot de passe pour empêcher son ouverture, le fichier de présentation devient chiffré.

## **Protection par mot de passe dans Aspose.Slides**
**Formats pris en charge**

Aspose.Slides prend en charge la protection par mot de passe, le chiffrement et des opérations similaires pour les présentations dans ces formats :

- PPTX et PPT – Microsoft PowerPoint Presentation
- ODP – OpenDocument Presentation
- OTP – OpenDocument Presentation Template

**Opérations prises en charge**

Aspose.Slides vous permet d’utiliser la protection par mot de passe sur les présentations pour empêcher les modifications de ces manières :

- Chiffrer une présentation
- Définir une protection en écriture sur une présentation

**Autres opérations**

Aspose.Slides vous permet d’effectuer d’autres tâches impliquant la protection par mot de passe et le chiffrement de ces manières :

- Déchiffrer une présentation ; ouvrir une présentation chiffrée
- Supprimer le chiffrement ; désactiver la protection par mot de passe
- Supprimer la protection en écriture d’une présentation
- Obtenir les propriétés d’une présentation chiffrée
- Vérifier si une présentation est chiffrée
- Vérifier si une présentation est protégée par mot de passe.

## **Protéger une présentation avec un mot de passe**

Vous pouvez chiffrer une présentation en définissant un mot de passe. Ensuite, pour modifier la présentation verrouillée, l'utilisateur doit fournir le mot de passe. 

Pour chiffrer ou protéger par mot de passe une présentation, vous devez utiliser la méthode `encrypt` (de [IProtectionManager](https://reference.aspose.com/slides/fr/java/com.aspose.slides/IProtectionManager)) afin de définir un mot de passe pour la présentation. Vous passez le mot de passe à la méthode `encrypt` et utilisez la méthode `save` pour enregistrer la présentation désormais chiffrée. 

Ce code d’exemple montre comment chiffrer une présentation :

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("pres.pptx");
try {
    presentation.getProtectionManager().encrypt("123123");
    presentation.save("encrypted-pres.pptx", SaveFormat.Pptx);
} finally {
    if (presentation != null) presentation.dispose();
}
```

## **Définir la protection en écriture d'une présentation**

Vous pouvez ajouter une mention « Do not modify » (Ne pas modifier) à une présentation. De cette façon, vous indiquez aux utilisateurs que vous ne souhaitez pas qu’ils modifient la présentation.  

**Remarque** que le processus de protection en écriture ne chiffre pas la présentation. Par conséquent, les utilisateurs — s’ils le souhaitent réellement — peuvent modifier la présentation, mais pour enregistrer les modifications, ils devront créer une présentation sous un autre nom. 

Pour définir une protection en écriture, vous devez utiliser la méthode [setWriteProtection](https://reference.aspose.com/slides/fr/java/com.aspose.slides/IProtectionManager#setWriteProtection-java.lang.String-) . Ce code d’exemple montre comment définir une protection en écriture sur une présentation :

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("pres.pptx");
try {
    presentation.getProtectionManager().setWriteProtection("123123");
    presentation.save("write-protected-pres.pptx", SaveFormat.Pptx);
} finally {
    if (presentation != null) presentation.dispose();
}
```

## **Charger une présentation chiffrée**

Aspose.Slides vous permet de charger une présentation chiffrée en transmettant le mot de passe correct via [LoadOptions](https://reference.aspose.com/slides/fr/java/com.aspose.slides/loadoptions/). 

Ce code d’exemple montre comment charger une présentation chiffrée : 

```java
import com.aspose.slides.*;

LoadOptions loadOptions = new LoadOptions();
loadOptions.setPassword("123123");
Presentation presentation = new Presentation("pres.pptx", loadOptions);
try {
    // travailler avec la présentation déchiffrée
} finally {
    if (presentation != null) presentation.dispose();
}
```

## **Supprimer le chiffrement d'une présentation**

Vous pouvez supprimer le chiffrement ou la protection par mot de passe d’une présentation. Ainsi, les utilisateurs peuvent accéder ou modifier la présentation sans restrictions. 

Pour supprimer le chiffrement ou la protection par mot de passe, vous devez appeler la méthode [removeEncryption](https://reference.aspose.com/slides/fr/java/com.aspose.slides/IProtectionManager#removeEncryption--) . Ce code d’exemple montre comment supprimer le chiffrement d’une présentation :

```java
import com.aspose.slides.*;

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

## **Supprimer la protection en écriture d'une présentation**

Vous pouvez utiliser Aspose.Slides pour supprimer la protection en écriture appliquée à un fichier de présentation. Ainsi, les utilisateurs peuvent modifier à leur guise — et ils ne recevront aucun avertissement lors de ces actions.

Vous pouvez supprimer la protection en écriture d’une présentation en utilisant la méthode [removeWriteProtection](https://reference.aspose.com/slides/fr/java/com.aspose.slides/IProtectionManager#removeWriteProtection--) . Ce code d’exemple montre comment supprimer la protection en écriture d’une présentation :

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("pres.pptx");
try {
    presentation.getProtectionManager().removeWriteProtection();
    presentation.save("write-protection-removed.pptx", SaveFormat.Pptx);
} finally {
    if (presentation != null) presentation.dispose();
}
```

## **Obtenir les propriétés d'une présentation chiffrée**

Typiquement, les utilisateurs ont du mal à récupérer les propriétés du document d’une présentation chiffrée ou protégée par mot de passe. Cependant, Aspose.Slides offre un mécanisme qui permet de protéger une présentation par mot de passe tout en conservant la capacité pour les utilisateurs d’accéder à ses propriétés.

**Remarque :** Par défaut, lorsque Aspose.Slides chiffre une présentation, les propriétés du document de la présentation sont également protégées par mot de passe. Si vous avez besoin de rendre les propriétés du document accessibles même après le chiffrement, Aspose.Slides vous permet de le faire précisément.

Si vous voulez que les utilisateurs conservent la capacité d’accéder aux propriétés d’une présentation chiffrée, transmettez `false` à [IProtectionManager.setEncryptDocumentProperties](https://reference.aspose.com/slides/fr/java/com.aspose.slides/iprotectionmanager/#setEncryptDocumentProperties-boolean-). Ce code d’exemple montre comment chiffrer une présentation tout en permettant aux utilisateurs d’accéder à ses propriétés de document :

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("pres.pptx");
try {
    presentation.getProtectionManager().setEncryptDocumentProperties(false);
    presentation.getProtectionManager().encrypt("123123");
    presentation.save("encrypted-pres.pptx", SaveFormat.Pptx);
} finally {
    if (presentation != null) presentation.dispose();
}
```

## **Charger uniquement les propriétés du document d'une présentation chiffrée**

Pour inspecter les métadonnées d’une présentation chiffrée sans charger ses diapositives ou autre contenu, créez un objet [LoadOptions](https://reference.aspose.com/slides/fr/java/com.aspose.slides/loadoptions/) et transmettez `true` à [setOnlyLoadDocumentProperties](https://reference.aspose.com/slides/fr/java/com.aspose.slides/iloadoptions/#setOnlyLoadDocumentProperties-boolean-). Dans ce mode, Aspose.Slides ignore le mot de passe et ne charge que les propriétés du document qui sont publiquement accessibles.

L’exemple de code suivant lit les propriétés de document intégrées et personnalisées via [IPresentation.getDocumentProperties](https://reference.aspose.com/slides/fr/java/com.aspose.slides/ipresentation/#getDocumentProperties--) :

```java
LoadOptions loadOptions = new LoadOptions();
loadOptions.setOnlyLoadDocumentProperties(true);

Presentation presentation = new Presentation("encrypted-pres.pptx", loadOptions);
try {
    IDocumentProperties documentProperties = presentation.getDocumentProperties();

    // Lire les propriétés de document intégrées.
    System.out.println("Title: " + documentProperties.getTitle());
    System.out.println("Author: " + documentProperties.getAuthor());

    // Lire les propriétés de document personnalisées.
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

Ce flux de travail ne fonctionne que lorsque les propriétés du document ont été laissées non chiffrées (publiques) au moment du chiffrement de la présentation. Si les propriétés du document sont chiffrées, transmettre `true` à `loadOptions.setOnlyLoadDocumentProperties` entraîne une exception car le mot de passe est ignoré dans ce mode. Pour accéder aux propriétés de document chiffrées ou charger la présentation complète, y compris ses diapositives et autre contenu, fournissez le bon mot de passe via [ILoadOptions.setPassword](https://reference.aspose.com/slides/fr/java/com.aspose.slides/iloadoptions/#setPassword-java.lang.String-) .

## **Vérifier si une présentation est protégée par mot de passe**

Avant de charger une présentation, vous pouvez vouloir vérifier et confirmer que la présentation n’est pas protégée par un mot de passe. Ainsi, vous évitez les erreurs et problèmes similaires qui surviennent lorsqu’une présentation protégée par mot de passe est chargée sans son mot de passe.

Ce code Java montre comment examiner une présentation pour voir si elle est protégée par mot de passe (sans charger la présentation elle‑même) :

```java
import com.aspose.slides.*;

IPresentationInfo presentationInfo = PresentationFactory.getInstance().getPresentationInfo("example.pptx");
System.out.println("The presentation is password protected: " + presentationInfo.isPasswordProtected());
```

## **Vérifier si une présentation est chiffrée**

Aspose.Slides vous permet de vérifier si une présentation est chiffrée. Pour réaliser cette tâche, vous pouvez utiliser la propriété [isEncrypted](https://reference.aspose.com/slides/fr/java/com.aspose.slides/IProtectionManager#isEncrypted--) qui renvoie `true` si la présentation est chiffrée ou `false` si elle ne l’est pas. 

Ce code d’exemple montre comment vérifier si une présentation est chiffrée :

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("pres.pptx");
try {
    boolean isEncrypted = presentation.getProtectionManager().isEncrypted();
} finally {
    if (presentation != null) presentation.dispose();
}
```

## **Vérifier si une présentation est protégée en écriture**

Aspose.Slides vous permet de vérifier si une présentation est protégée en écriture. Pour réaliser cette tâche, vous pouvez utiliser la propriété [isWriteProtected](https://reference.aspose.com/slides/fr/java/com.aspose.slides/IProtectionManager#isWriteProtected--) qui renvoie `true` si la présentation est protégée en écriture ou `false` sinon. 

Ce code d’exemple montre comment vérifier si une présentation est protégée en écriture :

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("pres.pptx");
try {
    boolean isEncrypted = presentation.getProtectionManager().isWriteProtected();
} finally {
    if (presentation != null) presentation.dispose();
}
```

## **Valider ou confirmer qu’un mot de passe spécifique a été utilisé**

Vous pouvez souhaiter vérifier et confirmer qu’un mot de passe spécifique a été utilisé pour protéger un document de présentation. Aspose.Slides fournit les moyens de valider un mot de passe. 

Ce code d’exemple montre comment valider un mot de passe :

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("pres.pptx");
try {
    // vérifier si "pass" correspond
    boolean isWriteProtected = presentation.getProtectionManager().checkWriteProtection("my_password");
} finally {
    if (presentation != null) presentation.dispose();
}
```

Il renvoie `true` si la présentation a été protégée en écriture avec le mot de passe indiqué. Sinon, il renvoie `false`. 

{{% alert color="info" title="Voir aussi" %}} 
- [Signature numérique dans PowerPoint](/slides/fr/java/digital-signature-in-powerpoint/)
{{% /alert %}}

## **FAQ**

**Quelles méthodes de chiffrement sont prises en charge par Aspose.Slides ?**

Aspose.Slides prend en charge les méthodes de chiffrement modernes, y compris les algorithmes basés sur AES, garantissant un haut niveau de sécurité des données pour vos présentations.

**Que se passe‑t‑il si un mot de passe incorrect est saisi lors de la tentative d’ouverture d’une présentation ?**

Une exception est levée si un mot de passe incorrect est utilisé, vous alertant que l’accès à la présentation est refusé. Cela aide à prévenir les accès non autorisés et protège le contenu de la présentation.

**Y a‑t‑il des implications de performance lors de l’utilisation de présentations protégées par mot de passe ?**

Le processus de chiffrement et de déchiffrement peut entraîner un léger surcoût lors des opérations d’ouverture et d’enregistrement. Dans la plupart des cas, cet impact sur les performances est minime et n’affecte pas de façon significative le temps de traitement global de vos tâches de présentation.