---
title: Enregistrer les présentations en mode lecture seule avec PHP
linktitle: Présentation en lecture seule
type: docs
weight: 30
url: /fr/php-java/read-only-presentation/
keywords:
- lecture seule
- protéger la présentation
- empêcher la modification
- PowerPoint
- OpenDocument
- présentation
- PHP
- Aspose.Slides
description: "Chargez et enregistrez des fichiers PowerPoint (PPT, PPTX) en mode lecture seule avec Aspose.Slides pour PHP, offrant des aperçus de diapositives précis sans modifier vos présentations."
---

## **Appliquer le mode lecture seule**

Dans PowerPoint 2019, Microsoft a introduit le paramètre **Always Open Read-Only** comme l'une des options que les utilisateurs peuvent utiliser pour protéger leurs présentations. Vous pourriez vouloir utiliser ce paramètre Read-Only pour protéger une présentation lorsque

- Vous souhaitez éviter les modifications accidentelles et garder le contenu de votre présentation en sécurité. 
- Vous voulez informer les personnes que la présentation que vous avez fournie est la version finale. 

Après avoir sélectionné l'option **Always Open Read-Only** pour une présentation, lorsque les utilisateurs ouvrent la présentation, ils voient la recommandation **Read-Only** et peuvent voir un message sous la forme suivante : *Pour éviter les modifications accidentelles, l'auteur a configuré ce fichier pour s'ouvrir en lecture seule.*

La recommandation **Read-Only** est un moyen simple mais efficace de décourager la modification, car les utilisateurs doivent effectuer une action pour la supprimer avant de pouvoir éditer une présentation. Si vous ne voulez pas que les utilisateurs modifient une présentation et que vous souhaitez le leur indiquer de manière polie, alors la recommandation **Read-Only** peut être une bonne option pour vous. 

> Si une présentation protégée par **Read-Only** est ouverte dans une version plus ancienne de Microsoft PowerPoint—qui ne prend pas en charge la fonction récemment introduite—la recommandation **Read-Only** est ignorée (la présentation s'ouvre normalement).

Aspose.Slides for PHP via Java vous permet de définir une présentation en **Read-Only**, ce qui signifie que les utilisateurs (une fois la présentation ouverte) voient la recommandation **Read-Only**. Ce code d'exemple montre comment définir une présentation en **Read-Only** à l'aide d'Aspose.Slides :
```php
  $pres = new Presentation();
  try {
    $pres->getProtectionManager()->setReadOnlyRecommended(true);
    $pres->save("ReadOnlyPresentation.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


{{% alert color="primary" %}} 

**Remarque** : La recommandation **Read-Only** a simplement pour but de décourager les modifications ou d'empêcher les utilisateurs d'apporter des changements accidentels à une présentation PowerPoint. Si une personne motivée—qui sait ce qu'elle fait—décide de modifier votre présentation, elle peut facilement supprimer le paramètre Read-Only. Si vous devez réellement empêcher les modifications non autorisées, il est préférable d'utiliser [des protections plus strictes impliquant des chiffrages et des mots de passe](https://docs.aspose.com/slides/php-java/password-protected-presentation/).

{{% /alert %}} 

## **FAQ**

**Comment le « Read-Only recommended » diffère-t-il d’une protection par mot de passe complète ?**

« Read-Only recommended » n'affiche qu'une suggestion d'ouvrir le fichier en mode lecture seule et il est facile de la contourner. [Password protection](/slides/fr/php-java/password-protected-presentation/) restreint réellement l'ouverture ou la modification et convient lorsque vous avez besoin de véritables contrôles de sécurité.

**Le « Read-Only recommended » peut-il être combiné avec des filigranes pour décourager davantage les modifications ?**

Oui. La recommandation peut être associée à des [watermarks](/slides/fr/php-java/watermark/) comme dissuasion visuelle ; ce sont des mécanismes séparés qui fonctionnent bien ensemble.

**Une macro ou un outil externe peut-il encore modifier le fichier lorsque la recommandation est activée ?**

Oui. La recommandation ne bloque pas les changements programmatiques. Pour empêcher les modifications automatisées, utilisez [passwords and encryption](/slides/fr/php-java/password-protected-presentation/).

**Comment le « Read-Only recommended » se rapporte-t-il aux méthodes « isEncrypted » et « isWriteProtected » ?**

Ce sont des signaux différents. « Read-Only recommended » est une invite douce et facultative ; [isWriteProtected](https://reference.aspose.com/slides/php-java/aspose.slides/protectionmanager/iswriteprotected/) et [isEncrypted](https://reference.aspose.com/slides/php-java/aspose.slides/protectionmanager/isencrypted/) indiquent des restrictions réelles d'écriture ou de lecture qui dépendent de mots de passe ou de chiffrement.