---
title: Présentations sécurisées avec des mots de passe en PHP
linktitle: Protection par mot de passe
type: docs
weight: 20
url: /fr/php-java/password-protected-presentation/
keywords:
- verrouillage PowerPoint
- verrouillage de la présentation
- déverrouillage PowerPoint
- déverrouillage de la présentation
- protection PowerPoint
- protection de la présentation
- définir le mot de passe
- ajouter un mot de passe
- chiffrement PowerPoint
- chiffrement de la présentation
- déchiffrement PowerPoint
- déchiffrement de la présentation
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
description: "Apprenez comment verrouiller et déverrouiller facilement des présentations PowerPoint et OpenDocument protégées par mot de passe avec Aspose.Slides pour PHP. Sécurisez vos présentations."
---
## **Introduction**

Lorsque vous protégez une présentation par mot de passe, vous définissez un mot de passe qui impose certaines restrictions sur la présentation. Pour supprimer ces restrictions, le mot de passe doit être saisi. Une présentation protégée par mot de passe est considérée comme une présentation verrouillée.

En général, vous pouvez définir un mot de passe pour imposer ces restrictions sur une présentation :

- **Modification**

  Si vous souhaitez que seuls certains utilisateurs puissent modifier votre présentation, vous pouvez définir une restriction de modification. Cette restriction empêche les personnes de modifier, changer ou copier des éléments de votre présentation (à moins qu'elles ne fournissent le mot de passe).

  Cependant, dans ce cas, même sans le mot de passe, un utilisateur pourra accéder à votre document et l'ouvrir. En mode lecture seule, l'utilisateur peut voir le contenu ou les éléments—hyperliens, animations, effets, etc.—dans votre présentation, mais il ne peut ni copier d'éléments ni enregistrer la présentation.

- **Ouverture**

  Si vous voulez que seuls certains utilisateurs puissent ouvrir votre présentation, vous pouvez définir une restriction d'ouverture. Cette restriction empêche les personnes de voir le contenu de votre présentation (à moins qu'elles ne fournissent le mot de passe).

  Techniquement, la restriction d'ouverture empêche également les utilisateurs de modifier vos présentations : lorsqu'ils ne peuvent pas ouvrir une présentation, ils ne peuvent pas la modifier.

  **Remarque** que lorsque vous protégez une présentation par mot de passe pour empêcher l'ouverture, le fichier de présentation devient chiffré.

## **Comment protéger une présentation par mot de passe en ligne**

