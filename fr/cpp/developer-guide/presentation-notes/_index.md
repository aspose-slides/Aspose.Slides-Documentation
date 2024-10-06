---
title: Notes de Présentation
type: docs
weight: 110
url: /cpp/presentation-notes/
keywords: "Notes pour le présentateur de la présentation PowerPoint"
---


## **Ajouter et Supprimer des Notes de Diapositive**
Aspose.Slides supporte désormais la suppression des diapositives de notes de la présentation. Dans ce sujet, nous allons introduire cette nouvelle fonctionnalité de suppression de notes ainsi que l'ajout de diapositives de style notes à partir de n'importe quelle présentation. Aspose.Slides pour C++ offre la fonctionnalité de supprimer les notes de n'importe quelle diapositive ainsi que d'ajouter du style aux notes existantes. Les développeurs peuvent supprimer des notes de la manière suivante :

- Suppression des notes d'une diapositive spécifique d'une présentation.
- Suppression des notes de toutes les diapositives d'une présentation.

## **Supprimer les Notes d'une Diapositive Spécifique**
Les notes de certaines diapositives spécifiques peuvent être supprimées comme montré dans l'exemple ci-dessous :

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-RemoveNotesAtSpecificSlide-RemoveNotesAtSpecificSlide.cpp" >}}
## **Supprimer les Notes de toutes les Diapositives**
Les notes de toutes les diapositives d'une présentation peuvent être supprimées comme montré dans l'exemple ci-dessous :

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-RemoveNotesFromAllSlides-RemoveNotesFromAllSlides.cpp" >}}
## **Ajouter NotesStyle**
La propriété NotesStyle a été ajoutée à l'interface IMasterNotesSlide et à la classe MasterNotesSlide respectivement. Cette propriété spécifie le style d'un texte de notes. L'implémentation est démontrée dans l'exemple ci-dessous.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-AddNotesSlideWithNotesStyle-AddNotesSlideWithNotesStyle.cpp" >}}