---
title: API Public et Changements Incompatibles dans Aspose.Slides pour .NET 15.6.0
type: docs
weight: 170
url: /fr/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-6-0/
---

{{% alert color="primary" %}} 

Cette page répertorie toutes les [ajouts](/slides/fr/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-6-0/) ou [suppressions](/slides/fr/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-6-0/) de classes, méthodes, propriétés, etc., ainsi que d'autres changements introduits avec l'API Aspose.Slides pour .NET 15.6.0.

{{% /alert %}} 
## **Changements de l'API Public**
#### **La signature du constructeur DataLabel a été modifiée**
La signature du constructeur DataLabel a été modifiée :
était : DataLabel.#ctor(Aspose.Slides.Charts.IChartSeries) ;
maintenant : DataLabel.#ctor(Aspose.Slides.Charts.IChartDataPoint).
#### **Les membres IDocumentProperties.Count, .GetPropertyName(int index), .Remove(string name), .Contains(string name) ont été marqués comme Obsolètes et leurs substitutions ont été introduites à la place.**
La propriété IDocumentProperties.Count et les méthodes IDocumentProperties.GetPropertyName(int index), .Remove(string name), .Contains(string name) ont été marquées comme Obsolètes. La propriété IDocumentProperties.CountOfCustomProperties et les méthodes IDocumentProperties.GetCustomPropertyName(int index), .RemoveCustomProperty(string name), .ContainsCustomProperty(string name) ont été ajoutées à la place.
#### **La méthode INotesSlideManager.RemoveNotesSlide() a été ajoutée**
La méthode INotesSlideManager.RemoveNotesSlide() a été ajoutée pour supprimer la diapositive de notes d'une diapositive donnée.
#### **La méthode Remove a été ajoutée à IComment**
La méthode IComment.Remove a été ajoutée pour supprimer un commentaire de la collection.
#### **La méthode Remove a été ajoutée à ICommentAuthor**
La méthode ICommentAuthor.Remove a été ajoutée pour supprimer l'auteur des commentaires de la collection.
#### **Les méthodes ClearCustomProperties et ClearBuiltInProperties ont été ajoutées à IDocumentProperties**
La méthode IDocumentProperties.ClearCustomProperties a été ajoutée pour supprimer toutes les propriétés de document personnalisées.
La méthode IDocumentProperties.ClearBuiltInProperties a été ajoutée pour supprimer et définir des valeurs par défaut pour toutes les propriétés de document intégrées (Société, Sujet, Auteur, etc.).
#### **Les méthodes RemoveAt, Remove et Clear ont été ajoutées à ICommentAuthorCollection**
La méthode ICommentAuthorCollection.RemoveAt a été ajoutée pour supprimer l'auteur par index spécifié.
La méthode ICommentAuthorCollection.Remove a été ajoutée pour supprimer un auteur spécifié de la collection.
La méthode ICommentAuthorCollection.Clear a été ajoutée pour supprimer tous les éléments de la collection.
#### **La propriété AppVersion a été ajoutée à IDocumentProperties**
La propriété IDocumentProperties.AppVersion a été ajoutée pour obtenir la propriété de document intégrée qui représente les numéros de version internes utilisés par Microsoft pendant le développement.
#### **La propriété BlackWhiteMode a été ajoutée à IShape et à Shape**
La propriété BlackWhiteMode a été ajoutée à IShape et à Shape.

Cette propriété spécifie comment une forme sera rendue en mode d'affichage noir et blanc.

|**Valeur** |**Signification** |
| :- | :- |
|Couleur |Rendre avec coloration normale |
|Automatique |Rendre avec coloration automatique |
|Gris |Rendre avec coloration grise |
|GrisClair |Rendre avec coloration gris clair |
|InverséGris |Rendre avec coloration gris inversé |
|GrisBlanc |Rendre avec coloration grise et blanche |
|NoirGris |Rendre avec coloration noire et grise |
|NoirBlanc |Rendre avec coloration noire et blanche |
|Noir |Rendre uniquement avec coloration noire |
|Blanc |Rendre avec coloration blanche |
|Caché |Ne pas rendre |
|NonDéfini|signifie que la propriété n'est pas définie|
#### **La propriété ISlide.NotesSlideManager a été ajoutée. La propriété ISlide.NotesSlide et la méthode ISlide.AddNotesSlide() ont été marquées comme Obsolètes.**
Les membres ISlide.NotesSlide, ISlide.AddNotesSlide() ont été marqués comme Obsolètes. Utilisez la nouvelle propriété ISlide.NotesSlideManager à la place.

``` csharp

 ISlide slide = ...;

INotesSlide notes;

// notes = slide.AddNotesSlide(); - obsolète

// notes = slide.NotesSlide; - obsolète

notes = slide.NotesSlideManager.NotesSlide;

notes = slide.NotesSlideManager.AddNotesSlide();

slide.NotesSlideManager.RemoveNotesSlide();

``` 