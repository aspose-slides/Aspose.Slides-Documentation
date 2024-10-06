---
title: Présentation protégée par mot de passe
type: docs
weight: 20
url: /androidjava/password-protected-presentation/
keywords: "Verrouiller la présentation PowerPoint en Java"
description: "Verrouiller la présentation PowerPoint. Présentation PowerPoint protégée par mot de passe en Java"
---

## **À propos de la protection par mot de passe**
### **Comment fonctionne la protection par mot de passe pour une présentation ?**
Lorsque vous protégez par mot de passe une présentation, cela signifie que vous définissez un mot de passe qui impose certaines restrictions sur la présentation. Pour supprimer les restrictions, il faut entrer le mot de passe. Une présentation protégée par mot de passe est considérée comme une présentation verrouillée.

En général, vous pouvez définir un mot de passe pour imposer ces restrictions sur une présentation :

- **Modification**

  Si vous souhaitez que seuls certains utilisateurs puissent modifier votre présentation, vous pouvez définir une restriction de modification. La restriction ici empêche les gens de modifier, changer ou copier des éléments dans votre présentation (à moins qu'ils ne fournissent le mot de passe).

  Cependant, dans ce cas, même sans le mot de passe, un utilisateur pourra accéder à votre document et l'ouvrir. Dans ce mode lecture seule, l'utilisateur peut voir le contenu ou les éléments—hyperliens, animations, effets, et autres—à l'intérieur de votre présentation, mais il ne peut pas copier des éléments ou enregistrer la présentation.

- **Ouverture**

  Si vous souhaitez que seuls certains utilisateurs puissent ouvrir votre présentation, vous pouvez définir une restriction d'ouverture. La restriction ici empêche les gens de même voir le contenu de votre présentation (à moins qu'ils ne fournissent le mot de passe).

  Techniquement, la restriction d'ouverture empêche également les utilisateurs de modifier vos présentations : Lorsque les gens ne peuvent pas ouvrir une présentation, ils ne peuvent pas la modifier ou y apporter des changements.

  **Remarque** : lorsque vous protégez par mot de passe une présentation pour empêcher son ouverture, le fichier de présentation devient chiffré.

## **Comment protéger une présentation par mot de passe en ligne**

