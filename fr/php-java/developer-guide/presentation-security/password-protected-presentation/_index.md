---
title: Présentation Protégée par Mot de Passe
type: docs
weight: 20
url: /php-java/presentation-protegee-par-mot-de-passe/
keywords: "Verrouiller la présentation PowerPoint"
description: "Verrouiller la présentation PowerPoint. Présentation PowerPoint protégée par mot de passe"
---

## **À propos de la protection par mot de passe**
### **Comment fonctionne la protection par mot de passe pour les présentations ?**
Lorsque vous protégez une présentation par mot de passe, cela signifie que vous définissez un mot de passe qui impose certaines restrictions sur la présentation. Pour supprimer ces restrictions, le mot de passe doit être saisi. Une présentation protégée par mot de passe est considérée comme une présentation verrouillée.

En général, vous pouvez définir un mot de passe pour imposer ces restrictions sur une présentation :

- **Modification**

  Si vous souhaitez que seuls certains utilisateurs puissent modifier votre présentation, vous pouvez définir une restriction de modification. La restriction ici empêche les gens de modifier, changer ou copier des éléments dans votre présentation (à moins qu'ils ne fournissent le mot de passe).

  Cependant, dans ce cas, même sans le mot de passe, un utilisateur pourra accéder à votre document et l'ouvrir. En mode lecture seule, l'utilisateur peut voir le contenu ou les éléments—hyperliens, animations, effets, et autres—dans votre présentation, mais il ne peut pas copier des éléments ou sauvegarder la présentation.

- **Ouverture**

  Si vous souhaitez que seuls certains utilisateurs puissent ouvrir votre présentation, vous pouvez définir une restriction d'ouverture. La restriction ici empêche les gens de même voir le contenu de votre présentation (à moins qu'ils ne fournissent le mot de passe).

  Techniquement, la restriction d'ouverture empêche également les utilisateurs de modifier vos présentations : Lorsque les gens ne peuvent pas ouvrir une présentation, ils ne peuvent pas la modifier ou y apporter des changements.

  **Remarque** que lorsque vous protégez une présentation par mot de passe pour empêcher l'ouverture, le fichier de présentation devient chiffré.

## **Comment protéger une présentation par mot de passe en ligne**

