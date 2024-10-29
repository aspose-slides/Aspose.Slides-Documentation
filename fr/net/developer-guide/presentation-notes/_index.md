---
title: Notes de présentation
type: docs
weight: 110
url: /fr/net/presentation-notes/
keywords: "Notes, notes PowerPoint, ajouter des notes, supprimer des notes, présentation PowerPoint, C#, Csharp, Aspose.Slides pour .NET"
description: "Ajoutez et supprimez des notes dans des présentations PowerPoint en C# ou .NET"
---



Aspose.Slides prend en charge la suppression des diapositives de notes d'une présentation. Dans ce sujet, nous introduirons cette nouvelle fonctionnalité de suppression de notes ainsi que l'ajout de diapositives de style de notes à partir de n'importe quelle présentation. Aspose.Slides pour .NET offre la possibilité de supprimer les notes de n'importe quelle diapositive ainsi que d'ajouter un style aux notes existantes. Les développeurs peuvent supprimer des notes de plusieurs manières :

- Supprimer les notes d'une diapositive spécifique d'une présentation.
- Supprimer les notes de toutes les diapositives d'une présentation.
## **Supprimer les notes d'une diapositive**
Les notes d'une diapositive spécifique peuvent être supprimées comme montré dans l'exemple ci-dessous :

```c#
// Instancier un objet Presentation qui représente un fichier de présentation 
Presentation presentation = new Presentation(dataDir + "AccessSlides.pptx");

// Suppression des notes de la première diapositive
INotesSlideManager mgr = presentation.Slides[0].NotesSlideManager;
mgr.RemoveNotesSlide();

// Enregistrer la présentation sur le disque
presentation.Save(dataDir + "RemoveNotesAtSpecificSlide_out.pptx", SaveFormat.Pptx);
```


## **Supprimer les notes de toutes les diapositives**
Les notes de toutes les diapositives d'une présentation peuvent être supprimées comme montré dans l'exemple ci-dessous :

```c#
// Instancier un objet Presentation qui représente un fichier de présentation 
Presentation presentation = new Presentation("AccessSlides.pptx");

// Suppression des notes de toutes les diapositives
INotesSlideManager mgr = null;
for (int i = 0; i < presentation.Slides.Count; i++)
{
    mgr = presentation.Slides[i].NotesSlideManager;
    mgr.RemoveNotesSlide();
}
// Enregistrer la présentation sur le disque
presentation.Save("RemoveNotesFromAllSlides_out.pptx", SaveFormat.Pptx);
```


## **Ajouter un style de notes**
La propriété NotesStyle a été ajoutée à [IMasterNotesSlide](https://reference.aspose.com/slides/net/aspose.slides/imasternotesslide) interface et [MasterNotesSlide](https://reference.aspose.com/slides/net/aspose.slides/masternotesslide) classe respectivement. Cette propriété spécifie le style d'un texte de notes. L'implémentation est démontrée dans l'exemple ci-dessous.

```c#
// Instancier la classe Presentation qui représente le fichier de présentation
using (Presentation presentation = new Presentation("AccessSlides.pptx"))
{
    IMasterNotesSlide notesMaster = presentation.MasterNotesSlideManager.MasterNotesSlide;

    if (notesMaster != null)
    {
        // Obtenir le style de texte de MasterNotesSlide
        ITextStyle notesStyle = notesMaster.NotesStyle;

        // Définir un symbole pour les paragraphes de premier niveau
        IParagraphFormat paragraphFormat = notesStyle.GetLevel(0);
        paragraphFormat.Bullet.Type = BulletType.Symbol;
    }

    // Enregistrer le fichier PPTX sur le disque
    presentation.Save("AddNotesSlideWithNotesStyle_out.pptx", Aspose.Slides.Export.SaveFormat.Pptx);

}
```