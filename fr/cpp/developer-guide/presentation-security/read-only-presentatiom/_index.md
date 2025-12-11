---
title: Enregistrer les présentations en mode lecture seule avec C++
linktitle: Présentation en lecture seule
type: docs
weight: 30
url: /fr/cpp/read-only-presentation/
keywords:
- lecture seule
- protéger la présentation
- empêcher la modification
- PowerPoint
- OpenDocument
- présentation
- C++
- Aspose.Slides
description: "Chargez et enregistrez des fichiers PowerPoint (PPT, PPTX) en mode lecture seule avec Aspose.Slides pour C++, offrant des aperçus de diapositives précis sans modifier vos présentations."
---

## **Appliquer le mode Lecture seule**

Dans PowerPoint 2019, Microsoft a introduit le paramètre **Toujours ouvrir en Lecture seule** comme l’une des options que les utilisateurs peuvent utiliser pour protéger leurs présentations. Vous pouvez vouloir utiliser ce paramètre Lecture seule pour protéger une présentation lorsque :

- Vous souhaitez empêcher les modifications accidentelles et garder le contenu de votre présentation en sécurité.  
- Vous voulez avertir les personnes que la présentation que vous avez fournie est la version finale.  

Après avoir sélectionné l’option **Toujours ouvrir en Lecture seule** pour une présentation, lorsqu’elle est ouverte, les utilisateurs voient la recommandation **Lecture seule** et peuvent voir un message sous cette forme : *Pour éviter les modifications accidentelles, l’auteur a défini ce fichier pour qu’il s’ouvre en lecture seule.*

La recommandation **Lecture seule** est un moyen simple mais efficace de décourager l’édition, car les utilisateurs doivent effectuer une action pour la retirer avant de pouvoir modifier la présentation. Si vous ne voulez pas que les utilisateurs modifient une présentation et que vous souhaitez le leur indiquer poliment, la recommandation **Lecture seule** peut être une bonne option pour vous. 

> Si une présentation protégée par **Lecture seule** est ouverte dans une version plus ancienne de Microsoft PowerPoint—qui ne prend pas en charge la fonction récemment introduite—la recommandation **Lecture seule** est ignorée (la présentation s’ouvre normalement).

Aspose.Slides for C++ vous permet de définir une présentation en **Lecture seule**, ce qui signifie que les utilisateurs (après l’ouverture de la présentation) voient la recommandation **Lecture seule**. Ce code d’exemple montre comment définir une présentation en **Lecture seule** en C++ avec Aspose.Slides :
``` cpp
auto pres = System::MakeObject<Presentation>();
pres->get_ProtectionManager()->set_ReadOnlyRecommended(true);
pres->Save(u"ReadOnlyPresentation.pptx", SaveFormat::Pptx);
```


{{% alert color="primary" %}} 

**Remarque** : La recommandation **Lecture seule** vise simplement à décourager l’édition ou à empêcher les changements accidentels d’une présentation PowerPoint. Si une personne motivée—qui sait ce qu’elle fait— décide de modifier votre présentation, elle peut facilement supprimer le paramètre Lecture seule. Si vous avez réellement besoin de prévenir les modifications non autorisées, il est préférable d’utiliser [des protections plus strictes impliquant chiffrement et mots de passe](https://docs.aspose.com/slides/cpp/password-protected-presentation/). 

{{% /alert %}} 

## **FAQ**

**En quoi la « Lecture seule recommandée » diffère-t-elle d’une protection par mot de passe complète ?**

« Lecture seule recommandée » n’affiche qu’une suggestion d’ouvrir le fichier en mode lecture seule et est facile à contourner. [Protection par mot de passe](/slides/fr/cpp/password-protected-presentation/) restreint réellement l’ouverture ou la modification et convient lorsque vous avez besoin de contrôles de sécurité réels.

**La « Lecture seule recommandée » peut‑elle être combinée avec des filigranes pour décourager davantage les modifications ?**

Oui. La recommandation peut être associée à [filigranes](/slides/fr/cpp/watermark/) comme moyen visuel de dissuasion ; ce sont des mécanismes séparés qui fonctionnent bien ensemble.

**Une macro ou un outil externe peut‑il toujours modifier le fichier lorsque la recommandation est activée ?**

Oui. La recommandation ne bloque pas les changements programmatiques. Pour empêcher les modifications automatisées, utilisez [des protections par mots de passe et chiffrement](/slides/fr/cpp/password-protected-presentation/).

**Comment la « Lecture seule recommandée » se rapporte‑t‑elle aux indicateurs « is encrypted » et « is write protected » ?**

Ce sont des signaux différents. « Lecture seule recommandée » est une invite douce et facultative ; [get_IsWriteProtected](https://reference.aspose.com/slides/cpp/aspose.slides/protectionmanager/get_iswriteprotected/) et [get_IsEncrypted](https://reference.aspose.com/slides/cpp/aspose.slides/protectionmanager/get_isencrypted/) indiquent des restrictions réelles d’écriture ou de lecture qui dépendent de mots de passe ou de chiffrement.