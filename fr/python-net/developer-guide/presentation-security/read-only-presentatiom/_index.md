---
title: Présentation en Lecture Seule
type: docs
weight: 30
url: /python-net/read-only-presentation/
keywords: "Paramètre en lecture seule, présentation PowerPoint, Python, Aspose.Slides pour Python via .NET"
description: "Présentation PowerPoint en lecture seule en Python"
---

Dans PowerPoint 2019, Microsoft a introduit le paramètre **Toujours Ouvrir en Lecture Seule** comme l'une des options que les utilisateurs peuvent utiliser pour protéger leurs présentations. Vous pouvez souhaiter utiliser ce paramètre en lecture seule pour protéger une présentation lorsque

- Vous souhaitez éviter des modifications accidentelles et garder le contenu de votre présentation en sécurité.
- Vous souhaitez alerter les personnes que la présentation que vous avez fournie est la version finale.

Après avoir sélectionné l'option **Toujours Ouvrir en Lecture Seule** pour une présentation, lorsque les utilisateurs ouvrent la présentation, ils voient la recommandation **Lecture Seule** et peuvent voir un message sous cette forme : *Pour éviter des modifications accidentelles, l'auteur a défini ce fichier pour s'ouvrir en lecture seule.*

La recommandation en lecture seule est un moyen simple mais efficace de décourager l'édition car les utilisateurs doivent effectuer une tâche pour la supprimer avant d'être autorisés à modifier une présentation. Si vous ne souhaitez pas que les utilisateurs apportent des modifications à une présentation et souhaitez leur en parler de manière polie, alors la recommandation en lecture seule peut être une bonne option pour vous.

> Si une présentation avec la protection **Lecture Seule** est ouverte dans une ancienne application Microsoft PowerPoint—qui ne prend pas en charge la fonction récemment introduite—la recommandation **Lecture Seule** est ignorée (la présentation s'ouvre normalement).

Aspose.Slides pour Python via .NET vous permet de définir une présentation en **Lecture Seule**, ce qui signifie que les utilisateurs (après avoir ouvert la présentation) voient la recommandation **Lecture Seule**. Ce code d'exemple vous montre comment définir une présentation en **Lecture Seule** en Python en utilisant Aspose.Slides :

```py
import aspose.slides as slides

with slides.Presentation() as pres:
    pres.protection_manager.read_only_recommended = True
    pres.save("ReadOnlyPresentation.pptx", slides.export.SaveFormat.PPTX)
```

{{% alert color="primary" %}} 

**Remarque** : La recommandation **Lecture Seule** est simplement destinée à décourager l'édition ou à empêcher les utilisateurs d'apporter des modifications accidentelles à une présentation PowerPoint. Si une personne motivée—qui sait ce qu'elle fait—décide de modifier votre présentation, elle peut facilement supprimer le paramètre en lecture seule. Si vous devez sérieusement empêcher la modification non autorisée, il vaut mieux utiliser [des protections plus strictes impliquant des encryptions et des mots de passe](https://docs.aspose.com/slides/python-net/password-protected-presentation/). 

{{% /alert %}} 