1. Accédez à notre page [**Aspose.Slides Lock**](https://products.aspose.app/slides/fr/lock).

   ![todo:image_alt_text](slides-lock.png)

2. Cliquez sur **Déposez ou téléversez vos fichiers**.

3. Sélectionnez le fichier que vous souhaitez protéger par mot de passe sur votre ordinateur.

4. Saisissez le mot de passe souhaité pour la protection en modification ; saisissez le mot de passe souhaité pour la protection en visualisation.

5. Si vous voulez que les utilisateurs voient votre présentation comme la copie finale, cochez la case **Marquer comme final**.

6. Cliquez sur **PROTECT NOW**.

7. Cliquez sur **DOWNLOAD NOW**.

## **Protection par mot de passe des présentations dans Aspose.Slides**
**Formats pris en charge**

Aspose.Slides prend en charge la protection par mot de passe, le chiffrement et des opérations similaires pour les présentations dans les formats suivants :

- PPTX et PPT – Présentation Microsoft PowerPoint
- ODP – Présentation OpenDocument
- OTP – Modèle de présentation OpenDocument

**Opérations prises en charge**

Aspose.Slides vous permet d’utiliser la protection par mot de passe sur les présentations pour empêcher les modifications de ces manières :

- Chiffrer une présentation
- Définir une protection en écriture sur une présentation

**Autres opérations**

Aspose.Slides vous permet d’effectuer d’autres tâches liées à la protection par mot de passe et au chiffrement de ces manières :

- Déchiffrer une présentation ; ouvrir une présentation chiffrée
- Supprimer le chiffrement ; désactiver la protection par mot de passe
- Supprimer la protection en écriture d’une présentation
- Obtenir les propriétés d’une présentation chiffrée
- Vérifier si une présentation est chiffrée
- Vérifier si une présentation est protégée par mot de passe.

## **Chiffrer une présentation**

Vous pouvez chiffrer une présentation en définissant un mot de passe. Ensuite, pour modifier la présentation verrouillée, un utilisateur doit fournir le mot de passe.

Pour chiffrer ou protéger par mot de passe une présentation, vous devez utiliser la méthode encrypt (de [ProtectionManager](https://reference.aspose.com/slides/fr/php-java/aspose.slides/protectionmanager/)) pour définir un mot de passe pour la présentation. Vous transmettez le mot de passe à la méthode encrypt et utilisez la méthode save pour enregistrer la présentation désormais chiffrée.

Ce code d’exemple montre comment chiffrer une présentation :

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

Vous pouvez ajouter une mention « Ne pas modifier » à une présentation. Ainsi, vous indiquez aux utilisateurs que vous ne souhaitez pas qu’ils modifient la présentation.

**Remarque** que le processus de protection en écriture ne chiffre pas la présentation. Par conséquent, les utilisateurs—s’ils le souhaitent—peuvent modifier la présentation, mais pour enregistrer les modifications, ils devront créer une présentation sous un nom différent.

Pour définir une protection en écriture, vous devez utiliser la méthode [setWriteProtection](https://reference.aspose.com/slides/fr/php-java/aspose.slides/protectionmanager/#setWriteProtection). Ce code d’exemple montre comment définir une protection en écriture sur une présentation :

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

Aspose.Slides vous permet de charger un fichier chiffré en transmettant son mot de passe. Pour déchiffrer une présentation, vous devez appeler la méthode [removeEncryption](https://reference.aspose.com/slides/fr/php-java/aspose.slides/protectionmanager/#removeEncryption) sans paramètres. Vous devrez ensuite saisir le mot de passe correct pour charger la présentation.

Ce code d’exemple montre comment déchiffrer une présentation :

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

Vous pouvez supprimer le chiffrement ou la protection par mot de passe d’une présentation. Ainsi, les utilisateurs peuvent accéder ou modifier la présentation sans restrictions.

Pour supprimer le chiffrement ou la protection par mot de passe, vous devez appeler la méthode [removeEncryption](https://reference.aspose.com/slides/fr/php-java/aspose.slides/protectionmanager/#removeEncryption). Ce code d’exemple montre comment supprimer le chiffrement d’une présentation :

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

Vous pouvez utiliser Aspose.Slides pour supprimer la protection en écriture appliquée à un fichier de présentation. Ainsi, les utilisateurs peuvent modifier à leur guise et ne reçoivent aucun avertissement lors de ces actions.

Vous pouvez supprimer la protection en écriture d’une présentation en utilisant la méthode [removeWriteProtection](https://reference.aspose.com/slides/fr/php-java/aspose.slides/protectionmanager/#removeWriteProtection). Ce code d’exemple montre comment supprimer la protection en écriture d’une présentation :

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

En général, les utilisateurs ont des difficultés à récupérer les propriétés du document d’une présentation chiffrée ou protégée par mot de passe. Cependant, Aspose.Slides propose un mécanisme qui permet de protéger une présentation par mot de passe tout en conservant la possibilité pour les utilisateurs d’accéder à ses propriétés.

**Remarque :** Par défaut, lorsque Aspose.Slides chiffre une présentation, les propriétés du document de la présentation sont également protégées par mot de passe. Si vous devez rendre les propriétés du document accessibles même après le chiffrement, Aspose.Slides vous permet de le faire précisément.

Si vous voulez que les utilisateurs conservent la possibilité d’accéder aux propriétés d’une présentation chiffrée, transmettez `false` à [ProtectionManager::setEncryptDocumentProperties](https://reference.aspose.com/slides/fr/php-java/aspose.slides/protectionmanager/#setEncryptDocumentProperties). Ce code d’exemple montre comment chiffrer une présentation tout en offrant aux utilisateurs l’accès à ses propriétés de document :

```php
  $presentation = new Presentation("pres.pptx");
  try {
    $presentation->getProtectionManager()->setEncryptDocumentProperties(false);
    $presentation->getProtectionManager()->encrypt("123123");
    $presentation->save("encrypted-pres.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($presentation)) {
      $presentation->dispose();
    }
  }
```

## **Charger uniquement les propriétés du document d’une présentation chiffrée**

Pour inspecter les métadonnées d’une présentation chiffrée sans charger ses diapositives ou autre contenu, créez un objet [LoadOptions](https://reference.aspose.com/slides/fr/php-java/aspose.slides/loadoptions/) et transmettez `true` à [setOnlyLoadDocumentProperties](https://reference.aspose.com/slides/fr/php-java/aspose.slides/loadoptions/#setOnlyLoadDocumentProperties). Dans ce mode, Aspose.Slides ignore le mot de passe et ne charge que les propriétés du document qui sont publiquement accessibles.

L’exemple de code suivant lit les propriétés de document intégrées et personnalisées via [Presentation::getDocumentProperties](https://reference.aspose.com/slides/fr/php-java/aspose.slides/presentation/#getDocumentProperties) :

```php
$loadOptions = new LoadOptions();
$loadOptions->setOnlyLoadDocumentProperties(true);

$presentation = new Presentation("encrypted-pres.pptx", $loadOptions);
try {
    $documentProperties = $presentation->getDocumentProperties();

    # Lire les propriétés de document intégrées.
    echo("Title: " . $documentProperties->getTitle() . "\n");
    echo("Author: " . $documentProperties->getAuthor() . "\n");

    # Lire les propriétés de document personnalisées.
    $customPropertyCount = java_values($documentProperties->getCountOfCustomProperties());

    for ($propertyIndex = 0; $propertyIndex < $customPropertyCount; $propertyIndex++) {
        $propertyName = $documentProperties->getCustomPropertyName($propertyIndex);
        $propertyValue = java_values($documentProperties->get_Item($propertyName));

        echo($propertyName . ": " . $propertyValue . "\n");
    }
} finally {
    $presentation->dispose();
}
```

Ce flux de travail ne fonctionne que lorsque les propriétés du document ont été laissées non chiffrées (publiques) lors du chiffrement de la présentation. Si les propriétés du document sont chiffrées, transmettre `true` à [LoadOptions::setOnlyLoadDocumentProperties](https://reference.aspose.com/slides/fr/php-java/aspose.slides/loadoptions/#setOnlyLoadDocumentProperties) provoque une exception car le mot de passe est ignoré dans ce mode. Pour accéder aux propriétés du document chiffrées ou charger la présentation complète, y compris ses diapositives et autre contenu, fournissez le mot de passe correct via [LoadOptions::setPassword](https://reference.aspose.com/slides/fr/php-java/aspose.slides/loadoptions/#setPassword).

## **Vérifier si une présentation est protégée par mot de passe**

Avant de charger une présentation, vous pouvez vouloir vérifier et confirmer que la présentation n’est pas protégée par un mot de passe. Ainsi, vous évitez les erreurs et problèmes similaires qui surviennent lorsqu’une présentation protégée est chargée sans son mot de passe.

Ce code PHP montre comment examiner une présentation pour déterminer si elle est protégée par mot de passe (sans charger la présentation elle‑même) :

```php
  $presentationInfo = PresentationFactory->getInstance()->getPresentationInfo("example.pptx");
  echo("The presentation is password protected: " . $presentationInfo->isPasswordProtected());

```

## **Vérifier si une présentation est chiffrée**

Aspose.Slides vous permet de vérifier si une présentation est chiffrée. Pour cela, vous pouvez utiliser la méthode [isEncrypted](https://reference.aspose.com/slides/fr/php-java/aspose.slides/protectionmanager/#isEncrypted), qui renvoie `true` si la présentation est chiffrée ou `false` si elle ne l’est pas.

Ce code d’exemple montre comment vérifier si une présentation est chiffrée :

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

Aspose.Slides vous permet de vérifier si une présentation est protégée en écriture. Pour cela, vous pouvez utiliser la méthode [isWriteProtected](https://reference.aspose.com/slides/fr/php-java/aspose.slides/protectionmanager/#isWriteProtected), qui renvoie `true` si la présentation est protégée en écriture ou `false` sinon.

Ce code d’exemple montre comment vérifier si une présentation est protégée en écriture :

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

Ce code d’exemple montre comment valider un mot de passe :

```php
  $presentation = new Presentation("pres.pptx");
  try {
    # vérifier si le "pass" correspond
    $isWriteProtected = $presentation->getProtectionManager()->checkWriteProtection("my_password");
  } finally {
    if (!java_is_null($presentation)) {
      $presentation->dispose();
    }
  }
```

Il renvoie `true` si la présentation a été chiffrée avec le mot de passe indiqué. Sinon, il renvoie `false`.

{{% alert color="primary" title="See also" %}} 
- [Digital Signature in PowerPoint](/slides/fr/php-java/digital-signature-in-powerpoint/)
{{% /alert %}}

## **FAQ**

**Quelles méthodes de chiffrement sont prises en charge par Aspose.Slides ?**

Aspose.Slides prend en charge des méthodes de chiffrement modernes, notamment les algorithmes basés sur AES, assurant un niveau élevé de sécurité des données pour vos présentations.

**Que se passe‑t‑il si un mot de passe incorrect est saisi lors de la tentative d’ouverture d’une présentation ?**

Une exception est levée si un mot de passe incorrect est utilisé, vous informant que l’accès à la présentation est refusé. Cela aide à prévenir les accès non autorisés et protège le contenu de la présentation.

**Existe‑t‑il des implications de performance lors du travail avec des présentations protégées par mot de passe ?**

Le processus de chiffrement et de déchiffrement peut introduire un léger surcoût lors des opérations d’ouverture et d’enregistrement. Dans la plupart des cas, cet impact sur les performances est minimal et n’affecte pas de manière significative le temps de traitement global de vos tâches de présentation.