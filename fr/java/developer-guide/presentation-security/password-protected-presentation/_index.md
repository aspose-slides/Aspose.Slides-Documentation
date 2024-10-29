---
title: Présentation protégée par mot de passe
type: docs
weight: 20
url: /fr/java/password-protected-presentation/
keywords: "Verrouiller une présentation PowerPoint en Java"
description: "Verrouiller une présentation PowerPoint. Présentation PowerPoint protégée par mot de passe en Java"
---

## **À propos de la protection par mot de passe**
### **Comment fonctionne la protection par mot de passe pour une présentation ?**
Lorsque vous protégez une présentation par mot de passe, cela signifie que vous mettez en place un mot de passe qui impose certaines restrictions sur la présentation. Pour supprimer les restrictions, le mot de passe doit être saisi. Une présentation protégée par mot de passe est considérée comme une présentation verrouillée.

En général, vous pouvez définir un mot de passe pour imposer ces restrictions sur une présentation :

- **Modification**

  Si vous souhaitez que seules certaines personnes puissent modifier votre présentation, vous pouvez définir une restriction de modification. La restriction ici empêche les gens de modifier, de changer ou de copier des éléments dans votre présentation (à moins qu'ils ne fournissent le mot de passe).

  Cependant, dans ce cas, même sans le mot de passe, un utilisateur pourra accéder à votre document et l'ouvrir. En mode lecture seule, l'utilisateur peut voir le contenu ou des éléments—hyperliens, animations, effets, et autres—à l'intérieur de votre présentation, mais il ne peut pas copier d'éléments ou enregistrer la présentation.

- **Ouverture**

  Si vous souhaitez que seules certaines personnes puissent ouvrir votre présentation, vous pouvez définir une restriction d'ouverture. La restriction ici empêche les gens de même voir le contenu de votre présentation (à moins qu'ils ne fournissent le mot de passe).

  Techniquement, la restriction d'ouverture empêche également les utilisateurs de modifier vos présentations : lorsque les gens ne peuvent pas ouvrir une présentation, ils ne peuvent pas la modifier ou y apporter des changements.

  **Remarque** que lorsque vous protégez une présentation par mot de passe pour empêcher son ouverture, le fichier de présentation devient chiffré.

## **Comment protéger une présentation par mot de passe en ligne**

