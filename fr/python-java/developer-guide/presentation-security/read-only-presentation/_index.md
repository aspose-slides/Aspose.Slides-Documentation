---
title: Enregistrer les présentations en mode lecture seule avec Python
linktitle: Présentation en lecture seule
type: docs
weight: 30
url: /fr/python-java/read-only-presentation/
keywords:
- lecture seule
- protéger la présentation
- empêcher la modification
- PowerPoint
- OpenDocument
- présentation
- Python
- Aspose.Slides
description: "Chargez et enregistrez des fichiers PowerPoint (PPT, PPTX) en mode lecture seule avec Aspose.Slides for Python via Java, offrant des aperçus précis des diapositives sans altérer vos présentations."
---
## **Introduction**

Dans PowerPoint 2019, Microsoft a introduit le paramètre **Always Open Read-Only** comme l’une des options que les utilisateurs peuvent employer pour protéger leurs présentations. Vous pourriez vouloir utiliser ce paramètre **Read-Only** pour protéger une présentation lorsque :

- Vous souhaitez éviter les modifications accidentelles et garder le contenu de votre présentation en sécurité. 
- Vous souhaitez informer les personnes que la présentation que vous avez fournie est la version finale. 

Après avoir sélectionné l’option **Always Open Read-Only** pour une présentation, lorsqu’elle est ouverte par les utilisateurs, ils voient la recommandation **Read-Only** et peuvent voir un message de ce type : *Pour éviter les modifications accidentelles, l’auteur a configuré ce fichier pour qu’il s’ouvre en lecture seule.*

La recommandation **Read-Only** est un moyen simple mais efficace de dissuader l’édition, car les utilisateurs doivent accomplir une opération pour la supprimer avant de pouvoir modifier une présentation. Si vous ne voulez pas que les utilisateurs modifient une présentation et souhaitez le leur indiquer de façon polie, la recommandation **Read-Only** peut alors être une bonne option pour vous. 

> Si une présentation protégée par **Read-Only** est ouverte dans une ancienne version de Microsoft PowerPoint—qui ne prend pas en charge la fonction récemment introduite—la recommandation **Read-Only** est ignorée (la présentation s’ouvre normalement).

## **Appliquer le mode Read-Only**

Aspose.Slides for Python via Java vous permet de définir une présentation en **Read-Only**, ce qui signifie que les utilisateurs (une fois la présentation ouverte) voient la recommandation **Read-Only**. Ce code d’exemple montre comment définir une présentation en **Read-Only** en Python avec Aspose.Slides :

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation()
try:
    presentation.getProtectionManager().setReadOnlyRecommended(True)
    presentation.save("ReadOnlyPresentation.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

{{% alert color="info" title="Note" %}} 

La recommandation **Read-Only** a simplement pour but de décourager l’édition ou d’empêcher les utilisateurs d’apporter des modifications accidentelles à une présentation PowerPoint. Si une personne motivée—qui sait ce qu’elle fait— décide de modifier votre présentation, elle peut facilement supprimer le paramètre Read-Only. Si vous devez réellement empêcher toute modification non autorisée, il vaut mieux utiliser [des protections plus strictes incluant le chiffrement et les mots de passe](/slides/fr/python-java/password-protected-presentation/). 

{{% /alert %}} 

## **FAQ**

**Comment le 'Read-Only recommended' diffère-t-il d’une protection complète par mot de passe ?**

« Read-Only recommended » ne fait qu’afficher une suggestion d’ouvrir le fichier en mode lecture seule et est facile à contourner. [Protection par mot de passe](/slides/fr/python-java/password-protected-presentation/) restreint réellement l’ouverture ou l’édition et convient lorsqu’une vraie sécurité est nécessaire.

**Le 'Read-Only recommended' peut-il être combiné avec des filigranes pour décourager davantage les modifications ?**

Oui. La recommandation peut être associée à [filigranes](/slides/fr/python-java/watermark/) comme moyen de dissuasion visuel ; ce sont des mécanismes distincts qui fonctionnent bien ensemble.

**Une macro ou un outil externe peut-il encore modifier le fichier lorsque la recommandation est activée ?**

Oui. La recommandation ne bloque pas les modifications programmatiques. Pour empêcher les modifications automatisées, utilisez [mots de passe et chiffrement](/slides/fr/python-java/password-protected-presentation/).

**Comment le 'Read-Only recommended' se rapporte-t-il aux méthodes [isEncrypted](https://reference.aspose.com/slides/fr/python-java/aspose.slides/protectionmanager/#isEncrypted) et [isWriteProtected](https://reference.aspose.com/slides/fr/python-java/aspose.slides/protectionmanager/#isWriteProtected) ?**

Ils sont des signaux différents. « Read-Only recommended » est une invite douce et facultative ; [isWriteProtected](https://reference.aspose.com/slides/fr/python-java/aspose.slides/protectionmanager/#isWriteProtected) et [isEncrypted](https://reference.aspose.com/slides/fr/python-java/aspose.slides/protectionmanager/#isEncrypted) indiquent de réelles restrictions d’écriture ou de lecture qui dépendent de mots de passe ou de chiffrement.