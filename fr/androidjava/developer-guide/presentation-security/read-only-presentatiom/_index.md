---
title: Enregistrer des présentations en mode lecture seule sur Android
linktitle: Présentation en lecture seule
type: docs
weight: 30
url: /fr/androidjava/read-only-presentation/
keywords:
- lecture seule
- protéger la présentation
- empêcher la modification
- PowerPoint
- OpenDocument
- présentation
- Android
- Java
- Aspose.Slides
description: "Enregistrez les fichiers PowerPoint (PPT, PPTX) en mode lecture seule avec Aspose.Slides pour Android via Java, offrant des aperçus de diapositives précis sans modifier vos présentations."
---

## **Appliquer le mode lecture seule**

Dans PowerPoint 2019, Microsoft a introduit le paramètre **Always Open Read-Only** comme l’une des options que les utilisateurs peuvent utiliser pour protéger leurs présentations. Vous pourriez vouloir utiliser ce paramètre Lecture seule pour protéger une présentation lorsque

- Vous voulez éviter les modifications accidentelles et garder le contenu de votre présentation en sécurité.
- Vous voulez avertir les personnes que la présentation que vous avez fournie est la version finale.

Après avoir sélectionné l’option **Always Open Read-Only** pour une présentation, lorsque les utilisateurs l’ouvrent, ils voient la recommandation **Read-Only** et peuvent voir un message sous cette forme : *Pour éviter les modifications accidentelles, l'auteur a défini ce fichier pour s'ouvrir en lecture seule.*

La recommandation **Read-Only** est un moyen simple mais efficace qui décourage l’édition, car les utilisateurs doivent effectuer une tâche pour la supprimer avant de pouvoir modifier une présentation. Si vous ne souhaitez pas que les utilisateurs apportent des modifications à une présentation et que vous voulez le leur indiquer de manière polie, alors la recommandation **Read-Only** peut être une bonne option pour vous.

> Si une présentation protégée par **Read-Only** est ouverte dans une ancienne version de Microsoft PowerPoint—qui ne prend pas en charge la fonction récemment introduite—la recommandation **Read-Only** est ignorée (la présentation s'ouvre normalement).

Aspose.Slides for Android via Java vous permet de définir une présentation en **Read-Only**, ce qui signifie que les utilisateurs (une fois la présentation ouverte) voient la recommandation **Read-Only**. Ce code d'exemple montre comment définir une présentation en **Read-Only** en Java avec Aspose.Slides :
```java
Presentation pres = new Presentation();
try {
    pres.getProtectionManager().setReadOnlyRecommended(true);
    pres.save("ReadOnlyPresentation.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


{{% alert color="primary" %}} 
**Note** : La recommandation **Read-Only** vise simplement à décourager l’édition ou à empêcher les utilisateurs de faire des modifications accidentelles d’une présentation PowerPoint. Si une personne motivée—qui sait ce qu’elle fait—décide d’éditer votre présentation, elle peut facilement supprimer le paramètre Read-Only. Si vous devez réellement empêcher les modifications non autorisées, il est préférable d’utiliser [des protections plus strictes impliquant des encryptions et des mots de passe](https://docs.aspose.com/slides/androidjava/password-protected-presentation/).
{{% /alert %}} 

## **FAQ**

**Comment le 'Read-Only recommended' diffère-t-il d’une protection par mot de passe complète ?**

`Read-Only recommended` ne fait qu’afficher une suggestion d’ouvrir le fichier en mode lecture seule et est facile à contourner. [Protection par mot de passe](/slides/fr/androidjava/password-protected-presentation/) restreint réellement l’ouverture ou la modification et est approprié lorsque vous avez besoin de véritables contrôles de sécurité.

**Le 'Read-Only recommended' peut-il être combiné avec des filigranes pour décourager davantage les modifications ?**

Oui. La recommandation peut être associée aux [filigranes](/slides/fr/androidjava/watermark/) comme un moyen visuel de dissuasion ; ils sont des mécanismes séparés et fonctionnent bien ensemble.

**Une macro ou un outil externe peut-il encore modifier le fichier lorsque la recommandation est activée ?**

Oui. La recommandation ne bloque pas les modifications programmatiques. Pour empêcher les éditions automatisées, utilisez [mots de passe et chiffrement](/slides/fr/androidjava/password-protected-presentation/).

**Comment le 'Read-Only recommended' se rapporte-t-il aux méthodes 'isEncrypted' et 'isWriteProtected' ?**

Ce sont des signaux différents. `Read-Only recommended` est une invite douce et facultative ; [isWriteProtected](https://reference.aspose.com/slides/androidjava/com.aspose.slides/protectionmanager/#isWriteProtected--) et [isEncrypted](https://reference.aspose.com/slides/androidjava/com.aspose.slides/protectionmanager/#isEncrypted--) indiquent des restrictions d’écriture ou de lecture réelles qui dépendent de mots de passe ou de chiffrement.