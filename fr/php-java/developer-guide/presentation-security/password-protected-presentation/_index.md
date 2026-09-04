---
title: Protection par mot de passe des présentations en PHP
linktitle: Protection par mot de passe
type: docs
weight: 20
url: /fr/php-java/password-protected-presentation/
keywords:
- présentation protégée par mot de passe
- mot de passe d'ouverture
- chiffrer PowerPoint
- déchiffrer PowerPoint
- valider le mot de passe de la présentation
- vérifier le mot de passe de la présentation
- ouvrir une présentation chiffrée
- supprimer le chiffrement
- PowerPoint
- PPT
- PPTX
- présentation
- PHP
- Aspose.Slides
description: "Chiffrer, détecter, valider, ouvrir et déchiffrer des présentations PowerPoint PPT et PPTX protégées par mot de passe en PHP avec Aspose.Slides."
---
## **Vue d'ensemble**

Un mot de passe d'ouverture chiffre une présentation. Le mot de passe correct est requis pour charger et afficher le contenu de la présentation, ce qui assure la confidentialité.

Un mot de passe d'ouverture est différent d’un mot de passe de protection en écriture. La protection en écriture restreint la modification mais ne chiffre pas le contenu et ne bloque pas le chargement de la présentation. Pour gérer les mots de passe de modification des présentations, voir [Protéger les présentations en écriture](/slides/fr/php-java/write-protected-presentation/).

Les flux de travail ci‑dessous s’appliquent aux présentations PPT et PPTX. Les exemples utilisent les deux formats lorsque le comportement basé sur le fichier ou le flux est important.

## **Chiffrer une présentation avec un mot de passe d'ouverture**

