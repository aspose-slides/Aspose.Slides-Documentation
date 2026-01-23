---
title: Sécuriser les présentations avec des mots de passe en PHP
linktitle: Protection par mot de passe
type: docs
weight: 20
url: /fr/php-java/password-protected-presentation/
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
- PHP
- Aspose.Slides
description: "Apprenez comment verrouiller et déverrouiller facilement les présentations PowerPoint et OpenDocument protégées par mot de passe avec Aspose.Slides pour PHP. Sécurisez vos présentations."
---

## **À propos de la protection par mot de passe**
### **Comment fonctionne la protection par mot de passe d’une présentation ?**
Lorsque vous protégez une présentation par un mot de passe, vous définissez un mot de passe qui impose certaines restrictions à la présentation. Pour supprimer les restrictions, il faut saisir le mot de passe. Une présentation protégée par mot de passe est considérée comme une présentation verrouillée.

Typiquement, vous pouvez définir un mot de passe pour imposer ces restrictions à une présentation :

- **Modification**

  Si vous souhaitez que seules certaines personnes puissent modifier votre présentation, vous pouvez définir une restriction de modification. Cette restriction empêche les personnes de modifier, de changer ou de copier des éléments de votre présentation (sauf si elles fournissent le mot de passe).

  Cependant, dans ce cas, même sans le mot de passe, un utilisateur pourra accéder à votre document et l’ouvrir. En mode lecture seule, l’utilisateur peut visualiser le contenu ou les éléments—hyperliens, animations, effets, etc.—à l’intérieur de votre présentation, mais il ne peut pas copier les éléments ni enregistrer la présentation.

- **Ouverture**

  Si vous souhaitez que seules certaines personnes puissent ouvrir votre présentation, vous pouvez définir une restriction d’ouverture. Cette restriction empêche les personnes de visualiser le contenu de votre présentation (sauf si elles fournissent le mot de passe).

  Techniquement, la restriction d’ouverture empêche également les utilisateurs de modifier vos présentations : lorsqu’une personne ne peut pas ouvrir une présentation, elle ne peut pas la modifier ou y apporter des changements.  

  **Remarque** que lorsque vous protégez une présentation par mot de passe pour empêcher l’ouverture, le fichier de la présentation devient chiffré.

## **Comment protéger une présentation par mot de passe en ligne**