1. Rendez-vous sur notre page [**Aspose.Slides Lock**](https://products.aspose.app/slides/lock).

   ![todo:image_alt_text](slides-lock.png)

2. Cliquez sur **Déposer ou télécharger vos fichiers**.

3. Sélectionnez le fichier que vous souhaitez protéger par mot de passe sur votre ordinateur.

4. Saisissez votre mot de passe préféré pour la protection de modification ; Saisissez votre mot de passe préféré pour la protection de visualisation.

5. Si vous souhaitez que les utilisateurs voient votre présentation comme la copie finale, cochez la case **Marquer comme final**.

6. Cliquez sur **PROTÉGER MAINTENANT.**

7. Cliquez sur **TÉLÉCHARGER MAINTENANT.**

## **Protection par mot de passe pour les présentations dans Aspose.Slides**
**Formats pris en charge**

Aspose.Slides prend en charge la protection par mot de passe, le chiffrement et des opérations similaires pour les présentations dans ces formats :

- PPTX et PPT - Présentation Microsoft PowerPoint
- ODP - Présentation OpenDocument
- OTP - Modèle de présentation OpenDocument

**Opérations prises en charge**

Aspose.Slides vous permet d'utiliser la protection par mot de passe sur les présentations pour empêcher les modifications de ces manières :

- Chiffrement d'une présentation
- Définir une protection en écriture sur une présentation

**Autres opérations**

Aspose.Slides vous permet d'effectuer d'autres tâches impliquant la protection par mot de passe et le chiffrement de ces manières :

- Déchiffrer une présentation ; ouvrir une présentation chiffrée
- Supprimer le chiffrement ; désactiver la protection par mot de passe
- Supprimer la protection en écriture d'une présentation
- Obtenir les propriétés d'une présentation chiffrée
- Vérifier si une présentation est chiffrée
- Vérifier si une présentation est protégée par mot de passe.

## **Chiffrement d'une présentation**

Vous pouvez chiffrer une présentation en définissant un mot de passe. Ensuite, pour modifier la présentation verrouillée, un utilisateur doit fournir le mot de passe.

Pour chiffrer ou protéger par mot de passe une présentation, vous devez utiliser la méthode encrypt (de [IProtectionManager](https://reference.aspose.com/slides/java/com.aspose.slides/IProtectionManager)) pour définir un mot de passe pour la présentation. Vous passez le mot de passe à la méthode encrypt et utilisez la méthode save pour enregistrer la présentation maintenant chiffrée.

Ce code exemple vous montre comment chiffrer une présentation :

```java
Presentation presentation = new Presentation("pres.pptx");
try {
    presentation.getProtectionManager().encrypt("123123");
    presentation.save("encrypted-pres.pptx", SaveFormat.Pptx);
} finally {
    if (presentation != null) presentation.dispose();
}
```

## **Définir une protection en écriture pour une présentation**

Vous pouvez ajouter une mention indiquant "Ne pas modifier" à une présentation. De cette façon, vous indiquez aux utilisateurs que vous ne souhaitez pas qu'ils apportent des modifications à la présentation.

**Remarque** que le processus de protection en écriture ne chiffre pas la présentation. Par conséquent, les utilisateurs—s'ils le souhaitent réellement—peuvent modifier la présentation, mais pour enregistrer les modifications, ils devront créer une présentation avec un nom différent.

Pour définir une protection en écriture, vous devez utiliser la méthode [setWriteProtection](https://reference.aspose.com/slides/java/com.aspose.slides/IProtectionManager#setWriteProtection-java.lang.String-). Ce code exemple vous montre comment définir une protection en écriture sur une présentation :

```java
Presentation presentation = new Presentation("pres.pptx");
try {
    presentation.getProtectionManager().setWriteProtection("123123");
    presentation.save("write-protected-pres.pptx", SaveFormat.Pptx);
} finally {
    if (presentation != null) presentation.dispose();
}
```

## **Déchiffrer une présentation ; ouvrir une présentation chiffrée**

Aspose.Slides vous permet de charger un fichier chiffré en passant son mot de passe. Pour déchiffrer une présentation, vous devez appeler la méthode [removeEncryption](https://reference.aspose.com/slides/java/com.aspose.slides/IProtectionManager#removeEncryption--) sans paramètres. Vous devrez alors entrer le mot de passe correct pour charger la présentation.

Ce code exemple vous montre comment déchiffrer une présentation :

```java
LoadOptions loadOptions = new LoadOptions();
loadOptions.setPassword("123123");
Presentation presentation = new Presentation("pres.pptx", loadOptions);
try {
    // travailler avec la présentation déchiffrée
} finally {
    if (presentation != null) presentation.dispose();
}
}
```

## **Supprimer le chiffrement ; désactiver la protection par mot de passe**

Vous pouvez supprimer le chiffrement ou la protection par mot de passe sur une présentation. De cette façon, les utilisateurs peuvent accéder ou modifier la présentation sans restrictions.

Pour supprimer le chiffrement ou la protection par mot de passe, vous devez appeler la méthode [removeEncryption](https://reference.aspose.com/slides/java/com.aspose.slides/IProtectionManager#removeEncryption--). Ce code exemple vous montre comment supprimer le chiffrement d'une présentation :

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

## **Supprimer la protection en écriture d'une présentation**

Vous pouvez utiliser Aspose.Slides pour supprimer la protection en écriture utilisée sur un fichier de présentation. De cette façon, les utilisateurs peuvent modifier à leur guise—et ils ne reçoivent aucun avertissement lorsqu'ils effectuent de telles tâches.

Vous pouvez supprimer la protection en écriture d'une présentation en utilisant la méthode [removeWriteProtection](https://reference.aspose.com/slides/java/com.aspose.slides/IProtectionManager#removeWriteProtection--) . Ce code exemple vous montre comment supprimer la protection en écriture d'une présentation :

```java
Presentation presentation = new Presentation("pres.pptx");
try {
    presentation.getProtectionManager().removeWriteProtection();
    presentation.save("write-protection-removed.pptx", SaveFormat.Pptx);
} finally {
    if (presentation != null) presentation.dispose();
}
```

## **Obtenir les propriétés d'une présentation chiffrée**

En général, les utilisateurs ont du mal à obtenir les propriétés du document d'une présentation chiffrée ou protégée par mot de passe. Cependant, Aspose.Slides offre un mécanisme qui vous permet de protéger par mot de passe une présentation tout en conservant les moyens pour les utilisateurs d'accéder aux propriétés de cette présentation.

**Remarque** que lorsque Aspose.Slides chiffre une présentation, les propriétés du document de la présentation sont également protégées par mot de passe par défaut. Mais si vous avez besoin que les propriétés de la présentation soient accessibles (même après que la présentation soit chiffrée), Aspose.Slides vous permet de le faire précisément.

Si vous souhaitez que les utilisateurs conservent la possibilité d'accéder aux propriétés d'une présentation que vous avez chiffrée, vous pouvez définir la propriété [encryptDocumentProperties](https://reference.aspose.com/slides/java/com.aspose.slides/IProtectionManager#getEncryptDocumentProperties--) sur `true`. Ce code exemple vous montre comment chiffrer une présentation tout en fournissant les moyens aux utilisateurs d'accéder à ses propriétés de document :

```java
Presentation presentation = new Presentation("pres.pptx");
try {
    presentation.getProtectionManager().setEncryptDocumentProperties(true);
    presentation.getProtectionManager().encrypt("123123");
} finally {
    if (presentation != null) presentation.dispose();
}
```

## **Vérifier si une présentation est protégée par mot de passe avant de la charger**

Avant de charger une présentation, vous pouvez souhaiter vérifier et confirmer que la présentation n'a pas été protégée par un mot de passe. De cette façon, vous pouvez éviter les erreurs et problèmes similaires qui surviennent lorsqu'une présentation protégée par mot de passe est chargée sans son mot de passe.

Ce code Java vous montre comment examiner une présentation pour voir si elle est protégée par mot de passe (sans charger la présentation elle-même) :

```java
IPresentationInfo presentationInfo = PresentationFactory.getInstance().getPresentationInfo("example.pptx");
System.out.println("La présentation est protégée par mot de passe : " + presentationInfo.isPasswordProtected());
```

## **Vérifier si une présentation est chiffrée**

Aspose.Slides vous permet de vérifier si une présentation est chiffrée. Pour effectuer cette tâche, vous pouvez utiliser la propriété [isEncrypted](https://reference.aspose.com/slides/java/com.aspose.slides/IProtectionManager#isEncrypted--), qui retourne `true` si la présentation est chiffrée ou `false` si la présentation n'est pas chiffrée.

Ce code exemple vous montre comment vérifier si une présentation est chiffrée :

```java
Presentation presentation = new Presentation("pres.pptx");
try {
    boolean isEncrypted = presentation.getProtectionManager().isEncrypted();
} finally {
    if (presentation != null) presentation.dispose();
}
```

## **Vérifier si une présentation est protégée en écriture**

Aspose.Slides vous permet de vérifier si une présentation est protégée en écriture. Pour effectuer cette tâche, vous pouvez utiliser la propriété [isWriteProtected](https://reference.aspose.com/slides/java/com.aspose.slides/IProtectionManager#isWriteProtected--), qui retourne `true` si la présentation est protégée en écriture ou `false` si la présentation n'est pas protégée en écriture.

Ce code exemple vous montre comment vérifier si une présentation est protégée en écriture :

```java
Presentation presentation = new Presentation("pres.pptx");
try {
    boolean isEncrypted = presentation.getProtectionManager().isWriteProtected();
} finally {
    if (presentation != null) presentation.dispose();
}
```

## **Valider ou confirmer qu'un mot de passe spécifique a été utilisé pour protéger une présentation**

Vous pouvez souhaiter vérifier et confirmer qu'un mot de passe spécifique a été utilisé pour protéger un document de présentation. Aspose.Slides fournit les moyens de valider un mot de passe.

Ce code exemple vous montre comment valider un mot de passe :

```java
Presentation presentation = new Presentation("pres.pptx");
try {
    // vérifier si "pass" correspond à
    boolean isWriteProtected = presentation.getProtectionManager().checkWriteProtection("my_password");
} finally {
    if (presentation != null) presentation.dispose();
}
```

Il retourne `true` si la présentation a été chiffrée avec le mot de passe spécifié. Sinon, il retourne `false`.

{{% alert color="primary" title="Voir aussi" %}} 
- [Signature numérique dans PowerPoint](/slides/fr/net/digital-signature-in-powerpoint/)
{{% /alert %}}