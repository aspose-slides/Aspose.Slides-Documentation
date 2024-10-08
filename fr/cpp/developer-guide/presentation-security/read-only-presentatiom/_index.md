---
title: Présentation en lecture seule
type: docs
weight: 30
url: /fr/cpp/read-only-presentation/

---

Dans PowerPoint 2019, Microsoft a introduit le paramètre **Toujours ouvrir en lecture seule** comme l'une des options que les utilisateurs peuvent utiliser pour protéger leurs présentations. Vous voudrez peut-être utiliser ce paramètre de lecture seule pour protéger une présentation lorsque

- Vous souhaitez éviter les modifications accidentelles et conserver le contenu de votre présentation en sécurité.
- Vous souhaitez alerter les gens que la présentation que vous avez fournie est la version finale.

Après avoir sélectionné l'option **Toujours ouvrir en lecture seule** pour une présentation, lorsque les utilisateurs ouvriront la présentation, ils verront la recommandation **Lecture seule** et peuvent voir un message sous cette forme : *Pour éviter les modifications accidentelles, l'auteur a défini ce fichier pour s'ouvrir en lecture seule.*

La recommandation de lecture seule est un moyen simple mais efficace de dissuasion qui décourage l'édition, car les utilisateurs doivent effectuer une tâche pour la supprimer avant de pouvoir éditer une présentation. Si vous ne voulez pas que les utilisateurs apportent des modifications à une présentation et souhaitez leur en parler de manière polie, alors la recommandation de lecture seule peut être une bonne option pour vous.

> Si une présentation avec protection **Lecture seule** est ouverte dans une ancienne application Microsoft PowerPoint — qui ne prend pas en charge la fonction récemment introduite — la recommandation **Lecture seule** est ignorée (la présentation est ouverte normalement).

Aspose.Slides pour C++ vous permet de définir une présentation en **Lecture seule**, ce qui signifie que les utilisateurs (après avoir ouvert la présentation) voient la recommandation **Lecture seule**. Ce code d'exemple montre comment définir une présentation en **Lecture seule** en C++ à l'aide d'Aspose.Slides :

``` cpp
auto pres = System::MakeObject<Presentation>();
pres->get_ProtectionManager()->set_ReadOnlyRecommended(true);
pres->Save(u"ReadOnlyPresentation.pptx", SaveFormat::Pptx);
```

{{% alert color="primary" %}} 

**Remarque** : La recommandation **Lecture seule** est simplement destinée à dissuader l'édition ou à empêcher les utilisateurs d'apporter des modifications accidentelles à une présentation PowerPoint. Si une personne motivée — qui sait ce qu'elle fait — décide d'éditer votre présentation, elle peut facilement supprimer le paramètre de lecture seule. Si vous devez sérieusement empêcher l'édition non autorisée, il est préférable d'utiliser [des protections plus strictes qui impliquent des encryptions et des mots de passe](https://docs.aspose.com/slides/cpp/password-protected-presentation/). 

{{% /alert %}}