Utilisez [ProtectionManager::encrypt](https://reference.aspose.com/slides/fr/php-java/aspose.slides/protectionmanager/#encrypt) pour affecter un mot de passe d'ouverture. Puis utilisez [Presentation::save](https://reference.aspose.com/slides/fr/php-java/aspose.slides/presentation/#save) pour enregistrer la présentation chiffrée.

L’exemple suivant chiffre une présentation PPTX :

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("pres.pptx");
try {
    $presentation->getProtectionManager()->encrypt("open_password");
    $presentation->save("encrypted-pres.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Laisser les propriétés du document publiques**

Par défaut, Aspose.Slides inclut les propriétés du document dans le chiffrement de la présentation. La méthode [ProtectionManager::setEncryptDocumentProperties](https://reference.aspose.com/slides/fr/php-java/aspose.slides/protectionmanager/#setEncryptDocumentProperties) contrôle ce comportement indépendamment du chiffrement du contenu des diapositives. Passez `false` avant d’appeler [ProtectionManager::encrypt](https://reference.aspose.com/slides/fr/php-java/aspose.slides/protectionmanager/#encrypt) lorsqu’un système d’indexation, de classification, de recherche ou de gestion documentaire doit lire les métadonnées sans le mot de passe d'ouverture.

L’exemple suivant crée une présentation PPTX chiffrée tout en laissant ses propriétés intégrées publiques :

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $properties = $presentation->getDocumentProperties();
    $properties->setAuthor("Contoso Knowledge Management");
    $properties->setTitle("Quarterly Product Roadmap");
    $properties->setKeywords("roadmap, planning, internal");

    $presentation->getSlides()->get_Item(0)->setName("Encrypted presentation content");
    $presentation->getProtectionManager()->setEncryptDocumentProperties(false);
    $presentation->getProtectionManager()->encrypt("open_password");
    $presentation->save("public-properties-encrypted.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Passer `false` à [ProtectionManager::setEncryptDocumentProperties](https://reference.aspose.com/slides/fr/php-java/aspose.slides/protectionmanager/#setEncryptDocumentProperties) ne rend pas publiques les diapositives, les maîtres, les dispositions, les formes, les médias ou tout autre contenu de la présentation. Cela n’affecte que les propriétés du document. Pour lire ces propriétés sans charger le contenu chiffré, voir [Gérer les propriétés de la présentation](/slides/fr/php-java/presentation-properties/).

## **Charger une présentation chiffrée**

Définissez [LoadOptions::setPassword](https://reference.aspose.com/slides/fr/php-java/aspose.slides/loadoptions/#setPassword) avec le mot de passe d'ouverture et transmettez les options à [Presentation](https://reference.aspose.com/slides/fr/php-java/aspose.slides/presentation/) lors du chargement du fichier. Le chargement échoue lorsqu’un mot de passe d'ouverture est requis mais que le mot de passe fourni est absent ou incorrect.

```php
use aspose\slides\LoadOptions;
use aspose\slides\Presentation;

$loadOptions = new LoadOptions();
$loadOptions->setPassword("open_password");

$presentation = new Presentation("encrypted-pres.pptx", $loadOptions);
try {
    # Travailler avec la présentation déchiffrée.
} finally {
    $presentation->dispose();
}
```

## **Supprimer le chiffrement d'une présentation**

Chargez la présentation avec son mot de passe d'ouverture, appelez [ProtectionManager::removeEncryption](https://reference.aspose.com/slides/fr/php-java/aspose.slides/protectionmanager/#removeEncryption) et enregistrez le résultat. La présentation enregistrée peut alors être chargée sans mot de passe.

```php
use aspose\slides\LoadOptions;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$loadOptions = new LoadOptions();
$loadOptions->setPassword("open_password");

$presentation = new Presentation("encrypted-pres.pptx", $loadOptions);
try {
    $presentation->getProtectionManager()->removeEncryption();
    $presentation->save("encryption-removed.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Valider un mot de passe d'ouverture avant le chargement**

Utilisez [PresentationFactory::getPresentationInfo](https://reference.aspose.com/slides/fr/php-java/aspose.slides/presentationfactory/#getPresentationInfo) pour obtenir [PresentationInfo](https://reference.aspose.com/slides/fr/php-java/aspose.slides/presentationinfo/) sans créer d’instance complète de présentation. Vérifiez [PresentationInfo::isPasswordProtected](https://reference.aspose.com/slides/fr/php-java/aspose.slides/presentationinfo/#isPasswordProtected) avant de demander ou de valider un mot de passe. Lorsqu’une protection est présente, validez la valeur fournie avec [PresentationInfo::checkPassword](https://reference.aspose.com/slides/fr/php-java/aspose.slides/presentationinfo/#checkPassword).

### **Flux de travail avec chemin de fichier**

L’exemple suivant valide un mot de passe d'ouverture pour un fichier PPTX, transmet la valeur validée à [LoadOptions::setPassword](https://reference.aspose.com/slides/fr/php-java/aspose.slides/loadoptions/#setPassword) puis charge la présentation complète :

```php
use aspose\slides\LoadOptions;
use aspose\slides\Presentation;
use aspose\slides\PresentationFactory;

$filePath = "protected-presentation.pptx";
$password = "open_password";
$presentationInfo = PresentationFactory::getInstance()->getPresentationInfo($filePath);

if (!$presentationInfo->isPasswordProtected()) {
    echo("The presentation does not have an opening password.\n");
} elseif (!$presentationInfo->checkPassword($password)) {
    echo("The opening password is incorrect.\n");
} else {
    $loadOptions = new LoadOptions();
    $loadOptions->setPassword($password);

    $presentation = new Presentation($filePath, $loadOptions);
    try {
        echo("The presentation was validated and loaded successfully.\n");
    } finally {
        $presentation->dispose();
    }
}
```

### **Flux de travail avec flux**

La surcharge flux de [PresentationFactory::getPresentationInfo](https://reference.aspose.com/slides/fr/php-java/aspose.slides/presentationfactory/#getPresentationInfo) fournit le même flux de travail. Réinitialisez la position d’un flux recherchable avant de charger la présentation complète depuis ce flux.

L’exemple suivant utilise un fichier PPT :

```php
use aspose\slides\LoadOptions;
use aspose\slides\Presentation;
use aspose\slides\PresentationFactory;

$password = "open_password";

$presentationStream = new Java("java.io.FileInputStream", "protected-presentation.ppt");
try {
    $presentationInfo = PresentationFactory::getInstance()->getPresentationInfo($presentationStream);

    if (!$presentationInfo->isPasswordProtected()) {
        echo("The presentation does not have an opening password.\n");
    } elseif (!$presentationInfo->checkPassword($password)) {
        echo("The opening password is incorrect.\n");
    } else {
        $presentationStream->getChannel()->position(0);

        $loadOptions = new LoadOptions();
        $loadOptions->setPassword($password);

        $presentation = new Presentation($presentationStream, $loadOptions);
        try {
            echo("The presentation was validated and loaded successfully.\n");
        } finally {
            $presentation->dispose();
        }
    }
} finally {
    $presentationStream->close();
}
```

### **Valeurs de retour de checkPassword**

[PresentationInfo::checkPassword](https://reference.aspose.com/slides/fr/php-java/aspose.slides/presentationinfo/#checkPassword) renvoie `true` uniquement lorsque la présentation possède un mot de passe d'ouverture et que le mot de passe fourni est correct. Il renvoie `false` dans chacun de ces cas :

- Le mot de passe est incorrect.
- La présentation ne possède pas de mot de passe d'ouverture.
- Le mot de passe fourni est `null` ou vide.

Le comportement est identique pour les présentations PPT et PPTX.

## **Vérifier si une présentation chargée est chiffrée**

Après avoir chargé une présentation avec le mot de passe correct, inspectez [ProtectionManager::isEncrypted](https://reference.aspose.com/slides/fr/php-java/aspose.slides/protectionmanager/#isEncrypted) pour confirmer que la présentation source était chiffrée. Pour détecter la protection par mot de passe d'ouverture avant le chargement, utilisez [PresentationInfo::isPasswordProtected](https://reference.aspose.com/slides/fr/php-java/aspose.slides/presentationinfo/#isPasswordProtected) comme indiqué ci‑dessus.

```php
use aspose\slides\LoadOptions;
use aspose\slides\Presentation;

$loadOptions = new LoadOptions();
$loadOptions->setPassword("open_password");

$presentation = new Presentation("encrypted-pres.pptx", $loadOptions);
try {
    $isEncrypted = $presentation->getProtectionManager()->isEncrypted();
    echo("The presentation is encrypted: " . ($isEncrypted ? "true" : "false") . "\n");
} finally {
    $presentation->dispose();
}
```

## **Recommandations de sécurité**

{{% alert color="warning" title="Sécurité" %}}
N’enregistrez pas les mots de passe d'ouverture dans les journaux ni ne les incluez dans les messages de diagnostic. Évitez les tentatives de validation répétées inutiles, conservez les mots de passe en mémoire uniquement le temps nécessaire et réutilisez un résultat de validation réussi lors du chargement immédiat de la présentation.

Les propriétés publiques du document peuvent divulguer les noms d’auteur, titres, sujets, mots‑clé, informations d’entreprise, commentaires et valeurs personnalisées même si le contenu de la présentation est chiffré. Chiffrez les métadonnées sensibles avec la présentation. Laisser les propriétés publiques doit être une décision explicite prise uniquement lorsque les systèmes doivent indexer, classifier, rechercher ou gérer le fichier sans un mot de passe d'ouverture.
{{% /alert %}}

## **Protéger une présentation par mot de passe en ligne**

1. Ouvrez l’application [Aspose.Slides Lock](https://products.aspose.app/slides/fr/lock).
1. Sélectionnez ou téléversez la présentation.
1. Saisissez un mot de passe pour la protection de la visualisation.
1. Saisissez éventuellement un mot de passe distinct pour la protection de la modification.
1. Appliquez la protection et téléchargez le fichier résultant.

{{% alert color="info" title="Voir aussi" %}}
- [Protéger les présentations en écriture](/slides/fr/php-java/write-protected-presentation/)
- [Signature numérique dans PowerPoint](/slides/fr/php-java/digital-signature-in-powerpoint/)
{{% /alert %}}

## **FAQ**

**Quelle est la différence entre un mot de passe d'ouverture et un mot de passe de protection en écriture ?**

Un mot de passe d'ouverture chiffre la présentation et est requis pour charger son contenu. Un mot de passe de protection en écriture restreint la modification sans chiffrer le contenu.

**Puis‑je valider un mot de passe d'ouverture sans charger toutes les diapositives ?**

Oui. Obtenez les informations de la présentation, vérifiez la présence d’une protection par mot de passe d'ouverture et validez le mot de passe avant de créer une instance complète de présentation.

**Une application peut‑elle lire les métadonnées sans le mot de passe d'ouverture ?**

Oui, mais uniquement lorsque la présentation a été chiffrée avec le chiffrement des propriétés du document désactivé. L’application doit alors utiliser le mode de chargement « document‑properties‑only » décrit dans [Gérer les propriétés de la présentation](/slides/fr/php-java/presentation-properties/).

**Les flux de travail de vérification du mot de passe prennent‑ils en charge à la fois PPT et PPTX ?**

Oui. La détection et la validation du mot de passe basées sur le chemin de fichier ou le flux se comportent de la même manière pour les présentations PPT et PPTX.