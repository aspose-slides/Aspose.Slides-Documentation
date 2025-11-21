---
title: Présentation en lecture seule
type: docs
weight: 30
url: /fr/net/read-only-presentation/
keywords: "Paramètre en lecture seule, présentation PowerPoint, C#, Csharp, Aspose.Slides pour .NET"
description: "Présentation PowerPoint en lecture seule en C# ou .NET"
---

## **Appliquer le mode Lecture seule**

Dans PowerPoint 2019, Microsoft a introduit le paramètre **Always Open Read-Only** comme l'une des options que les utilisateurs peuvent utiliser pour protéger leurs présentations. Vous pouvez vouloir utiliser ce paramètre Lecture seule pour protéger une présentation lorsque

- Vous voulez empêcher les modifications accidentelles et garder le contenu de votre présentation en sécurité. 
- Vous voulez alerter les personnes que la présentation que vous avez fournie est la version finale. 

Après avoir sélectionné l'option **Always Open Read-Only** pour une présentation, lorsque les utilisateurs ouvrent la présentation, ils voient la recommandation **Read-Only** et peuvent voir un message sous cette forme : *Pour éviter les changements accidentels, l'auteur a configuré ce fichier pour qu'il s'ouvre en lecture seule.*

La recommandation Read-Only est un moyen simple mais efficace de décourager la modification car les utilisateurs doivent effectuer une action pour la supprimer avant de pouvoir éditer une présentation. Si vous ne voulez pas que les utilisateurs apportent des modifications à une présentation et souhaitez le leur indiquer de manière polie, alors la recommandation Read-Only peut être une bonne option pour vous. 

> Si une présentation protégée par **Read-Only** est ouverte dans une ancienne version de Microsoft PowerPoint—qui ne prend pas en charge la fonction récemment introduite—la recommandation **Read-Only** est ignorée (la présentation s'ouvre normalement).

Aspose.Slides for .NET vous permet de définir une présentation en **Read-Only**, ce qui signifie que les utilisateurs (après avoir ouvert la présentation) voient la recommandation **Read-Only**. Ce code d'exemple vous montre comment définir une présentation en **Read-Only** en C# avec Aspose.Slides :
```c#
using (Presentation pres = new Presentation())
{
    pres.ProtectionManager.ReadOnlyRecommended = true;
    pres.Save("ReadOnlyPresentation.pptx", SaveFormat.Pptx);
}
```


{{% alert color="primary" %}} 

**Note** : La recommandation **Read-Only** vise simplement à décourager l'édition ou à empêcher les utilisateurs d'apporter des modifications accidentelles à une présentation PowerPoint. Si une personne motivée—qui sait ce qu'elle fait—décide de modifier votre présentation, elle peut facilement supprimer le paramètre Read-Only. Si vous avez réellement besoin d'empêcher les modifications non autorisées, il est préférable d'utiliser [des protections plus strictes impliquant le chiffrement et les mots de passe](https://docs.aspose.com/slides/net/password-protected-presentation/). 

{{% /alert %}} 

## **FAQ**

**En quoi le 'Read-Only recommended' diffère-t-il d'une protection complète par mot de passe ?**  

'Read-Only recommended' ne fait qu'afficher une suggestion d'ouvrir le fichier en mode lecture seule et est facile à contourner. [Protection par mot de passe](/slides/fr/net/password-protected-presentation/) restreint réellement l'ouverture ou l'édition et convient lorsque vous avez besoin de véritables contrôles de sécurité.  

**Le 'Read-Only recommended' peut-il être combiné avec des filigranes pour décourager davantage les modifications ?**  

Oui. La recommandation peut être associée à des [filigranes](/slides/fr/net/watermark/) comme moyen de dissuasion visuel ; ils sont des mécanismes distincts et fonctionnent bien ensemble.  

**Une macro ou un outil externe peut-il encore modifier le fichier lorsque la recommandation est activée ?**  

Oui. La recommandation ne bloque pas les modifications programmatiques. Pour empêcher les éditions automatisées, utilisez des [mots de passe et chiffrement](/slides/fr/net/password-protected-presentation/).  

**Comment le 'Read-Only recommended' se rapporte-t-il aux indicateurs 'IsEncrypted' et 'IsWriteProtected' ?**  

Ce sont des signaux différents. 'Read-Only recommended' est une invite douce et optionnelle ; [IsWriteProtected](https://reference.aspose.com/slides/net/aspose.slides/protectionmanager/iswriteprotected/) et [IsEncrypted](https://reference.aspose.com/slides/net/aspose.slides/protectionmanager/isencrypted/) indiquent des restrictions réelles d'écriture ou de lecture qui dépendent de mots de passe ou de chiffrement.