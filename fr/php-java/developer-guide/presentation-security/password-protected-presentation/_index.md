---
title: "Présentations sécurisées avec des mots de passe en PHP"
linktitle: "Protection par mot de passe"
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
description: "Découvrez comment verrouiller et déverrouiller facilement des présentations PowerPoint et OpenDocument protégées par mot de passe avec Aspose.Slides pour PHP. Sécurisez vos présentations."
---

## **À propos de la protection par mot de passe**
### **Comment fonctionne la protection par mot de passe d’une présentation ?**
Lorsque vous protégez une présentation par mot de passe, cela signifie que vous définissez un mot de passe qui impose certaines restrictions à la présentation. Pour supprimer les restrictions, le mot de passe doit être saisi. Une présentation protégée par mot de passe est considérée comme une présentation verrouillée.

En général, vous pouvez définir un mot de passe pour appliquer ces restrictions à une présentation :

- **Modification**

  Si vous ne souhaitez autoriser que certains utilisateurs à modifier votre présentation, vous pouvez définir une restriction de modification. Cette restriction empêche les personnes de modifier, de changer ou de copier des éléments de votre présentation (à moins qu’elles ne fournissent le mot de passe).  

  Cependant, dans ce cas, même sans le mot de passe, un utilisateur pourra accéder à votre document et l’ouvrir. En mode lecture seule, l’utilisateur peut consulter le contenu ou les éléments—hyperliens, animations, effets, etc.—dans votre présentation, mais il ne peut pas copier d’éléments ni enregistrer la présentation.  

- **Ouverture**

  Si vous ne souhaitez autoriser que certains utilisateurs à ouvrir votre présentation, vous pouvez définir une restriction d’ouverture. Cette restriction empêche les personnes de même voir le contenu de votre présentation (à moins qu’elles ne fournissent le mot de passe).  

  Techniquement, la restriction d’ouverture empêche également les utilisateurs de modifier vos présentations : lorsqu’ils ne peuvent pas ouvrir une présentation, ils ne peuvent pas la modifier.  

  **Note** que lorsque vous protégez une présentation par mot de passe afin d’empêcher son ouverture, le fichier de la présentation devient chiffré.

