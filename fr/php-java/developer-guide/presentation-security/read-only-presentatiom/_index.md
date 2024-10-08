---
title: Présentation en Lecture Seule
type: docs
weight: 30
url: /fr/php-java/read-only-presentation/

---

Dans PowerPoint 2019, Microsoft a introduit le paramètre **Toujours Ouvrir en Lecture Seule** comme l'une des options que les utilisateurs peuvent utiliser pour protéger leurs présentations. Vous pourriez vouloir utiliser ce paramètre en Lecture Seule pour protéger une présentation lorsque

- Vous voulez éviter les modifications accidentelles et garder le contenu de votre présentation en sécurité. 
- Vous voulez alerter les gens que la présentation que vous avez fournie est la version finale. 

Après avoir sélectionné l'option **Toujours Ouvrir en Lecture Seule** pour une présentation, lorsque les utilisateurs ouvrent la présentation, ils voient la recommandation **Lecture Seule** et peuvent voir un message sous cette forme : *Pour éviter les modifications accidentelles, l'auteur a configuré ce fichier pour l'ouvrir en lecture seule.*

La recommandation Lecture Seule est un moyen simple mais efficace de décourager l'édition, car les utilisateurs doivent effectuer une tâche pour la supprimer avant d'être autorisés à modifier une présentation. Si vous ne voulez pas que les utilisateurs apportent des modifications à une présentation et voulez leur dire cela de manière polie, alors la recommandation Lecture Seule pourrait être une bonne option pour vous.

> Si une présentation avec la protection **Lecture Seule** est ouverte dans une ancienne application Microsoft PowerPoint—qui ne prend pas en charge la fonction récemment introduite—la recommandation **Lecture Seule** est ignorée (la présentation est ouverte normalement).

Aspose.Slides pour PHP via Java vous permet de définir une présentation en **Lecture Seule**, ce qui signifie que les utilisateurs (après avoir ouvert la présentation) voient la recommandation **Lecture Seule**. Ce code d'exemple vous montre comment définir une présentation en **Lecture Seule** en utilisant Aspose.Slides :

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

**Remarque** : La recommandation **Lecture Seule** est simplement destinée à décourager l'édition ou à empêcher les utilisateurs de faire des modifications accidentelles à une présentation PowerPoint. Si une personne motivée—qui sait ce qu'elle fait—décide de modifier votre présentation, elle peut facilement supprimer le paramètre Lecture Seule. Si vous avez vraiment besoin d'empêcher l'édition non autorisée, il est préférable d'utiliser [des protections plus strictes impliquant des encryptions et des mots de passe](https://docs.aspose.com/slides/php-java/password-protected-presentation/).

{{% /alert %}} 