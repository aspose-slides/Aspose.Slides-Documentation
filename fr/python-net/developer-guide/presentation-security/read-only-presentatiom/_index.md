---
title: Enregistrer les présentations en mode lecture seule avec Python
linktitle: Présentation en lecture seule
type: docs
weight: 30
url: /fr/python-net/read-only-presentation/
keywords:
- lecture seule
- protéger la présentation
- empêcher la modification
- PowerPoint
- présentation
- Python
- Aspose.Slides
description: "Chargez et enregistrez des fichiers PowerPoint (PPT, PPTX) en mode lecture seule avec Aspose.Slides pour Python via .NET, offrant des aperçus de diapositives précis sans modifier vos présentations."
---

## **Appliquer le mode lecture seule**

Dans PowerPoint 2019, Microsoft a introduit le paramètre **Always Open Read-Only** parmi les options que les utilisateurs peuvent utiliser pour protéger leurs présentations. Vous pouvez souhaiter utiliser ce paramètre Lecture seule pour protéger une présentation lorsque

- Vous souhaitez éviter les modifications accidentelles et garder le contenu de votre présentation en sécurité.  
- Vous souhaitez avertir les personnes que la présentation que vous avez fournie est la version finale.  

Après avoir sélectionné l'option **Always Open Read-Only** pour une présentation, lorsque les utilisateurs ouvrent la présentation, ils voient la recommandation **Read-Only** et peuvent voir un message sous cette forme : *Pour éviter les modifications accidentelles, l’auteur a défini ce fichier pour qu’il s’ouvre en lecture seule.*

La recommandation **Read-Only** est un moyen simple mais efficace de décourager la modification, car les utilisateurs doivent effectuer une action pour la supprimer avant de pouvoir éditer une présentation. Si vous ne voulez pas que les utilisateurs apportent des modifications à une présentation et souhaitez leur communiquer cela de manière courtoise, alors la recommandation **Read-Only** peut être une bonne option pour vous. 

> Si une présentation protégée par **Read-Only** est ouverte dans une ancienne version de Microsoft PowerPoint — qui ne prend pas en charge la fonction récemment introduite — la recommandation **Read-Only** est ignorée (la présentation s’ouvre normalement).

Aspose.Slides for Python via .NET vous permet de définir une présentation en **Read-Only**, ce qui signifie que les utilisateurs (après avoir ouvert la présentation) voient la recommandation **Read-Only**. Ce code d’exemple montre comment définir une présentation en **Read-Only** en Python avec Aspose.Slides :

```py
import aspose.slides as slides

with slides.Presentation() as pres:
    pres.protection_manager.read_only_recommended = True
    pres.save("ReadOnlyPresentation.pptx", slides.export.SaveFormat.PPTX)
```

{{% alert color="primary" %}} 

**Note** : La recommandation **Read-Only** vise simplement à décourager la modification ou à empêcher les utilisateurs d’apporter des changements accidentels à une présentation PowerPoint. Si une personne motivée — qui sait ce qu’elle fait — décide de modifier votre présentation, elle peut facilement supprimer le paramètre Read-Only. Si vous avez réellement besoin d’empêcher les modifications non autorisées, il vaut mieux utiliser [des protections plus strictes impliquant le chiffrement et des mots de passe](https://docs.aspose.com/slides/python-net/password-protected-presentation/). 

{{% /alert %}} 

## **FAQ**

**En quoi le « Read-Only recommended » diffère-t-il d’une protection par mot de passe complète ?**

« Read-Only recommended » n’affiche qu’une suggestion d’ouvrir le fichier en mode lecture seule et il est facile de la contourner. [Protection par mot de passe](/slides/fr/python-net/password-protected-presentation/) restreint réellement l’ouverture ou la modification et convient lorsque vous avez besoin de véritables contrôles de sécurité.

**Le « Read-Only recommended » peut-il être combiné avec des filigranes pour décourager davantage les modifications ?**

Oui. Cette recommandation peut être associée à des [filigranes](/slides/fr/python-net/watermark/) comme moyen de dissuasion visuel ; ils sont des mécanismes distincts et fonctionnent bien ensemble.

**Une macro ou un outil externe peut-il encore modifier le fichier lorsque la recommandation est activée ?**

Oui. La recommandation ne bloque pas les modifications programmatiques. Pour empêcher les éditions automatisées, utilisez des [mots de passe et du chiffrement](/slides/fr/python-net/password-protected-presentation/).

**Comment le « Read-Only recommended » se rapporte-t-il aux indicateurs « is_encrypted » et « is_write_protected » ?**

Ce sont des signaux différents. « Read-Only recommended » est une invite douce et facultative ; [is_write_protected](https://reference.aspose.com/slides/python-net/aspose.slides/protectionmanager/is_write_protected/) et [is_encrypted](https://reference.aspose.com/slides/python-net/aspose.slides/protectionmanager/is_encrypted/) indiquent des restrictions réelles d’écriture ou de lecture qui dépendent de mots de passe ou de chiffrement.