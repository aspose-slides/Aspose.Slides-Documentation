---
title: Protection en écriture des présentations en PHP
linktitle: Protection en écriture
type: docs
weight: 25
url: /fr/php-java/write-protected-presentation/
keywords:
- protection en écriture
- PowerPoint protégé en écriture
- mot de passe pour modifier
- restreindre la modification de la présentation
- supprimer la protection en écriture
- valider le mot de passe de modification
- PowerPoint
- présentation
- PHP
- Aspose.Slides
description: "Définir, détecter, valider et supprimer les mots de passe de protection en écriture dans les présentations PowerPoint PPT et PPTX à l'aide d'Aspose.Slides pour PHP."
---
## **Introduction**

Un mot de passe de protection en écriture restreint la modification d’une présentation mais n’en chiffre pas le contenu. Les utilisateurs peuvent charger et afficher une présentation protégée en écriture sans le mot de passe. Selon l’application, ils peuvent également modifier le contenu et l’enregistrer sous un autre nom, de sorte que la protection en écriture ne doit pas être considérée comme un mécanisme de confidentialité.

Un mot de passe d’ouverture sert à un autre but : il chiffre la présentation et est requis pour charger son contenu. Pour chiffrer une présentation ou valider un mot de passe d’ouverture, voir [Password-Protect Presentations](/slides/fr/php-java/password-protected-presentation/).

Les flux de travail de cet article s’appliquent aux présentations PPT et PPTX. Les exemples utilisent des fichiers PPTX ; lors de l’enregistrement au format PPT, utilisez l’extension `.ppt` et le format d’enregistrement PPT correspondant.

## **Set Write Protection on a Presentation**

