---
title: Présentation en lecture seule
type: docs
weight: 30
url: /fr/nodejs-java/read-only-presentation/
---

## **Appliquer le mode lecture seule**

Dans PowerPoint 2019, Microsoft a introduit le paramètre **Always Open Read-Only** comme l’une des options que les utilisateurs peuvent utiliser pour protéger leurs présentations. Vous pourriez vouloir utiliser ce paramètre Lecture seule pour protéger une présentation lorsque

- Vous souhaitez empêcher les modifications accidentelles et garder le contenu de votre présentation en sécurité. 
- Vous souhaitez avertir les personnes que la présentation que vous avez fournie est la version finale. 

Après avoir sélectionné l’option **Always Open Read-Only** pour une présentation, lorsque les utilisateurs ouvrent la présentation, ils voient la recommandation **Read-Only** et peuvent voir un message sous cette forme : *To prevent accidental changes, the author has set this file to open as read-only.*

La recommandation **Read-Only** est un moyen simple mais efficace qui décourage la modification car les utilisateurs doivent effectuer une action pour la supprimer avant de pouvoir modifier une présentation. Si vous ne voulez pas que les utilisateurs modifient une présentation et souhaitez leur en informer de manière polie, alors la recommandation **Read-Only** peut être une bonne option pour vous. 

> Si une présentation protégée par **Read-Only** est ouverte dans une ancienne version de Microsoft PowerPoint—qui ne prend pas en charge la fonction récemment introduite—la recommandation **Read-Only** est ignorée (la présentation s’ouvre normalement).

Aspose.Slides for Node.js via Java vous permet de définir une présentation en **Read-Only**, ce qui signifie que les utilisateurs (après avoir ouvert la présentation) voient la recommandation **Read-Only**. Ce code d’exemple vous montre comment définir une présentation en **Read-Only** en JavaScript avec Aspose.Slides :
```javascript
var pres = new aspose.slides.Presentation();
try {
    pres.getProtectionManager().setReadOnlyRecommended(true);
    pres.save("ReadOnlyPresentation.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


{{% alert color="primary" %}} 

**Note** : La recommandation **Read-Only** a simplement pour but de décourager la modification ou d’empêcher les utilisateurs d’apporter des changements accidentels à une présentation PowerPoint. Si une personne motivée—qui sait ce qu’elle fait—décide de modifier votre présentation, elle peut facilement supprimer le paramètre Read-Only. Si vous devez vraiment empêcher les modifications non autorisées, il vaut mieux utiliser [des protections plus strictes qui impliquent des encryptions et des mots de passe](https://docs.aspose.com/slides/nodejs-java/password-protected-presentation/).

{{% /alert %}} 

## **FAQ**

**Comment le mode 'Read-Only recommended' diffère-t-il d’une protection par mot de passe complète ?**

'Read-Only recommended' ne fait qu’afficher une suggestion d’ouvrir le fichier en mode lecture seule et est facile à contourner. [Password protection](/slides/fr/nodejs-java/password-protected-presentation/) restreint réellement l’ouverture ou la modification et convient lorsque vous avez besoin de véritables contrôles de sécurité.

**Le mode 'Read-Only recommended' peut-il être combiné avec des filigranes pour décourager davantage les modifications ?**

Oui. La recommandation peut être associée à des [watermarks](/slides/fr/nodejs-java/watermark/) comme moyen visuel de dissuasion ; ils sont des mécanismes séparés et fonctionnent bien ensemble.

**Une macro ou un outil externe peut-il encore modifier le fichier lorsque la recommandation est activée ?**

Oui. La recommandation ne bloque pas les modifications programmatiques. Pour empêcher les modifications automatisées, utilisez [passwords and encryption](/slides/fr/nodejs-java/password-protected-presentation/).

**Comment le mode 'Read-Only recommended' se rapporte-t-il aux indicateurs 'IsEncrypted' et 'IsWriteProtected' ?**

Ce sont des signaux différents. 'Read-Only recommended' est une invite souple et facultative ; [isWriteProtected](https://reference.aspose.com/slides/nodejs-java/aspose.slides/protectionmanager/iswriteprotected/) et [isEncrypted](https://reference.aspose.com/slides/nodejs-java/aspose.slides/protectionmanager/isencrypted/) indiquent des restrictions réelles d’écriture ou de lecture qui dépendent de mots de passe ou de chiffrement.