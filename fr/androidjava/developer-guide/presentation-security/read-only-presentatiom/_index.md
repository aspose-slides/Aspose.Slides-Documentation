---
title: Enregistrer les présentations en mode lecture seule sur Android
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
description: "Enregistrez les fichiers PowerPoint (PPT, PPTX) en mode lecture seule avec Aspose.Slides for Android via Java, offrant des aperçus précis des diapositives sans modifier vos présentations."
---
## **Introduction**

Dans PowerPoint 2019, Microsoft a introduit le paramètre **Always Open Read-Only** comme l’une des options que les utilisateurs peuvent utiliser pour protéger leurs présentations. Vous pourriez vouloir utiliser ce paramètre Read-Only pour protéger une présentation lorsque

- Vous souhaitez empêcher les modifications accidentelles et garder le contenu de votre présentation en sécurité.
- Vous voulez avertir les personnes que la présentation que vous avez fournie est la version finale.

Après avoir sélectionné l’option **Always Open Read-Only** pour une présentation, lorsque les utilisateurs ouvrent la présentation, ils voient la recommandation **Read-Only** et peuvent voir un message sous cette forme : *Pour éviter les modifications accidentelles, l’auteur a configuré ce fichier pour qu’il s’ouvre en lecture seule.*

La recommandation **Read-Only** est un moyen simple mais efficace de dissuader la modification, car les utilisateurs doivent effectuer une tâche pour la supprimer avant de pouvoir éditer une présentation. Si vous ne voulez pas que les utilisateurs modifient une présentation et souhaitez leur indiquer cela de manière polie, alors la recommandation **Read-Only** peut être une bonne option pour vous.

> Si une présentation protégée par **Read-Only** est ouverte dans une ancienne version de Microsoft PowerPoint—qui ne prend pas en charge la fonction récemment introduite—la recommandation **Read-Only** est ignorée (la présentation s’ouvre normalement).

## **Appliquer le mode Read-Only**

Aspose.Slides for Android via Java vous permet de définir une présentation en **Read-Only**, ce qui signifie que les utilisateurs (une fois la présentation ouverte) voient la recommandation **Read-Only**. Ce code d’exemple montre comment définir une présentation en **Read-Only** en Java avec Aspose.Slides :

```java
import com.aspose.slides.*;

Presentation pres = new Presentation();
try {
    pres.getProtectionManager().setReadOnlyRecommended(true);
    pres.save("ReadOnlyPresentation.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

{{% alert color="info" %}} 

**Note** : La recommandation **Read-Only** vise simplement à décourager la modification ou à empêcher les utilisateurs d’apporter des changements accidentels à une présentation PowerPoint. Si une personne motivée—qui sait ce qu’elle fait—décide de modifier votre présentation, elle peut facilement supprimer le paramètre Read-Only. Si vous avez vraiment besoin d’empêcher les modifications non autorisées, il vaut mieux utiliser [des protections plus strictes impliquant chiffrement et mots de passe](https://docs.aspose.com/slides/fr/androidjava/password-protected-presentation/).

{{% /alert %}} 

## **FAQ**

### En quoi la 'Read-Only recommended' diffère-t-elle d’une protection par mot de passe complète ?

La « Read-Only recommended » ne fait qu’afficher une suggestion d’ouvrir le fichier en mode lecture seule et est facile à contourner. [Protection par mot de passe](/slides/fr/androidjava/password-protected-presentation/) restreint réellement l’ouverture ou la modification et convient lorsque vous avez besoin de véritables contrôles de sécurité.

### La 'Read-Only recommended' peut-elle être combinée avec des filigranes pour décourager davantage les modifications ?

Oui. La recommandation peut être associée aux [filigranes](/slides/fr/androidjava/watermark/) comme moyen de dissuasion visuel ; ce sont des mécanismes distincts qui fonctionnent bien ensemble.

### Une macro ou un outil externe peut-il encore modifier le fichier lorsque la recommandation est activée ?

Oui. La recommandation ne bloque pas les modifications programmatiques. Pour empêcher les modifications automatisées, utilisez les [mots de passe et chiffrement](/slides/fr/androidjava/password-protected-presentation/).

### Comment la 'Read-Only recommended' se rapporte-t-elle aux méthodes 'isEncrypted' et 'isWriteProtected' ?

Elles sont des signaux différents. La « Read-Only recommended » est une invite souple et facultative ; [isWriteProtected](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/protectionmanager/#isWriteProtected--) et [isEncrypted](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/protectionmanager/#isEncrypted--) indiquent des restrictions réelles d’écriture ou de lecture qui dépendent de mots de passe ou de chiffrement.