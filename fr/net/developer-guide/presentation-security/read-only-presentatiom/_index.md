---
title: Présentation en Lecture Seule
type: docs
weight: 30
url: /net/read-only-presentation/
keywords: "Paramètre en lecture seule, Présentation PowerPoint, C#, Csharp, Aspose.Slides pour .NET"
description: "Présentation PowerPoint en lecture seule en C# ou .NET"
---

Dans PowerPoint 2019, Microsoft a introduit le paramètre **Toujours Ouvrir en Lecture Seule** comme l'une des options que les utilisateurs peuvent utiliser pour protéger leurs présentations. Vous pouvez vouloir utiliser ce paramètre en Lecture Seule pour protéger une présentation lorsque

- Vous souhaitez empêcher les modifications accidentelles et garder le contenu de votre présentation en sécurité.
- Vous souhaitez alerter les gens que la présentation que vous avez fournie est la version finale.

Après avoir sélectionné l'option **Toujours Ouvrir en Lecture Seule** pour une présentation, lorsque les utilisateurs ouvrent la présentation, ils voient la recommandation **Lecture Seule** et peuvent voir un message sous cette forme : *Pour éviter les modifications accidentelles, l'auteur a défini ce fichier pour s'ouvrir en lecture seule.*

La recommandation en Lecture Seule est un moyen simple mais efficace de dissuasion qui décourage l'édition car les utilisateurs doivent effectuer une tâche pour la supprimer avant d'être autorisés à modifier une présentation. Si vous ne voulez pas que les utilisateurs apportent des modifications à une présentation et que vous souhaitez leur en parler de manière polie, alors la recommandation en Lecture Seule peut être une bonne option pour vous.

> Si une présentation avec la protection **Lecture Seule** est ouverte dans une ancienne application Microsoft PowerPoint—qui ne prend pas en charge la fonction récemment introduite—la recommandation **Lecture Seule** est ignorée (la présentation s'ouvre normalement).

Aspose.Slides pour .NET vous permet de définir une présentation en **Lecture Seule**, ce qui signifie que les utilisateurs (après avoir ouvert la présentation) voient la recommandation **Lecture Seule**. Ce code d'exemple vous montre comment définir une présentation en **Lecture Seule** en C# en utilisant Aspose.Slides :

```c#
using (Presentation pres = new Presentation())
{
    pres.ProtectionManager.ReadOnlyRecommended = true;
    pres.Save("ReadOnlyPresentation.pptx", SaveFormat.Pptx);
}
```

{{% alert color="primary" %}} 

**Remarque** : La recommandation **Lecture Seule** est simplement destinée à décourager l'édition ou à empêcher les utilisateurs d'apporter des modifications accidentelles à une présentation PowerPoint. Si une personne motivée—qui sait ce qu'elle fait—décide de modifier votre présentation, elle peut facilement supprimer le paramètre Lecture Seule. Si vous devez sérieusement empêcher l'édition non autorisée, il est préférable d'utiliser [des protections plus strictes impliquant des encryptions et des mots de passe](https://docs.aspose.com/slides/net/password-protected-presentation/).

{{% /alert %}}