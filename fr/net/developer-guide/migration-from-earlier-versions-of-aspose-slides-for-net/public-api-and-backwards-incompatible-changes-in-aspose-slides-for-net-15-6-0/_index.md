---
title: API publique et changements incompatibles rétroactifs dans Aspose.Slides pour .NET 15.6.0
linktitle: Aspose.Slides pour .NET 15.6.0
type: docs
weight: 170
url: /fr/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-6-0/
keywords:
- migration
- code hérité
- code moderne
- approche héritée
- approche moderne
- PowerPoint
- OpenDocument
- présentation
- .NET
- C#
- Aspose.Slides
description: "Examinez les mises à jour de l'API publique et les changements incompatibles dans Aspose.Slides pour .NET afin de migrer en douceur vos solutions de présentation PowerPoint PPT, PPTX et ODP."
---

{{% alert color="primary" %}} 

Cette page répertorie toutes les [ajoutées](/slides/fr/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-6-0/) ou [supprimées](/slides/fr/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-6-0/) classes, méthodes, propriétés et autres changements introduits avec l'API Aspose.Slides for .NET 15.6.0.

{{% /alert %}} 
## **Modifications de l'API publique**
#### **La signature du constructeur DataLabel a été modifiée**
La signature du constructeur DataLabel a été modifiée :
was: DataLabel.#ctor(Aspose.Slides.Charts.IChartSeries);
now: DataLabel.#ctor(Aspose.Slides.Charts.IChartDataPoint).
#### **Les membres IDocumentProperties.Count, .GetPropertyName(int index), .Remove(string name), .Contains(string name) ont été marqués comme obsolètes et leurs remplacements ont été introduits.**
La propriété IDocumentProperties.Count et les méthodes IDocumentProperties.GetPropertyName(int index), .Remove(string name), .Contains(string name) ont été marqués comme obsolètes. La propriété IDocumentProperties.CountOfCustomProperties et les méthodes IDocumentProperties.GetCustomPropertyName(int index), .RemoveCustomProperty(string name), .ContainsCustomProperty(string name) ont été ajoutées à la place.
#### **La méthode INotesSlideManager.RemoveNotesSlide() a été ajoutée**
La méthode INotesSlideManager.RemoveNotesSlide() a été ajoutée pour supprimer la diapositive de notes d’une diapositive.
#### **La méthode Remove a été ajoutée à IComment**
La méthode IComment.Remove a été ajoutée pour supprimer un commentaire de la collection.
#### **La méthode Remove a été ajoutée à ICommentAuthor**
La méthode ICommentAuthor.Remove a été ajoutée pour supprimer l’auteur des commentaires de la collection.
#### **Les méthodes ClearCustomProperties et ClearBuiltInProperties ont été ajoutées à IDocumentProperties**
La méthode IDocumentProperties.ClearCustomProperties a été ajoutée pour supprimer toutes les propriétés personnalisées du document.  
La méthode IDocumentProperties.ClearBuiltInProperties a été ajoutée pour supprimer et réinitialiser les valeurs par défaut de toutes les propriétés intégrées du document (Company, Subject, Author, etc.).
#### **Les méthodes RemoveAt, Remove et Clear ont été ajoutées à ICommentAuthorCollection**
La méthode ICommentAuthorCollection.RemoveAt a été ajoutée pour supprimer un auteur selon un indice spécifié.  
La méthode ICommentAuthorCollection.Remove a été ajoutée pour supprimer un auteur spécifié de la collection.  
La méthode ICommentAuthorCollection.Clear a été ajoutée pour supprimer tous les éléments de la collection.
#### **La propriété AppVersion a été ajoutée à IDocumentProperties**
La propriété IDocumentProperties.AppVersion a été ajoutée pour obtenir la propriété intégrée du document qui représente les numéros de version internes utilisés par Microsoft pendant le développement.
#### **La propriété BlackWhiteMode a été ajoutée à IShape et à Shape**
La propriété BlackWhiteMode a été ajoutée à IShape et à Shape.

Cette propriété spécifie comment une forme sera rendue en mode d’affichage noir et blanc.

|**Valeur**|**Signification**|
| :- | :- |
|Color|Rendu avec les couleurs normales|
|Automatic|Rendu avec coloration automatique|
|Gray|Rendu en niveaux de gris|
|LightGray|Rendu en gris clair|
|InverseGray|Rendu en gris inversé|
|GrayWhite|Rendu en gris et blanc|
|BlackGray|Rendu en noir et gris|
|BlackWhite|Rendu en noir et blanc|
|Black|Rendu uniquement en noir|
|White|Rendu en blanc|
|Hidden|Non rendu|
|NotDefined|indique que la propriété n’est pas définie|
#### **Propriété ISlide.NotesSlideManager a été ajoutée. La propriété ISlide.NotesSlide et la méthode ISlide.AddNotesSlide() ont été marquées comme obsolètes.**
Les membres ISlide.NotesSlide et ISlide.AddNotesSlide() ont été marqués comme obsolètes. Utilisez la nouvelle propriété ISlide.NotesSlideManager à la place.

``` csharp

 ISlide slide = ...;

INotesSlide notes;

// notes = slide.AddNotesSlide(); - obsolete

// notes = slide.NotesSlide; - obsolete

notes = slide.NotesSlideManager.NotesSlide;

notes = slide.NotesSlideManager.AddNotesSlide();

slide.NotesSlideManager.RemoveNotesSlide();

```