1. Allez sur notre page [**Aspose.Slides Lock**](https://products.aspose.app/slides/lock). 

   ![todo:image_alt_text](slides-lock.png)

2. Cliquez sur **Déposez ou téléchargez vos fichiers**.

3. Sélectionnez le fichier que vous souhaitez protéger par mot de passe sur votre ordinateur. 

4. Entrez votre mot de passe préféré pour la protection de modification ; entrez votre mot de passe préféré pour la protection de visualisation. 

5. Si vous voulez que les utilisateurs voient votre présentation comme la copie finale, cochez la case **Marquer comme final**.

6. Cliquez sur **PROTÉGER MAINTENANT.** 

7. Cliquez sur **TÉLÉCHARGER MAINTENANT.**

## **Protection par mot de passe pour les présentations dans Aspose.Slides**
**Formats pris en charge**

Aspose.Slides prend en charge la protection par mot de passe, le chiffrement et des opérations similaires pour les présentations dans les formats suivants : 

- PPTX et PPT - Présentation Microsoft PowerPoint 
- ODP - Présentation OpenDocument 
- OTP - Modèle de présentation OpenDocument 

**Opérations prises en charge**

Aspose.Slides vous permet d'utiliser la protection par mot de passe sur les présentations pour empêcher les modifications de ces manières :

- Chiffrement d'une présentation
- Définir une protection en écriture pour une présentation

**Autres opérations**

Aspose.Slides vous permet d'effectuer d'autres tâches impliquant la protection par mot de passe et le chiffrement de ces manières :

- Déchiffrement d'une présentation ; ouverture d'une présentation chiffrée
- Suppression du chiffrement ; désactivation de la protection par mot de passe
- Suppression de la protection en écriture d'une présentation
- Obtention des propriétés d'une présentation chiffrée
- Vérification si une présentation est chiffrée
- Vérification si une présentation est protégée par mot de passe.

## **Chiffrement d'une présentation**

Vous pouvez chiffrer une présentation en définissant un mot de passe. Ensuite, pour modifier la présentation verrouillée, un utilisateur doit fournir le mot de passe. 

Pour chiffrer ou protéger par mot de passe une présentation, vous devez utiliser la méthode encrypt (de [IProtectionManager](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IProtectionManager)) pour définir un mot de passe pour la présentation. Vous passez le mot de passe à la méthode encrypt et utilisez la méthode save pour enregistrer la présentation désormais chiffrée.

Cet exemple de code vous montre comment chiffrer une présentation :

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

Vous pouvez ajouter une mention indiquant "Ne pas modifier" à une présentation. De cette manière, vous faites savoir aux utilisateurs que vous ne souhaitez pas qu'ils apportent des changements à la présentation.  

**Remarque** : le processus de protection en écriture ne chiffre pas la présentation. Par conséquent, les utilisateurs—s'ils le souhaitent réellement—peuvent modifier la présentation, mais pour enregistrer les changements, ils devront créer une présentation avec un nom différent. 

Pour définir une protection en écriture, vous devez utiliser la méthode [setWriteProtection](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IProtectionManager#setWriteProtection-java.lang.String-) . Cet exemple de code vous montre comment définir une protection en écriture pour une présentation :

```java
Presentation presentation = new Presentation("pres.pptx");
try {
    presentation.getProtectionManager().setWriteProtection("123123");
    presentation.save("write-protected-pres.pptx", SaveFormat.Pptx);
} finally {
    if (presentation != null) presentation.dispose();
}
```

## **Déchiffrement d'une présentation ; ouverture d'une présentation chiffrée**

Aspose.Slides vous permet de charger un fichier chiffré en passant son mot de passe. Pour déchiffrer une présentation, vous devez appeler la méthode [removeEncryption](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IProtectionManager#removeEncryption--) sans paramètres. Vous devrez ensuite entrer le mot de passe correct pour charger la présentation.

Cet exemple de code vous montre comment déchiffrer une présentation : 

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

## **Suppression du chiffrement ; désactivation de la protection par mot de passe**

Vous pouvez supprimer le chiffrement ou la protection par mot de passe sur une présentation. De cette manière, les utilisateurs peuvent accéder ou modifier la présentation sans restrictions. 

Pour supprimer le chiffrement ou la protection par mot de passe, vous devez appeler la méthode [removeEncryption](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IProtectionManager#removeEncryption--) . Cet exemple de code vous montre comment supprimer le chiffrement d'une présentation :

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

## **Suppression de la protection en écriture d'une présentation**

Vous pouvez utiliser Aspose.Slides pour supprimer la protection en écriture utilisée sur un fichier de présentation. De cette manière, les utilisateurs peuvent modifier comme bon leur semble—et ils ne recevront aucun avertissement lorsqu'ils effectueront de telles tâches.

Vous pouvez supprimer la protection en écriture d'une présentation en utilisant la méthode [removeWriteProtection](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IProtectionManager#removeWriteProtection--) . Cet exemple de code vous montre comment supprimer la protection en écriture d'une présentation :

```java
Presentation presentation = new Presentation("pres.pptx");
try {
    presentation.getProtectionManager().removeWriteProtection();
    presentation.save("write-protection-removed.pptx", SaveFormat.Pptx);
} finally {
    if (presentation != null) presentation.dispose();
}
```

## **Obtention des propriétés d'une présentation chiffrée**

En général, les utilisateurs ont du mal à obtenir les propriétés du document d'une présentation chiffrée ou protégée par mot de passe. Aspose.Slides, cependant, offre un mécanisme qui vous permet de protéger par mot de passe une présentation tout en conservant les moyens pour les utilisateurs d'accéder aux propriétés de cette présentation.

**Remarque** : lorsque Aspose.Slides chiffre une présentation, les propriétés du document de la présentation sont également protégées par mot de passe par défaut. Mais si vous devez rendre les propriétés de la présentation accessibles (même après que la présentation soit chiffrée), Aspose.Slides vous permet de le faire précisément. 

Si vous souhaitez que les utilisateurs conservent la capacité d'accéder aux propriétés d'une présentation que vous avez chiffrée, vous pouvez définir la propriété [encryptDocumentProperties](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IProtectionManager#getEncryptDocumentProperties--) sur `true`. Cet exemple de code vous montre comment chiffrer une présentation tout en fournissant les moyens aux utilisateurs d'accéder à ses propriétés document :

```java
Presentation presentation = new Presentation("pres.pptx");
try {
    presentation.getProtectionManager().setEncryptDocumentProperties(true);
    presentation.getProtectionManager().encrypt("123123");
} finally {
    if (presentation != null) presentation.dispose();
}
```

## **Vérification si une présentation est protégée par mot de passe avant de la charger**

Avant de charger une présentation, vous voudrez peut-être vérifier et confirmer que la présentation n'a pas été protégée par un mot de passe. De cette manière, vous évitez les erreurs et des problèmes similaires, qui se présentent lorsque une présentation protégée par mot de passe est chargée sans son mot de passe.

Ce code Java vous montre comment examiner une présentation pour voir si elle est protégée par mot de passe (sans charger la présentation elle-même) :

```java
IPresentationInfo presentationInfo = PresentationFactory.getInstance().getPresentationInfo("example.pptx");
System.out.println("La présentation est protégée par mot de passe : " + presentationInfo.isPasswordProtected());
```

## **Vérification si une présentation est chiffrée**

Aspose.Slides vous permet de vérifier si une présentation est chiffrée. Pour effectuer cette tâche, vous pouvez utiliser la propriété [isEncrypted](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IProtectionManager#isEncrypted--) , qui retourne `true` si la présentation est chiffrée ou `false` si la présentation n'est pas chiffrée.

Cet exemple de code vous montre comment vérifier si une présentation est chiffrée :

```java
Presentation presentation = new Presentation("pres.pptx");
try {
    boolean isEncrypted = presentation.getProtectionManager().isEncrypted();
} finally {
    if (presentation != null) presentation.dispose();
}
```

## **Vérification si une présentation est protégée en écriture**

Aspose.Slides vous permet de vérifier si une présentation est protégée en écriture. Pour effectuer cette tâche, vous pouvez utiliser la propriété [isWriteProtected](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IProtectionManager#isWriteProtected--) , qui retourne `true` si la présentation est protégée en écriture ou `false` si la présentation n'est pas protégée.

Cet exemple de code vous montre comment vérifier si une présentation est protégée en écriture :

```java
Presentation presentation = new Presentation("pres.pptx");
try {
    boolean isEncrypted = presentation.getProtectionManager().isWriteProtected();
} finally {
    if (presentation != null) presentation.dispose();
}
```

## **Validation ou confirmation qu'un mot de passe spécifique a été utilisé pour protéger une présentation**

Vous pouvez vouloir vérifier et confirmer qu'un mot de passe spécifique a été utilisé pour protéger un document de présentation. Aspose.Slides fournit les moyens pour vous valider un mot de passe.

Cet exemple de code vous montre comment valider un mot de passe :

```java
Presentation presentation = new Presentation("pres.pptx");
try {
    // vérifier si "pass" est correspondant
    boolean isWriteProtected = presentation.getProtectionManager().checkWriteProtection("my_password");
} finally {
    if (presentation != null) presentation.dispose();
}
```

Elle retourne `true` si la présentation a été chiffrée avec le mot de passe spécifié. Sinon, elle retourne `false`. 

{{% alert color="primary" title="Voir aussi" %}} 
- [Signature numérique dans PowerPoint](/slides/net/digital-signature-in-powerpoint/)
{{% /alert %}}