Utilisez [ProtectionManager::setWriteProtection](https://reference.aspose.com/slides/fr/php-java/aspose.slides/protectionmanager/#setWriteProtection) pour attribuer un mot de passe à la modification d’une présentation. L’enregistrement de la présentation conserve le paramètre de protection.

L’exemple suivant définit la protection en écriture sur une présentation PPTX :

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("pres.pptx");
try {
    $presentation->getProtectionManager()->setWriteProtection("modify_password");
    $presentation->save("write-protected-pres.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Load a Write-Protected Presentation**

Parce que la protection en écriture ne chiffre pas le contenu de la présentation, aucun mot de passe n’est requis pour charger la présentation. Le mot de passe n’est pertinent que lors de la validation de l’autorisation de modifier la présentation protégée.

```php
use aspose\slides\Presentation;

$presentation = new Presentation("write-protected-pres.pptx");
try {
    echo("Slide count: " . $presentation->getSlides()->size() . "\n");
} finally {
    $presentation->dispose();
}
```

Ne passez pas de mot de passe de protection en écriture à [LoadOptions::setPassword](https://reference.aspose.com/slides/fr/php-java/aspose.slides/loadoptions/#setPassword). Cette méthode accepte un mot de passe d’ouverture pour le contenu chiffré. Si une présentation possède les deux types de protection, fournissez le mot de passe d’ouverture pour la charger et traitez séparément le mot de passe de protection en écriture.

## **Remove Write Protection from a Presentation**

Utilisez [ProtectionManager::removeWriteProtection](https://reference.aspose.com/slides/fr/php-java/aspose.slides/protectionmanager/#removeWriteProtection) pour supprimer la restriction de modification, puis enregistrez la présentation.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("write-protected-pres.pptx");
try {
    $presentation->getProtectionManager()->removeWriteProtection();
    $presentation->save("write-protection-removed.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Check Whether a Presentation Is Write Protected**

Pour inspecter un fichier sans créer une instance complète de [Presentation](/slides/fr/php-java/aspose.slides/presentation/), appelez [PresentationFactory::getPresentationInfo](https://reference.aspose.com/slides/fr/php-java/aspose.slides/presentationfactory/#getPresentationInfo) et examinez [PresentationInfo::isWriteProtected](https://reference.aspose.com/slides/fr/php-java/aspose.slides/presentationinfo/#isWriteProtected). La méthode utilise [NullableBool](https://reference.aspose.com/slides/fr/php-java/aspose.slides/nullablebool/) et renvoie `NullableBool::True` lorsqu’une protection en écriture est détectée.

```php
use aspose\slides\NullableBool;
use aspose\slides\PresentationFactory;

$presentationInfo = PresentationFactory::getInstance()->getPresentationInfo("write-protected-pres.pptx");

if ($presentationInfo->isWriteProtected() == NullableBool::True) {
    echo("The presentation is write protected.\n");
} else {
    echo("Write protection was not detected.\n");
}
```

La surcharge flux de [PresentationFactory::getPresentationInfo](https://reference.aspose.com/slides/fr/php-java/aspose.slides/presentationfactory/#getPresentationInfo) fournit les mêmes informations pour une présentation fournie sous forme de flux.

## **Validate a Write-Protection Password**

Utilisez [PresentationInfo::checkWriteProtection](https://reference.aspose.com/slides/fr/php-java/aspose.slides/presentationinfo/#checkWriteProtection) pour valider un mot de passe de modification sans charger la présentation complète. Vérifiez d’abord [PresentationInfo::isWriteProtected](https://reference.aspose.com/slides/fr/php-java/aspose.slides/presentationinfo/#isWriteProtected) afin que l’application ne demande ou ne valide un mot de passe que lorsqu’une protection en écriture est présente.

```php
use aspose\slides\NullableBool;
use aspose\slides\PresentationFactory;

$presentationInfo = PresentationFactory::getInstance()->getPresentationInfo("write-protected-pres.pptx");

if ($presentationInfo->isWriteProtected() != NullableBool::True) {
    echo("The presentation is not write protected.\n");
} elseif ($presentationInfo->checkWriteProtection("modify_password")) {
    echo("The write-protection password is correct.\n");
} else {
    echo("The write-protection password is incorrect.\n");
}
```

[PresentationInfo::checkWriteProtection](https://reference.aspose.com/slides/fr/php-java/aspose.slides/presentationinfo/#checkWriteProtection) ne valide que le mot de passe de protection en écriture. Il ne valide pas un mot de passe d’ouverture ni ne détermine si le contenu chiffré peut être chargé. Inversement, [PresentationInfo::checkPassword](https://reference.aspose.com/slides/fr/php-java/aspose.slides/presentationinfo/#checkPassword) ne valide que le mot de passe d’ouverture. Si une présentation complète a déjà été chargée, [ProtectionManager::checkWriteProtection](https://reference.aspose.com/slides/fr/php-java/aspose.slides/protectionmanager/#checkWriteProtection) fournit le même contrôle de protection en écriture via son gestionnaire de protection.

En production, ne consignez pas les mots de passe et ne les incluez pas dans les messages de diagnostic. Évitez les tentatives de validation répétées inutiles et ne conservez les mots de passe en mémoire que le temps strictement nécessaire.

{{% alert color="info" title="Voir aussi" %}}
- [Protections par mot de passe des présentations](/slides/fr/php-java/password-protected-presentation/)
- [Présentations en lecture seule](/slides/fr/php-java/read-only-presentation/)
- [Signature numérique dans PowerPoint](/slides/fr/php-java/digital-signature-in-powerpoint/)
{{% /alert %}}

## **FAQ**

**La protection en écriture chiffre‑t‑elle une présentation ?**

Non. Elle restreint la modification mais laisse le contenu de la présentation disponible pour le chargement et l’affichage.

**Le mot de passe de protection en écriture est‑il requis pour ouvrir une présentation ?**

Non. Seul un mot de passe d’ouverture est requis pour charger le contenu chiffré d’une présentation.

**Une présentation peut‑elle avoir à la fois un mot de passe d’ouverture et un mot de passe de protection en écriture ?**

Oui. Fournissez le mot de passe d’ouverture via les options de chargement pour ouvrir la présentation chiffrée, et validez séparément le mot de passe de protection en écriture lorsque l’autorisation de modification est nécessaire.