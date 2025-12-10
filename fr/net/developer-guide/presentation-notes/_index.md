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
description: "Personnalisez les notes de présentation avec Aspose.Slides pour .NET. Travaillez sans effort avec les notes PowerPoint et OpenDocument pour augmenter votre productivité."
---

Aspose.Slides prend en charge la suppression des diapositives de notes d’une présentation. Dans cet article, nous présenterons cette nouvelle fonctionnalité de suppression des notes ainsi que l’ajout de diapositives de style de notes à partir de n’importe quelle présentation. Aspose.Slides pour .NET offre la possibilité de supprimer les notes de n’importe quelle diapositive ainsi que d’ajouter du style aux notes existantes. Les développeurs peuvent supprimer les notes de la manière suivante :

- Supprimer les notes d’une diapositive spécifique d’une présentation.  
- Supprimer les notes de toutes les diapositives d’une présentation.  

## **Supprimer les notes d'une diapositive**
Les notes d’une diapositive précise peuvent être supprimées comme le montre l’exemple ci‑dessous :
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
Les notes de toutes les diapositives d’une présentation peuvent être supprimées comme le montre l’exemple ci‑dessous :
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
La propriété NotesStyle a été ajoutée à l’interface [IMasterNotesSlide](https://reference.aspose.com/slides/net/aspose.slides/imasternotesslide) et à la classe [MasterNotesSlide](https://reference.aspose.com/slides/net/aspose.slides/masternotesslide) respectivement. Cette propriété indique le style du texte des notes. L’implémentation est illustrée dans l’exemple ci‑dessous.
```c#
// Instancier la classe Presentation qui représente le fichier de présentation
using (Presentation presentation = new Presentation("AccessSlides.pptx"))
{
    IMasterNotesSlide notesMaster = presentation.MasterNotesSlideManager.MasterNotesSlide;

    if (notesMaster != null)
    {
        // Obtenir le style de texte du MasterNotesSlide
        ITextStyle notesStyle = notesMaster.NotesStyle;

        //Définir une puce symbole pour les paragraphes de premier niveau
        IParagraphFormat paragraphFormat = notesStyle.GetLevel(0);
        paragraphFormat.Bullet.Type = BulletType.Symbol;
    }

    // Enregistrer le fichier PPTX sur le disque
    presentation.Save("AddNotesSlideWithNotesStyle_out.pptx", Aspose.Slides.Export.SaveFormat.Pptx);

}
```


## **FAQ**

**Quel entité API fournit l’accès aux notes d’une diapositive spécifique ?**

Les notes sont accessibles via le gestionnaire de notes de la diapositive : la diapositive possède un [NotesSlideManager](https://reference.aspose.com/slides/net/aspose.slides/notesslidemanager/) et une [property](https://reference.aspose.com/slides/net/aspose.slides/notesslidemanager/notesslide/) qui renvoie l’objet notes, ou `null` s’il n’y a pas de notes.

**Existe‑t‑il des différences de prise en charge des notes selon les versions de PowerPoint avec lesquelles la bibliothèque fonctionne ?**

La bibliothèque cible un large éventail de formats Microsoft PowerPoint (97‑plus récent) ainsi que ODP ; les notes sont prises en charge dans ces formats sans dépendre d’une copie installée de PowerPoint.