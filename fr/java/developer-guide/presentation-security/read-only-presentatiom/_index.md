---
title: Présentation en Lecture Seule
type: docs
weight: 30
url: /fr/java/read-only-presentation/

---

Dans PowerPoint 2019, Microsoft a introduit le paramètre **Toujours Ouvrir en Lecture Seule** comme l'une des options que les utilisateurs peuvent utiliser pour protéger leurs présentations. Vous pouvez souhaiter utiliser ce paramètre Lecture Seule pour protéger une présentation lorsque

- Vous souhaitez empêcher les modifications accidentelles et garder le contenu de votre présentation en sécurité.
- Vous souhaitez alerter les personnes que la présentation que vous avez fournie est la version finale.

Après avoir sélectionné l'option **Toujours Ouvrir en Lecture Seule** pour une présentation, lorsque les utilisateurs ouvrent la présentation, ils voient la recommandation **Lecture Seule** et peuvent voir un message sous cette forme : *Pour éviter les modifications accidentelles, l'auteur a configuré ce fichier pour qu'il s'ouvre en lecture seule.*

La recommandation Lecture Seule est un moyen simple mais efficace de dissuasion contre l'édition, car les utilisateurs doivent effectuer une tâche pour la supprimer avant d'être autorisés à éditer une présentation. Si vous ne souhaitez pas que les utilisateurs apportent des modifications à une présentation et souhaitez leur en parler de manière polie, alors la recommandation Lecture Seule peut être une bonne option pour vous.

> Si une présentation avec la protection **Lecture Seule** est ouverte dans une ancienne application Microsoft PowerPoint—qui ne prend pas en charge la fonction récemment introduite—la recommandation **Lecture Seule** est ignorée (la présentation s'ouvre normalement).

Aspose.Slides pour Java vous permet de définir une présentation en **Lecture Seule**, ce qui signifie que les utilisateurs (après avoir ouvert la présentation) voient la recommandation **Lecture Seule**. Ce code d'exemple vous montre comment définir une présentation en **Lecture Seule** en Java en utilisant Aspose.Slides :

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

**Remarque** : La recommandation **Lecture Seule** vise simplement à dissuader l'édition ou à empêcher les utilisateurs de faire des modifications accidentelles sur une présentation PowerPoint. Si une personne motivée—qui sait ce qu'elle fait—décide d'éditer votre présentation, elle peut facilement supprimer le paramètre Lecture Seule. Si vous devez sérieusement empêcher l'édition non autorisée, il est préférable d'utiliser [des protections plus strictes impliquant des encryptions et des mots de passe](https://docs.aspose.com/slides/java/password-protected-presentation/). 

{{% /alert %}} 