## **Comment protéger une présentation par mot de passe en ligne**
1. Accédez à notre page [**Aspose.Slides Lock**](https://products.aspose.app/slides/lock). 

   ![todo:image_alt_text](slides-lock.png)

2. Cliquez sur **Déposer ou télécharger vos fichiers**.

3. Sélectionnez le fichier que vous souhaitez protéger par mot de passe sur votre ordinateur. 

4. Saisissez le mot de passe souhaité pour la protection en édition ; Saisissez le mot de passe souhaité pour la protection en lecture. 

5. Si vous souhaitez que les utilisateurs voient votre présentation comme la version finale, cochez la case **Mark as final**.

6. Cliquez sur **PROTECT NOW.** 

7. Cliquez sur **DOWNLOAD NOW.**

## **Protection par mot de passe des présentations dans Aspose.Slides**
**Formats pris en charge**

Aspose.Slides prend en charge la protection par mot de passe, le chiffrement et des opérations similaires pour les présentations dans ces formats :

- PPTX and PPT - Microsoft PowerPoint Presentation 
- ODP - OpenDocument Presentation 
- OTP -  OpenDocument Presentation Template 

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

## **Chiffrer une présentation**
Vous pouvez chiffrer une présentation en définissant un mot de passe. Ensuite, pour modifier la présentation verrouillée, l'utilisateur doit fournir le mot de passe.

Vous devez utiliser la méthode encrypt (de [IProtectionManager](https://reference.aspose.com/slides/php-java/aspose.slides/IProtectionManager)) pour définir un mot de passe pour la présentation. Vous transmettez le mot de passe à la méthode encrypt et utilisez la méthode save pour enregistrer la présentation désormais chiffrée.

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


## **Définir une protection en écriture sur une présentation**
Vous pouvez ajouter une mention « Ne pas modifier » à une présentation. Ainsi, vous indiquez aux utilisateurs que vous ne souhaitez pas qu’ils apportent des modifications à la présentation.  

**Note** que le processus de protection en écriture ne chiffre pas la présentation. Ainsi, les utilisateurs—s’ils le souhaitent réellement—peuvent modifier la présentation, mais pour enregistrer les modifications, ils devront créer une présentation sous un autre nom.  

Pour définir une protection en écriture, vous devez utiliser la méthode [setWriteProtection](https://reference.aspose.com/slides/php-java/aspose.slides/IProtectionManager#setWriteProtection-java.lang.String-). Ce code d’exemple vous montre comment appliquer une protection en écriture à une présentation :
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
Aspose.Slides vous permet de charger un fichier chiffré en transmettant son mot de passe. Pour déchiffrer une présentation, vous devez appeler la méthode [removeEncryption](https://reference.aspose.com/slides/php-java/aspose.slides/IProtectionManager#removeEncryption--) sans paramètres. Vous devrez alors saisir le mot de passe correct pour charger la présentation.

Ce code d’exemple vous montre comment déchiffrer une présentation :
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


## **Supprimer le chiffrement d’une présentation**
Vous pouvez supprimer le chiffrement ou la protection par mot de passe d’une présentation. Ainsi, les utilisateurs peuvent accéder ou modifier la présentation sans restriction.

Pour supprimer le chiffrement ou la protection par mot de passe, vous devez appeler la méthode [removeEncryption](https://reference.aspose.com/slides/php-java/aspose.slides/IProtectionManager#removeEncryption--). Ce code d’exemple vous montre comment supprimer le chiffrement d’une présentation :
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
Vous pouvez utiliser Aspose.Slides pour supprimer la protection en écriture appliquée à un fichier de présentation. Ainsi, les utilisateurs peuvent modifier à leur guise—sans aucun avertissement.

Vous pouvez supprimer la protection en écriture d’une présentation en utilisant la méthode [removeWriteProtection](https://reference.aspose.com/slides/php-java/aspose.slides/IProtectionManager#removeWriteProtection--). Ce code d’exemple vous montre comment supprimer la protection en écriture d’une présentation :
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
En général, les utilisateurs ont du mal à obtenir les propriétés du document d’une présentation chiffrée ou protégée par mot de passe. Aspose.Slides propose toutefois un mécanisme permettant de protéger une présentation par mot de passe tout en conservant la possibilité pour les utilisateurs d’accéder aux propriétés de cette présentation.

**Note** que lorsqu’Aspose.Slides chiffre une présentation, les propriétés du document de la présentation sont également protégées par mot de passe par défaut. Mais si vous devez rendre les propriétés de la présentation accessibles (même après le chiffrement), Aspose.Slides vous permet de le faire.

Si vous souhaitez que les utilisateurs conservent la capacité d’accéder aux propriétés d’une présentation que vous avez chiffrée, vous pouvez définir la propriété [encryptDocumentProperties](https://reference.aspose.com/slides/php-java/aspose.slides/IProtectionManager#getEncryptDocumentProperties--) sur `true`. Ce code d’exemple vous montre comment chiffrer une présentation tout en offrant aux utilisateurs la possibilité d’accéder à ses propriétés de document :
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
Avant de charger une présentation, vous pouvez vérifier et confirmer que la présentation n’est pas protégée par un mot de passe. Ainsi, vous évitez les erreurs et problèmes similaires qui surviennent lorsqu’une présentation protégée par mot de passe est chargée sans son mot de passe.

Ce code PHP vous montre comment examiner une présentation pour déterminer si elle est protégée par mot de passe (sans charger la présentation elle‑même) :
```php
  $presentationInfo = PresentationFactory->getInstance()->getPresentationInfo("example.pptx");
  echo("The presentation is password protected: " . $presentationInfo->isPasswordProtected());

```


## **Vérifier si une présentation est chiffrée**
Aspose.Slides vous permet de vérifier si une présentation est chiffrée. Pour cela, vous pouvez utiliser la propriété [isEncrypted](https://reference.aspose.com/slides/php-java/aspose.slides/IProtectionManager#isEncrypted--) qui renvoie `true` si la présentation est chiffrée ou `false` sinon.

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
Aspose.Slides vous permet de vérifier si une présentation est protégée en écriture. Pour cela, vous pouvez utiliser la propriété [isWriteProtected](https://reference.aspose.com/slides/php-java/aspose.slides/IProtectionManager#isWriteProtected--) qui renvoie `true` si la présentation est protégée en écriture ou `false` sinon.

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
Vous pouvez vouloir vérifier et confirmer qu’un mot de passe spécifique a été utilisé pour protéger un document de présentation. Aspose.Slides offre les moyens de valider un mot de passe.

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


Il renvoie `true` si la présentation a été chiffrée avec le mot de passe spécifié. Sinon, il renvoie `false`.

{{% alert color="primary" title="Voir aussi" %}} 
- [Signature numérique dans PowerPoint](/slides/fr/php-java/digital-signature-in-powerpoint/)
{{% /alert %}}

## **FAQ**

**Quelles méthodes de chiffrement sont prises en charge par Aspose.Slides ?**

Aspose.Slides prend en charge les méthodes de chiffrement modernes, notamment les algorithmes basés sur AES, garantissant un niveau élevé de sécurité des données pour vos présentations.

**Que se passe-t-il si un mot de passe incorrect est saisi lors de la tentative d’ouverture d’une présentation ?**

Une exception est levée si un mot de passe incorrect est utilisé, vous informant que l’accès à la présentation est refusé. Cela contribue à empêcher les accès non autorisés et protège le contenu de la présentation.

**Y a-t-il des implications de performances lorsqu’on travaille avec des présentations protégées par mot de passe ?**

Le processus de chiffrement et de déchiffrement peut introduire une légère surcharge lors des opérations d’ouverture et d’enregistrement. Dans la plupart des cas, cet impact sur les performances est minime et n’affecte pas de manière significative le temps de traitement global de vos tâches de présentation.