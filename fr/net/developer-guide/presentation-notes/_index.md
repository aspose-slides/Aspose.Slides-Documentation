---
title: Notes de présentation
type: docs
weight: 110
url: /fr/net/presentation-notes/
keywords: "Notes, notes PowerPoint, ajouter des notes, supprimer des notes, présentation PowerPoint, C#, Csharp, Aspose.Slides for .NET"
description: "Ajouter et supprimer des notes dans les présentations PowerPoint en C# ou .NET"
---

Aspose.Slides prend en charge la suppression des diapositives de notes d'une présentation. Dans ce sujet, nous présenterons cette nouvelle fonctionnalité de suppression des notes ainsi que l'ajout de diapositives de style de notes à partir de toute présentation. Aspose.Slides pour .NET offre la fonctionnalité de supprimer les notes de n'importe quelle diapositive ainsi que d'ajouter un style aux notes existantes. Les développeurs peuvent supprimer les notes de les manières suivantes :

- Supprimer les notes d'une diapositive spécifique d'une présentation.
- Supprimer les notes de toutes les diapositives d'une présentation.
## **Supprimer les notes d'une diapositive**
Les notes d'une diapositive précise peuvent être supprimées comme indique dans l'exemple ci-dessous :
```c#
// Instancier un objet Presentation qui représente un fichier de présentation 
Presentation presentation = new Presentation(dataDir + "AccessSlides.pptx");

// Suppression des notes de la première diapositive
INotesSlideManager mgr = presentation.Slides[0].NotesSlideManager;
mgr.RemoveNotesSlide();

// Enregistrer la présentation sur disque
presentation.Save(dataDir + "RemoveNotesAtSpecificSlide_out.pptx", SaveFormat.Pptx);
```


## **Supprimer les notes de toutes les diapositives**
Les notes de toutes les diapositives d'une présentation peuvent être supprimées comme indique dans l'exemple ci-dessous :
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
// Enregistrer la présentation sur disque
presentation.Save("RemoveNotesFromAllSlides_out.pptx", SaveFormat.Pptx);
```


## **Ajouter NotesStyle**
La propriete NotesStyle a ete ajoutee a l'interface [IMasterNotesSlide](https://reference.aspose.com/slides/net/aspose.slides/imasternotesslide) et a la classe [MasterNotesSlide](https://reference.aspose.com/slides/net/aspose.slides/masternotesslide) respectivement. Cette propriete specifie le style du texte des notes. L'implementation est illustree dans l'exemple ci-dessous.
```c#
// Instancier la classe Presentation qui représente le fichier de présentation
using (Presentation presentation = new Presentation("AccessSlides.pptx"))
{
    IMasterNotesSlide notesMaster = presentation.MasterNotesSlideManager.MasterNotesSlide;

    if (notesMaster != null)
    {
        // Obtient le style de texte du MasterNotesSlide
        ITextStyle notesStyle = notesMaster.NotesStyle;

        //Définir un symbole de puce pour les paragraphes de premier niveau
        IParagraphFormat paragraphFormat = notesStyle.GetLevel(0);
        paragraphFormat.Bullet.Type = BulletType.Symbol;
    }

    // Enregistrer le fichier PPTX sur le disque
    presentation.Save("AddNotesSlideWithNotesStyle_out.pptx", Aspose.Slides.Export.SaveFormat.Pptx);

}
```


## **FAQ**

**Quel element de l'API permet d'acceder aux notes d'une diapositive specifique?**

Les notes sont accessibles via le gestionnaire de notes de la diapositive: la diapositive possède un [NotesSlideManager](https://reference.aspose.com/slides/net/aspose.slides/notesslidemanager/) et une [property](https://reference.aspose.com/slides/net/aspose.slides/notesslidemanager/notesslide/) qui renvoie l'objet notes, ou `null` s'il n'y a aucune note.

**Existe-t-il des differences de prise en charge des notes selon les versions de PowerPoint compatibles avec la bibliotheque?**

La bibliotheque cible une large gamme de formats Microsoft PowerPoint (97-plus recent) et ODP; les notes sont prises en charge dans ces formats sans dependre d'une copie installee de PowerPoint.