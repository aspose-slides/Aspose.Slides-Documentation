---
title: Enregistrer des présentations en mode lecture seule avec C++
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
description: "Chargez et enregistrez des fichiers PowerPoint (PPT, PPTX) en mode lecture seule avec Aspose.Slides pour C++, offrant des aperçus précis des diapositives sans modifier vos présentations."
---
## **Introduction**

Dans PowerPoint 2019, Microsoft a introduit le paramètre **Always Open Read-Only** comme l’une des options que les utilisateurs peuvent utiliser pour protéger leurs présentations. Vous pourriez vouloir utiliser ce paramètre Lecture seule pour protéger une présentation lorsque

- Vous souhaitez empêcher les modifications accidentelles et garder le contenu de votre présentation en sécurité. 
- Vous voulez avertir les personnes que la présentation que vous avez fournie est la version finale. 

Après avoir sélectionné l’option **Always Open Read-Only** pour une présentation, lorsque les utilisateurs ouvrent la présentation, ils voient la recommandation **Read-Only** et peuvent voir un message sous cette forme : *Pour éviter les modifications accidentelles, l’auteur a configuré ce fichier pour qu’il s’ouvre en lecture seule.*

La recommandation **Read-Only** est un moyen simple mais efficace de dissuader la modification, car les utilisateurs doivent effectuer une action pour la supprimer avant de pouvoir modifier une présentation. Si vous ne souhaitez pas que les utilisateurs apportent des modifications à une présentation et que vous voulez le leur indiquer de manière polie, la recommandation **Read-Only** peut être une bonne option pour vous. 

> Si une présentation protégée par **Read-Only** est ouverte dans une ancienne version de Microsoft PowerPoint—qui ne prend pas en charge la fonction récemment introduite—la recommandation **Read-Only** est ignorée (la présentation s’ouvre normalement).

## **Appliquer le mode Lecture seule**

Aspose.Slides for C++ vous permet de définir une présentation en **Read-Only**, ce qui signifie que les utilisateurs (une fois la présentation ouverte) voient la recommandation **Read-Only**. Ce code d’exemple montre comment définir une présentation en **Read-Only** en C++ avec Aspose.Slides :

``` cpp
#include <DOM/IProtectionManager.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto pres = System::MakeObject<Presentation>();
pres->get_ProtectionManager()->set_ReadOnlyRecommended(true);
pres->Save(u"ReadOnlyPresentation.pptx", SaveFormat::Pptx);
```

{{% alert color="info" %}} 

**Remarque** : La recommandation **Read-Only** vise simplement à décourager la modification ou à empêcher les utilisateurs d’apporter des changements accidentels à une présentation PowerPoint. Si une personne motivée—qui sait ce qu’elle fait—choisit de modifier votre présentation, elle peut facilement supprimer le paramètre Lecture seule. Si vous avez réellement besoin d’empêcher les modifications non autorisées, il vaut mieux utiliser [des protections plus strictes qui impliquent des encryptions et des mots de passe](https://docs.aspose.com/slides/fr/cpp/password-protected-presentation/). 

{{% /alert %}} 

## **FAQ**

### En quoi la « Read-Only recommended » diffère-t-elle d’une protection par mot de passe complète ?

« Read-Only recommended » n’affiche qu’une suggestion d’ouvrir le fichier en mode lecture seule et est facile à contourner. [Protection par mot de passe](/slides/fr/cpp/password-protected-presentation/) restreint réellement l’ouverture ou la modification et convient lorsqu’il faut un vrai contrôle de sécurité.

### La « Read-Only recommended » peut-elle être combinée avec des filigranes pour décourager davantage les modifications ?

Oui. La recommandation peut être associée à des [filigranes](/slides/fr/cpp/watermark/) comme moyen de dissuasion visuel ; ce sont des mécanismes séparés qui fonctionnent bien ensemble.

### Une macro ou un outil externe peut-il encore modifier le fichier lorsque la recommandation est activée ?

Oui. La recommandation ne bloque pas les modifications programmatiques. Pour empêcher les éditions automatisées, utilisez [des mots de passe et le chiffrement](/slides/fr/cpp/password-protected-presentation/).

### Comment la « Read-Only recommended » se rapporte-t-elle aux indicateurs « is encrypted » et « is write protected » ?

Ce sont des signaux différents. « Read-Only recommended » est une invite douce et optionnelle ; [get_IsWriteProtected](https://reference.aspose.com/slides/fr/cpp/aspose.slides/protectionmanager/get_iswriteprotected/) et [get_IsEncrypted](https://reference.aspose.com/slides/fr/cpp/aspose.slides/protectionmanager/get_isencrypted/) indiquent des restrictions réelles d’écriture ou de lecture qui dépendent de mots de passe ou de chiffrement.