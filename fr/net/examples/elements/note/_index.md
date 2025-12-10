---
title: Note
type: docs
weight: 240
url: /fr/net/examples/elements/elements/note/
keywords:
- exemple de note
- ajouter une diapositive de notes
- accéder à une diapositive de notes
- supprimer une diapositive de notes
- mettre à jour le texte des notes
- PowerPoint
- OpenDocument
- présentation
- .NET
- C#
- Aspose.Slides
description: "Ajouter, lire, modifier et exporter les notes du présentateur en C# avec Aspose.Slides : formater le texte, gérer les notes par diapositive et contrôler la visibilité dans PowerPoint et OpenDocument."
---

Montre comment ajouter, lire, supprimer et mettre à jour des diapositives de notes à l'aide de **Aspose.Slides for .NET**.

## **Ajouter une diapositive de notes**

Créez une diapositive de notes et affectez‑lui du texte.
```csharp
static void Add_Note()
{
    using var pres = new Presentation();
    var slide = pres.Slides[0];

    var notesSlide = slide.NotesSlideManager.AddNotesSlide();
    slide.NotesSlideManager.NotesSlide.NotesTextFrame.Text = "My note";
}
```


## **Accéder à une diapositive de notes**

Lire le texte d'une diapositive de notes existante.
```csharp
static void Access_Note()
{
    using var pres = new Presentation();
    var slide = pres.Slides[0];
    var notesSlide = slide.NotesSlideManager.AddNotesSlide();

    var notes = notesSlide.NotesTextFrame.Text;
}
```


## **Supprimer une diapositive de notes**

Supprimez la diapositive de notes associée à une diapositive.
```csharp
static void Remove_Note()
{
    using var pres = new Presentation();
    var slide = pres.Slides[0];
    var notesSlide = slide.NotesSlideManager.AddNotesSlide();

    slide.NotesSlideManager.RemoveNotesSlide();
}
```


## **Mettre à jour le texte d'une diapositive de notes**

Modifiez le texte d'une diapositive de notes.
```csharp
static void Update_Note_Text()
{
    using var pres = new Presentation();
    var slide = pres.Slides[0];
    var notesSlide = slide.NotesSlideManager.AddNotesSlide();

    slide.NotesSlideManager.NotesSlide.NotesTextFrame.Text = "Old";
    slide.NotesSlideManager.NotesSlide.NotesTextFrame.Text = "Updated";
}
```
