---
title: Enregistrer les présentations en mode lecture seule avec Java
linktitle: Présentation en lecture seule
type: docs
weight: 30
url: /fr/java/read-only-presentation/
keywords:
- lecture seule
- protéger la présentation
- empêcher la modification
- PowerPoint
- OpenDocument
- présentation
- Java
- Aspose.Slides
description: "Chargez et enregistrez des fichiers PowerPoint (PPT, PPTX) en mode lecture seule avec Aspose.Slides pour Java, offrant des aperçus précis des diapositives sans modifier vos présentations."
---
## **Introduction**

Dans PowerPoint 2019, Microsoft a introduit le paramètre **Always Open Read-Only** comme l’une des options que les utilisateurs peuvent utiliser pour protéger leurs présentations. Vous pourriez vouloir utiliser ce paramètre Lecture seule pour protéger une présentation lorsque  

- Vous voulez empêcher les modifications accidentelles et garder le contenu de votre présentation en sécurité.  
- Vous voulez avertir les personnes que la présentation que vous avez fournie est la version finale.  

Après avoir sélectionné l’option **Always Open Read-Only** pour une présentation, lorsque les utilisateurs ouvrent la présentation, ils voient la recommandation **Read-Only** et peuvent voir un message sous la forme : *Pour éviter les modifications accidentelles, l’auteur a configuré ce fichier pour qu’il s’ouvre en lecture seule.*  

La recommandation **Read-Only** est un moyen simple mais efficace de décourager la modification, car les utilisateurs doivent effectuer une action pour la supprimer avant de pouvoir modifier la présentation. Si vous ne voulez pas que les utilisateurs modifient une présentation et souhaitez le leur indiquer poliment, alors la recommandation **Read-Only** peut être une bonne option pour vous.  

> Si une présentation protégée par **Read-Only** est ouverte dans une ancienne version de Microsoft PowerPoint—qui ne prend pas en charge la fonction récemment introduite—la recommandation **Read-Only** est ignorée (la présentation s’ouvre normalement).  

## **Appliquer le mode Lecture seule**

Aspose.Slides for Java vous permet de définir une présentation en **Read-Only**, ce qui signifie que les utilisateurs (après avoir ouvert la présentation) voient la recommandation **Read-Only**. Ce code d’exemple vous montre comment définir une présentation en **Read-Only** en Java avec Aspose.Slides :

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

**Note** : La recommandation **Read-Only** vise simplement à décourager la modification ou à empêcher les utilisateurs d’effectuer des changements accidentels dans une présentation PowerPoint. Si une personne motivée—qui sait ce qu’elle fait—décide de modifier votre présentation, elle peut facilement supprimer le paramètre Lecture seule. Si vous devez réellement empêcher les modifications non autorisées, il est préférable d’utiliser [des protections plus strictes impliquant le chiffrement et des mots de passe](https://docs.aspose.com/slides/fr/java/password-protected-presentation/). 

{{% /alert %}} 

## **FAQ**

### En quoi le « Read-Only recommended » diffère-t-il d’une protection par mot de passe complète ?

« Read-Only recommended » ne fait qu’afficher une suggestion d’ouvrir le fichier en mode lecture seule et il est facile de la contourner. [Password protection](/slides/fr/java/password-protected-presentation/) restreint réellement l’ouverture ou la modification et convient lorsque vous avez besoin de véritables contrôles de sécurité.  

### Le « Read-Only recommended » peut-il être combiné avec des filigranes pour décourager davantage les modifications ?

Oui. La recommandation peut être associée à des [watermarks](/slides/fr/java/watermark/) comme moyen de dissuasion visuelle ; ce sont des mécanismes séparés qui fonctionnent bien ensemble.  

### Une macro ou un outil externe peut-il toujours modifier le fichier lorsque la recommandation est activée ?

Oui. La recommandation ne bloque pas les modifications programmatiques. Pour empêcher les éditions automatisées, utilisez des [mots de passe et chiffrement](/slides/fr/java/password-protected-presentation/).  

### Comment le « Read-Only recommended » se rapporte-t-il aux méthodes « isEncrypted » et « isWriteProtected » ?

Ils sont des indicateurs différents. « Read-Only recommended » est une invite douce et facultative ; [isWriteProtected](https://reference.aspose.com/slides/fr/java/com.aspose.slides/protectionmanager/#isWriteProtected--) et [isEncrypted](https://reference.aspose.com/slides/fr/java/com.aspose.slides/protectionmanager/#isEncrypted--) indiquent des restrictions réelles d’écriture ou de lecture qui dépendent de mots de passe ou de chiffrement.