1. Accédez à notre page [**Aspose.Slides Lock**](https://products.aspose.app/slides/lock).

   ![todo:image_alt_text](slides-lock.png)

2. Cliquez sur **Drop or upload your files**.

3. Sélectionnez le fichier que vous souhaitez protéger par mot de passe sur votre ordinateur.

4. Saisissez le mot de passe souhaité pour la protection en modification ; saisissez le mot de passe souhaité pour la protection en visualisation.

5. Si vous voulez que les utilisateurs voient votre présentation comme la copie finale, cochez la case **Mark as final**.

6. Cliquez sur **PROTECT NOW.**

7. Cliquez sur **DOWNLOAD NOW.**

## **Protection par mot de passe des présentations dans Aspose.Slides**
**Formats pris en charge**

Aspose.Slides prend en charge la protection par mot de passe, le chiffrement et des opérations similaires pour les présentations aux formats suivants :

- PPTX et PPT - Présentation Microsoft PowerPoint
- ODP - Présentation OpenDocument
- OTP - Modèle de présentation OpenDocument

**Opérations prises en charge**

Aspose.Slides vous permet d’utiliser la protection par mot de passe sur les présentations afin d’empêcher les modifications de ces manières :

- Chiffrer une présentation
- Appliquer une protection en écriture à une présentation

**Autres opérations**

Aspose.Slides vous permet d’effectuer d’autres tâches liées à la protection par mot de passe et au chiffrement de ces manières :

- Déchiffrer une présentation ; ouvrir une présentation chiffrée
- Supprimer le chiffrement ; désactiver la protection par mot de passe
- Supprimer la protection en écriture d’une présentation
- Obtenir les propriétés d’une présentation chiffrée
- Vérifier si une présentation est chiffrée
- Vérifier si une présentation est protégée par mot de passe.

## **Chiffrer une présentation**

Vous pouvez chiffrer une présentation en définissant un mot de passe. Ensuite, pour modifier la présentation verrouillée, l’utilisateur doit fournir le mot de passe.

Pour chiffrer ou protéger par mot de passe une présentation, vous devez utiliser la méthode encrypt (de [ProtectionManager](https://reference.aspose.com/slides/php-java/aspose.slides/protectionmanager/)) afin de définir un mot de passe pour la présentation. Vous transmettez le mot de passe à la méthode encrypt et utilisez la méthode save pour enregistrer la présentation désormais chiffrée.

Ce code d’exemple vous montre comment chiffrer une présentation :
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


## **Appliquer une protection en écriture à une présentation**

Vous pouvez ajouter une mention « Ne pas modifier » à une présentation. Ainsi, vous indiquez aux utilisateurs que vous ne souhaitez pas qu’ils modifient la présentation.

**Remarque** que le processus de protection en écriture ne chiffre pas la présentation. Par conséquent, les utilisateurs—s’ils le souhaitent réellement—peuvent modifier la présentation, mais pour enregistrer les modifications, ils devront créer une présentation avec un nom différent.

Pour appliquer une protection en écriture, vous devez utiliser la méthode [setWriteProtection](https://reference.aspose.com/slides/php-java/aspose.slides/protectionmanager/#setWriteProtection). Ce code d’exemple vous montre comment appliquer une protection en écriture à une présentation :
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


## **Charger une présentation chiffrée**

Aspose.Slides vous permet de charger un fichier chiffré en transmettant son mot de passe. Pour déchiffrer une présentation, vous devez appeler la méthode [removeEncryption](https://reference.aspose.com/slides/php-java/aspose.slides/protectionmanager/#removeEncryption) sans paramètres. Vous devrez alors saisir le mot de passe correct pour charger la présentation.

Ce code d’exemple vous montre comment déchiffrer une présentation : 
```php
  $loadOptions = new LoadOptions();
  $loadOptions->setPassword("123123");
  $presentation = new Presentation("pres.pptx", $loadOptions);
  try {
    # travailler avec la présentation décryptée
  } finally {
    if (!java_is_null($presentation)) {
      $presentation->dispose();
    }
  }
```


## **Supprimer le chiffrement d’une présentation**

Vous pouvez supprimer le chiffrement ou la protection par mot de passe d’une présentation. Ainsi, les utilisateurs peuvent accéder à la présentation ou la modifier sans restrictions.

Pour supprimer le chiffrement ou la protection par mot de passe, vous devez appeler la méthode [removeEncryption](https://reference.aspose.com/slides/php-java/aspose.slides/protectionmanager/#removeEncryption). Ce code d’exemple vous montre comment supprimer le chiffrement d’une présentation :
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


## **Supprimer la protection en écriture d’une présentation**

Vous pouvez utiliser Aspose.Slides pour supprimer la protection en écriture appliquée à un fichier de présentation. Ainsi, les utilisateurs peuvent modifier à leur guise—et ils n’obtiennent aucun avertissement lorsqu’ils effectuent ces tâches.

Vous pouvez supprimer la protection en écriture d’une présentation en utilisant la méthode [removeWriteProtection](https://reference.aspose.com/slides/php-java/aspose.slides/protectionmanager/#removeWriteProtection). Ce code d’exemple vous montre comment supprimer la protection en écriture d’une présentation :
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


## **Obtenir les propriétés d’une présentation chiffrée**

Typiquement, les utilisateurs ont du mal à obtenir les propriétés du document d’une présentation chiffrée ou protégée par mot de passe. Aspose.Slides propose toutefois un mécanisme qui vous permet de protéger une présentation par mot de passe tout en conservant la possibilité pour les utilisateurs d’accéder aux propriétés de cette présentation.

**Remarque** que lorsque Aspose.Slides chiffre une présentation, les propriétés du document de la présentation sont également protégées par mot de passe par défaut. Mais si vous devez rendre les propriétés de la présentation accessibles (même après le chiffrement), Aspose.Slides vous le permet.

Si vous voulez que les utilisateurs conservent la capacité d’accéder aux propriétés d’une présentation que vous avez chiffrée, vous pouvez utiliser la méthode [encryptDocumentProperties](https://reference.aspose.com/slides/php-java/aspose.slides/protectionmanager/#getEncryptDocumentProperties) avec la valeur `true`. Ce code d’exemple vous montre comment chiffrer une présentation tout en permettant aux utilisateurs d’accéder à ses propriétés de document :
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


## **Vérifier si une présentation est protégée par mot de passe**

Avant de charger une présentation, vous pouvez vouloir vérifier et confirmer que la présentation n’est pas protégée par un mot de passe. Ainsi, vous évitez les erreurs et problèmes similaires qui surviennent lorsqu’une présentation protégée par mot de passe est chargée sans son mot de passe.

Ce code PHP vous montre comment examiner une présentation pour voir si elle est protégée par mot de passe (sans charger la présentation elle‑même) :
```php
  $presentationInfo = PresentationFactory->getInstance()->getPresentationInfo("example.pptx");
  echo("The presentation is password protected: " . $presentationInfo->isPasswordProtected());

```


## **Vérifier si une présentation est chiffrée**

Aspose.Slides vous permet de vérifier si une présentation est chiffrée. Pour effectuer cette tâche, vous pouvez utiliser la méthode [isEncrypted](https://reference.aspose.com/slides/php-java/aspose.slides/protectionmanager/#isEncrypted), qui renvoie `true` si la présentation est chiffrée ou `false` sinon.

Ce code d’exemple vous montre comment vérifier si une présentation est chiffrée :
```php
  $presentation = new Presentation("pres.pptx");
  try {
    $isEncrypted = $presentation->getProtectionManager()->isEncrypted();
  finally {
    if (!java_is_null($presentation)) {
      $presentation->dispose();
    }
  }
```


## **Vérifier si une présentation est protégée en écriture**

Aspose.Slides vous permet de vérifier si une présentation est protégée en écriture. Pour effectuer cette tâche, vous pouvez utiliser la méthode [isWriteProtected](https://reference.aspose.com/slides/php-java/aspose.slides/protectionmanager/#isWriteProtected), qui renvoie `true` si la présentation est protégée en écriture ou `false` sinon.

Ce code d’exemple vous montre comment vérifier si une présentation est protégée en écriture :
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


## **Valider ou confirmer qu’un mot de passe spécifique a été utilisé**

Vous pouvez vouloir vérifier et confirmer qu’un mot de passe spécifique a été utilisé pour protéger un document de présentation. Aspose.Slides fournit les moyens de valider un mot de passe.

Ce code d’exemple vous montre comment valider un mot de passe :
```php
  $presentation = new Presentation("pres.pptx");
  try {
    # vérifier si le mot de passe correspond
    $isWriteProtected = $presentation->getProtectionManager()->checkWriteProtection("my_password");
  } finally {
    if (!java_is_null($presentation)) {
      $presentation->dispose();
    }
  }
```


Il renvoie `true` si la présentation a été chiffrée avec le mot de passe indiqué. Sinon, il renvoie `false`. 

{{% alert color="primary" title="Voir aussi" %}} 
- [Digital Signature in PowerPoint](/slides/fr/php-java/digital-signature-in-powerpoint/)
{{% /alert %}}

## **FAQ**

**Quelles méthodes de chiffrement sont prises en charge par Aspose.Slides ?**

Aspose.Slides prend en charge les méthodes de chiffrement modernes, y compris les algorithmes basés sur AES, garantissant un niveau élevé de sécurité des données pour vos présentations.

**Que se passe‑t‑il si un mot de passe incorrect est saisi lors de la tentative d’ouverture d’une présentation ?**

Une exception est levée si un mot de passe incorrect est utilisé, vous avertissant que l’accès à la présentation est refusé. Cela aide à prévenir les accès non autorisés et protège le contenu de la présentation.

**Existe‑t‑il des implications de performance lors de la manipulation de présentations protégées par mot de passe ?**

Le processus de chiffrement et de déchiffrement peut introduire un léger surcoût lors des opérations d’ouverture et d’enregistrement. Dans la plupart des cas, cet impact sur les performances est minime et n’affecte pas de manière significative le temps de traitement global de vos tâches de présentation.