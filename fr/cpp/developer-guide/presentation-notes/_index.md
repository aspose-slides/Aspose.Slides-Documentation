---
title: Gérer les notes de présentation en C++
linktitle: Notes de présentation
type: docs
weight: 110
url: /fr/cpp/presentation-notes/
keywords:
- notes
- diapositive de notes
- ajouter des notes
- supprimer des notes
- style de notes
- notes maîtres
- PowerPoint
- OpenDocument
- présentation
- C++
- Aspose.Slides
description: "Personnalisez les notes de présentation avec Aspose.Slides pour C++. Travaillez en toute transparence avec les notes PowerPoint et OpenDocument pour augmenter votre productivité."
---

## **Ajouter et supprimer des notes de diapositive**
Aspose.Slides prend désormais en charge la suppression des diapositives de notes d’une présentation. Dans ce sujet, nous présenterons cette nouvelle fonctionnalité de suppression des notes ainsi que d’ajout de diapositives de style de notes à partir de n’importe quelle présentation. Aspose.Slides pour C++ offre la fonctionnalité de suppression des notes de n’importe quelle diapositive ainsi que l’ajout de style aux notes existantes. Les développeurs peuvent supprimer les notes de la manière suivante :

- Suppression des notes d’une diapositive spécifique d’une présentation.
- Suppression des notes de toutes les diapositives d’une présentation.

## **Supprimer les notes d’une diapositive spécifique**
Les notes d’une diapositive spécifique peuvent être supprimées comme indiqué dans l’exemple ci‑dessous :

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-RemoveNotesAtSpecificSlide-RemoveNotesAtSpecificSlide.cpp" >}}
## **Supprimer les notes de toutes les diapositives**
Les notes de toutes les diapositives d’une présentation peuvent être supprimées comme indiqué dans l’exemple ci‑dessous :

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-RemoveNotesFromAllSlides-RemoveNotesFromAllSlides.cpp" >}}
## **Ajouter un style de notes**
La propriété NotesStyle a été ajoutée à l’interface IMasterNotesSlide et à la classe MasterNotesSlide respectivement. Cette propriété spécifie le style du texte des notes. L’implémentation est démontrée dans l’exemple ci‑dessous.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-AddNotesSlideWithNotesStyle-AddNotesSlideWithNotesStyle.cpp" >}}

## **FAQ**

**Quelle entité API permet d’accéder aux notes d’une diapositive spécifique ?**

Les notes sont accessibles via le gestionnaire de notes de la diapositive : la diapositive possède un [NotesSlideManager](https://reference.aspose.com/slides/cpp/aspose.slides/notesslidemanager/) et une [méthode](https://reference.aspose.com/slides/cpp/aspose.slides/notesslidemanager/get_notesslide/) qui renvoie l’objet notes, ou `null` s’il n’y a pas de notes.

**Existe-t-il des différences de prise en charge des notes selon les versions de PowerPoint avec lesquelles la bibliothèque fonctionne ?**

La bibliothèque cible une large gamme de formats Microsoft PowerPoint (97-et plus récents) ainsi que ODP ; les notes sont prises en charge dans ces formats sans dépendre d’une copie installée de PowerPoint.