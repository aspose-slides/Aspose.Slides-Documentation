---
title: Gérer les notes de présentation en .NET
linktitle: Notes de présentation
type: docs
weight: 110
url: /fr/net/presentation-notes/
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
- .NET
- C#
- Aspose.Slides
description: "Personnalisez les notes de présentation avec Aspose.Slides pour .NET. Travaillez en toute transparence avec les notes PowerPoint et OpenDocument pour augmenter votre productivité."
---
## **Vue d'ensemble**

Aspose.Slides prend en charge la suppression des diapositives de notes d’une présentation. Dans ce sujet, nous présenterons cette fonctionnalité, y compris comment supprimer les notes et comment appliquer un style aux diapositives de notes dans une présentation. Aspose.Slides vous permet de supprimer les notes de n'importe quelle diapositive et également d'appliquer du style aux notes existantes. Les développeurs peuvent supprimer les notes de la manière suivante :

- Supprimer les notes d’une diapositive spécifique d’une présentation.
- Supprimer les notes de toutes les diapositives d’une présentation.

Pour lire ou modifier les dimensions de la page de notes, changer l'orientation et vérifier le comportement d'exportation, consultez [Taille de la page des notes](/slides/fr/net/notes-size/).

## **Supprimer les notes d’une diapositive**
Les notes d’une diapositive spécifique peuvent être supprimées comme le montre l'exemple ci-dessous :

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

// Instancier un objet Presentation qui représente un fichier de présentation
Presentation presentation = new Presentation("AccessSlides.pptx");

// Suppression des notes de la première diapositive
INotesSlideManager mgr = presentation.Slides[0].NotesSlideManager;
mgr.RemoveNotesSlide();

// Enregistrer la présentation sur le disque
presentation.Save("RemoveNotesAtSpecificSlide_out.pptx", SaveFormat.Pptx);
```

## **Supprimer les notes de toutes les diapositives**
Les notes de toutes les diapositives d'une présentation peuvent être supprimées comme le montre l'exemple ci-dessous :

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

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
La propriété NotesStyle a été ajoutée à l'interface [IMasterNotesSlide](https://reference.aspose.com/slides/fr/net/aspose.slides/imasternotesslide) et à la classe [MasterNotesSlide](https://reference.aspose.com/slides/fr/net/aspose.slides/masternotesslide) respectivement. Cette propriété spécifie le style du texte des notes. L'implémentation est démontrée dans l'exemple ci-dessous.

```c#
using Aspose.Slides;

// Instancier la classe Presentation qui représente le fichier de présentation
using (Presentation presentation = new Presentation("AccessSlides.pptx"))
{
    IMasterNotesSlide notesMaster = presentation.MasterNotesSlideManager.MasterNotesSlide;

    if (notesMaster != null)
    {
        // Obtenir le style de texte du MasterNotesSlide
        ITextStyle notesStyle = notesMaster.NotesStyle;

        //Définir un puce symbole pour les paragraphes de premier niveau
        IParagraphFormat paragraphFormat = notesStyle.GetLevel(0);
        paragraphFormat.Bullet.Type = BulletType.Symbol;
    }

    // Enregistrer le fichier PPTX sur le disque
    presentation.Save("AddNotesSlideWithNotesStyle_out.pptx", Aspose.Slides.Export.SaveFormat.Pptx);

}
```

## **FAQ**

### Quelle entité API fournit l'accès aux notes d'une diapositive spécifique ?
Les notes sont accessibles via le gestionnaire de notes de la diapositive : la diapositive possède un [NotesSlideManager](https://reference.aspose.com/slides/fr/net/aspose.slides/notesslidemanager/) et une [property](https://reference.aspose.com/slides/fr/net/aspose.slides/notesslidemanager/notesslide/) qui renvoie l'objet notes, ou `null` si aucune note n'existe.

### Existe-t-il des différences de prise en charge des notes selon les versions de PowerPoint avec lesquelles la bibliothèque fonctionne ?
La bibliothèque cible un large éventail de formats Microsoft PowerPoint (97-newer) et ODP ; les notes sont prises en charge dans ces formats sans dépendre d'une copie installée de PowerPoint.