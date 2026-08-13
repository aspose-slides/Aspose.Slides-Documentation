---
title: Enregistrer les présentations en mode lecture seule dans .NET
linktitle: Présentation en lecture seule
type: docs
weight: 30
url: /fr/net/read-only-presentation/
keywords:
- lecture seule
- protéger la présentation
- prévenir la modification
- PowerPoint
- OpenDocument
- présentation
- .NET
- C#
- Aspose.Slides
description: "Chargez et enregistrez des fichiers PowerPoint (PPT, PPTX) en mode lecture seule avec Aspose.Slides pour .NET, offrant des aperçus précis des diapositives sans modifier vos présentations."
---
## **Introduction**

Dans PowerPoint 2019, Microsoft a introduit le paramètre **Always Open Read-Only** comme l’une des options que les utilisateurs peuvent utiliser pour protéger leurs présentations. Vous pouvez souhaiter utiliser ce paramètre **Read-Only** pour protéger une présentation lorsque

- Vous voulez éviter les modifications accidentelles et garder le contenu de votre présentation en sécurité. 
- Vous voulez informer les gens que la présentation que vous avez fournie est la version finale. 

Après avoir sélectionné l’option **Always Open Read-Only** pour une présentation, lorsque les utilisateurs ouvrent la présentation, ils voient la recommandation **Read-Only** et peuvent voir un message sous cette forme : *Pour éviter les modifications accidentelles, l’auteur a configuré ce fichier pour qu’il s’ouvre en lecture seule.*

La recommandation **Read-Only** est un moyen simple mais efficace de décourager la modification, car les utilisateurs doivent effectuer une action pour la supprimer avant de pouvoir modifier une présentation. Si vous ne voulez pas que les utilisateurs apportent des modifications à une présentation et souhaitez le leur indiquer de manière polie, alors la recommandation **Read-Only** peut être une bonne option pour vous. 

> Si une présentation protégée par **Read-Only** est ouverte dans une ancienne version de Microsoft PowerPoint—qui ne prend pas en charge la fonction récemment introduite—la recommandation **Read-Only** est ignorée (la présentation s’ouvre normalement).

## **Appliquer le mode Read-Only**

Aspose.Slides pour .NET vous permet de définir une présentation en **Read-Only**, ce qui signifie que les utilisateurs (après avoir ouvert la présentation) voient la recommandation **Read-Only**. Ce code d’exemple montre comment définir une présentation en **Read-Only** en C# avec Aspose.Slides :

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

using (Presentation pres = new Presentation())
{
    pres.ProtectionManager.ReadOnlyRecommended = true;
    pres.Save("ReadOnlyPresentation.pptx", SaveFormat.Pptx);
}
```

{{% alert color="info" %}} 

**Note** : La recommandation **Read-Only** vise simplement à décourager la modification ou à empêcher les utilisateurs d’apporter des changements accidentels à une présentation PowerPoint. Si une personne motivée—qui sait ce qu’elle fait—décide de modifier votre présentation, elle peut facilement supprimer le paramètre Read-Only. Si vous devez réellement empêcher les modifications non autorisées, il vaut mieux utiliser [protections plus strictes impliquant des encryptions et des mots de passe](https://docs.aspose.com/slides/fr/net/password-protected-presentation/). 

{{% /alert %}} 

## **FAQ**

### En quoi le « Read-Only recommended » diffère-t-il d’une protection par mot de passe complète ?

« Read-Only recommended » ne fait qu’afficher une suggestion d’ouvrir le fichier en mode lecture seule et est facile à contourner. [Protection par mot de passe](/slides/fr/net/password-protected-presentation/) restreint réellement l’ouverture ou la modification et convient lorsque vous avez besoin de véritables contrôles de sécurité.

### Le « Read-Only recommended » peut-il être combiné avec des filigranes pour décourager davantage les modifications ?

Oui. La recommandation peut être associée à [filigranes](/slides/fr/net/watermark/) comme moyen de dissuasion visuel ; ils sont des mécanismes distincts et fonctionnent bien ensemble.

### Une macro ou un outil externe peut-il toujours modifier le fichier lorsque la recommandation est activée ?

Oui. La recommandation ne bloque pas les modifications programmatiques. Pour empêcher les modifications automatisées, utilisez [mots de passe et chiffrement](/slides/fr/net/password-protected-presentation/).

### Comment le « Read-Only recommended » se rapporte-t-il aux indicateurs « IsEncrypted » et « IsWriteProtected » ?

Ils sont des signaux différents. « Read-Only recommended » est une invite souple et optionnelle ; [IsWriteProtected](https://reference.aspose.com/slides/fr/net/aspose.slides/protectionmanager/iswriteprotected/) et [IsEncrypted](https://reference.aspose.com/slides/fr/net/aspose.slides/protectionmanager/isencrypted/) indiquent des restrictions réelles d’écriture ou de lecture qui dépendent de mots de passe ou de chiffrement.