1. Allez sur notre page [**Aspose.Slides Lock**](https://products.aspose.app/slides/lock).

   ![todo:image_alt_text](slides-lock.png)

2. Cliquez sur **Déposez ou téléchargez vos fichiers**.

3. Sélectionnez le fichier que vous souhaitez protéger par mot de passe sur votre ordinateur.

4. Saisissez votre mot de passe préféré pour la protection de modification ; saisissez votre mot de passe préféré pour la protection de lecture.

5. Si vous souhaitez que les utilisateurs voient votre présentation comme la copie finale, cochez la case **Marquer comme final**.

6. Cliquez sur **PROTÉGER MAINTENANT**.

7. Cliquez sur **TÉLÉCHARGER MAINTENANT**.

## **Protection par mot de passe pour les présentations dans Aspose.Slides**
**Formats supportés**

Aspose.Slides prend en charge la protection par mot de passe, le chiffrement, et des opérations similaires pour des présentations dans ces formats :

- PPTX et PPT - Présentation Microsoft PowerPoint
- ODP - Présentation OpenDocument
- OTP - Modèle de présentation OpenDocument

**Opérations prises en charge**

Aspose.Slides vous permet d'utiliser la protection par mot de passe sur les présentations pour empêcher les modifications de ces manières :

- Chiffrer une présentation
- Définir une protection en écriture pour une présentation

**Autres opérations**

Aspose.Slides vous permet d'effectuer d'autres tâches impliquant la protection par mot de passe et le chiffrement de ces manières :

- Déchiffrer une présentation ; ouvrir une présentation chiffrée
- Supprimer le chiffrement ; désactiver la protection par mot de passe
- Supprimer la protection en écriture d'une présentation
- Obtenir les propriétés d'une présentation chiffrée
- Vérifier si une présentation est chiffrée
- Vérifier si une présentation est protégée par mot de passe.

## **Chiffrer une présentation**

Vous pouvez chiffrer une présentation en définissant un mot de passe. Ensuite, pour modifier la présentation verrouillée, un utilisateur doit fournir le mot de passe.

Pour chiffrer ou protéger par mot de passe une présentation, vous devez utiliser la méthode encrypt (du [IProtectionManager](https://reference.aspose.com/slides/php-java/aspose.slides/IProtectionManager)) pour définir un mot de passe à la présentation. Vous passez le mot de passe à la méthode encrypt et utilisez la méthode save pour sauvegarder la présentation maintenant chiffrée.

Ce code d'exemple vous montre comment chiffrer une présentation :

```php
  $presentation = new Presentation("pres.pptx");
  try {
    $presentation->getProtectionManager()->encrypt("123123");
    $presentation->save("encrypted-pres.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($presentation)) {
      $presentation->dispose();
    }
  }
```

## **Définir une protection en écriture sur une présentation**

Vous pouvez ajouter une mention indiquant "Ne pas modifier" à une présentation. De cette manière, vous indiquez aux utilisateurs que vous ne souhaitez pas qu'ils apportent des modifications à la présentation.

**Remarque** que le processus de protection en écriture ne chiffre pas la présentation. Par conséquent, les utilisateurs—s'ils le souhaitent réellement—peuvent modifier la présentation, mais pour sauvegarder les changements, ils devront créer une présentation avec un nom différent.

Pour définir une protection en écriture, vous devez utiliser la méthode [setWriteProtection](https://reference.aspose.com/slides/php-java/aspose.slides/IProtectionManager#setWriteProtection-java.lang.String-). Ce code d'exemple vous montre comment définir une protection en écriture sur une présentation :

```php
  $presentation = new Presentation("pres.pptx");
  try {
    $presentation->getProtectionManager()->setWriteProtection("123123");
    $presentation->save("write-protected-pres.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($presentation)) {
      $presentation->dispose();
    }
  }
```

## **Déchiffrer une présentation ; ouvrir une présentation chiffrée**

Aspose.Slides vous permet de charger un fichier chiffré en passant son mot de passe. Pour déchiffrer une présentation, vous devez appeler la méthode [removeEncryption](https://reference.aspose.com/slides/php-java/aspose.slides/IProtectionManager#removeEncryption--) sans paramètres. Vous devrez ensuite entrer le bon mot de passe pour charger la présentation.

Ce code d'exemple vous montre comment déchiffrer une présentation :

```php
  $loadOptions = new LoadOptions();
  $loadOptions->setPassword("123123");
  $presentation = new Presentation("pres.pptx", $loadOptions);
  try {
    # travailler avec la présentation déchiffrée
  } finally {
    if (!java_is_null($presentation)) {
      $presentation->dispose();
    }
  }
```

## **Supprimer le chiffrement ; désactiver la protection par mot de passe**

Vous pouvez supprimer le chiffrement ou la protection par mot de passe sur une présentation. De cette manière, les utilisateurs deviennent capables d'accéder ou de modifier la présentation sans restrictions.

Pour supprimer le chiffrement ou la protection par mot de passe, vous devez appeler la méthode [removeEncryption](https://reference.aspose.com/slides/php-java/aspose.slides/IProtectionManager#removeEncryption--). Ce code d'exemple vous montre comment supprimer le chiffrement d'une présentation :

```php
  $loadOptions = new LoadOptions();
  $loadOptions->setPassword("123123");
  $presentation = new Presentation("pres.pptx", $loadOptions);
  try {
    $presentation->getProtectionManager()->removeEncryption();
    $presentation->save("encryption-removed.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($presentation)) {
      $presentation->dispose();
    }
  }
```

## **Supprimer la protection en écriture d'une présentation**

Vous pouvez utiliser Aspose.Slides pour supprimer la protection en écriture d'un fichier de présentation. De cette manière, les utilisateurs peuvent modifier à leur guise—et ils ne reçoivent aucun avertissement lorsqu'ils effectuent de telles tâches.

Vous pouvez supprimer la protection en écriture d'une présentation en utilisant la méthode [removeWriteProtection](https://reference.aspose.com/slides/php-java/aspose.slides/IProtectionManager#removeWriteProtection--) . Ce code d'exemple vous montre comment supprimer la protection en écriture d'une présentation :

```php
  $presentation = new Presentation("pres.pptx");
  try {
    $presentation->getProtectionManager()->removeWriteProtection();
    $presentation->save("write-protection-removed.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($presentation)) {
      $presentation->dispose();
    }
  }
```

## **Obtenir les propriétés d'une présentation chiffrée**

En général, les utilisateurs ont du mal à obtenir les propriétés du document d'une présentation chiffrée ou protégée par mot de passe. Aspose.Slides, cependant, offre un mécanisme qui vous permet de protéger par mot de passe une présentation tout en conservant la possibilité pour les utilisateurs d'accéder aux propriétés de cette présentation.

**Remarque** que lorsque Aspose.Slides chiffre une présentation, les propriétés du document de la présentation sont également protégées par mot de passe par défaut. Mais si vous devez rendre les propriétés de la présentation accessibles (même après que la présentation a été chiffrée), Aspose.Slides vous permet de faire précisément cela.

Si vous souhaitez que les utilisateurs conservent la possibilité d'accéder aux propriétés d'une présentation que vous avez chiffrée, vous pouvez définir la propriété [encryptDocumentProperties](https://reference.aspose.com/slides/php-java/aspose.slides/IProtectionManager#getEncryptDocumentProperties--) à `true`. Ce code d'exemple vous montre comment chiffrer une présentation tout en fournissant les moyens aux utilisateurs d'accéder à ses propriétés de document :

```php
  $presentation = new Presentation("pres.pptx");
  try {
    $presentation->getProtectionManager()->setEncryptDocumentProperties(true);
    $presentation->getProtectionManager()->encrypt("123123");
  } finally {
    if (!java_is_null($presentation)) {
      $presentation->dispose();
    }
  }
```

## **Vérifier si une présentation est protégée par mot de passe avant de la charger**

Avant de charger une présentation, vous voudrez peut-être vérifier et confirmer que la présentation n'a pas été protégée par un mot de passe. De cette manière, vous pouvez éviter les erreurs et problèmes similaires qui surviennent lorsqu'une présentation protégée par mot de passe est chargée sans son mot de passe.

Ce code PHP vous montre comment examiner une présentation pour voir si elle est protégée par mot de passe (sans charger la présentation elle-même) :

```php
  $presentationInfo = PresentationFactory->getInstance()->getPresentationInfo("example.pptx");
  echo("La présentation est protégée par mot de passe : " . $presentationInfo->isPasswordProtected());
```

## **Vérifier si une présentation est chiffrée**

Aspose.Slides vous permet de vérifier si une présentation est chiffrée. Pour effectuer cette tâche, vous pouvez utiliser la propriété [isEncrypted](https://reference.aspose.com/slides/php-java/aspose.slides/IProtectionManager#isEncrypted--), qui retourne `true` si la présentation est chiffrée ou `false` si la présentation n'est pas chiffrée.

Ce code d'exemple vous montre comment vérifier si une présentation est chiffrée :

```php
  $presentation = new Presentation("pres.pptx");
  try {
    $isEncrypted = $presentation->getProtectionManager()->isEncrypted();
  } finally {
    if (!java_is_null($presentation)) {
      $presentation->dispose();
    }
  }
```

## **Vérifier si une présentation est protégée en écriture**

Aspose.Slides vous permet de vérifier si une présentation est protégée en écriture. Pour effectuer cette tâche, vous pouvez utiliser la propriété [isWriteProtected](https://reference.aspose.com/slides/php-java/aspose.slides/IProtectionManager#isWriteProtected--), qui retourne `true` si la présentation est protégée en écriture ou `false` si la présentation n'est pas protégée en écriture.

Ce code d'exemple vous montre comment vérifier si une présentation est protégée en écriture :

```php
  $presentation = new Presentation("pres.pptx");
  try {
    $isEncrypted = $presentation->getProtectionManager()->isWriteProtected();
  } finally {
    if (!java_is_null($presentation)) {
      $presentation->dispose();
    }
  }
```

## **Valider ou confirmer qu'un mot de passe spécifique a été utilisé pour protéger une présentation**

Vous voudrez peut-être vérifier et confirmer qu'un mot de passe spécifique a été utilisé pour protéger un document de présentation. Aspose.Slides fournit les moyens de valider un mot de passe.

Ce code d'exemple vous montre comment valider un mot de passe :

```php
  $presentation = new Presentation("pres.pptx");
  try {
    # vérifier si "pass" correspond à
    $isWriteProtected = $presentation->getProtectionManager()->checkWriteProtection("my_password");
  } finally {
    if (!java_is_null($presentation)) {
      $presentation->dispose();
    }
  }
```

Il retourne `true` si la présentation a été chiffrée avec le mot de passe spécifié. Sinon, il retourne `false`.

{{% alert color="primary" title="Voir aussi" %}} 
- [Signature numérique dans PowerPoint](/slides/net/digital-signature-in-powerpoint/)
{{% /alert %}}