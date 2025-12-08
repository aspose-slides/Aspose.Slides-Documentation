---
title: Convertir PowerPoint en SWF Flash
type: docs
weight: 80
url: /fr/net/convert-powerpoint-to-swf-flash/
keywords: "Convertir PowerPoint, Présentation, PowerPoint en SWF, SWF flash PPT en SWF, PPTX en SWF, C#, Csharp, .NET"
description: "Convertir une présentation PowerPoint en SWF Flash en C# ou .NET"
---

## **Convertir des présentations en Flash**

La méthode [Save](https://reference.aspose.com/slides/net/aspose.slides/presentation/methods/save/index) exposée par la classe [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) peut être utilisée pour convertir l'ensemble de la présentation en document SWF. Vous pouvez également inclure des commentaires dans le SWF généré en utilisant la classe [SWFOptions](https://reference.aspose.com/slides/net/aspose.slides.export/swfoptions) et l'interface [INotesCommentsLayoutingOptions](https://reference.aspose.com/slides/net/aspose.slides.export/inotescommentslayoutingoptions). L'exemple suivant montre comment convertir une présentation en document SWF en utilisant les options fournies par la classe SWFOptions.
```c#
// Instancie un objet Presentation qui représente un fichier de présentation
using (Presentation presentation = new Presentation("HelloWorld.pptx"))
{
    SwfOptions swfOptions = new SwfOptions();
    swfOptions.ViewerIncluded = false;


    INotesCommentsLayoutingOptions notesOptions = swfOptions.NotesCommentsLayouting;
    notesOptions.NotesPosition = NotesPositions.BottomFull;

    // Enregistrement de la présentation et des pages de notes
    presentation.Save("SaveAsSwf_out.swf", SaveFormat.Swf, swfOptions);
    swfOptions.ViewerIncluded = true;
    presentation.Save("SaveNotes_out.swf", SaveFormat.Swf, swfOptions);
}
```


## **FAQ**

**Puis-je inclure des diapositives masquées dans le SWF ?**

Oui. Activez l'option [ShowHiddenSlides](https://reference.aspose.com/slides/net/aspose.slides.export/swfoptions/showhiddenslides/) dans [SwfOptions](https://reference.aspose.com/slides/net/aspose.slides.export/swfoptions/). Par défaut, les diapositives masquées ne sont pas exportées.

**Comment puis‑je contrôler la compression et la taille finale du SWF ?**

Utilisez le drapeau [Compressed](https://reference.aspose.com/slides/net/aspose.slides.export/swfoptions/compressed/) (activé par défaut) et ajustez [JpegQuality](https://reference.aspose.com/slides/net/aspose.slides.export/swfoptions/jpegquality/) pour équilibrer la taille du fichier et la fidélité de l'image.

**À quoi sert « ViewerIncluded » et quand faut‑il le désactiver ?**

[ViewerIncluded](https://reference.aspose.com/slides/net/aspose.slides.export/swfoptions/viewerincluded/) ajoute une interface de lecteur intégrée (contrôles de navigation, panneaux, recherche). Désactivez‑le si vous prévoyez d'utiliser votre propre lecteur ou si vous avez besoin d'un cadre SWF minimal sans interface.

**Que se passe‑t‑il si une police source est absente sur la machine d'exportation ?**

Aspose.Slides remplacera la police que vous spécifiez via [DefaultRegularFont](https://reference.aspose.com/slides/net/aspose.slides.export/saveoptions/defaultregularfont/) dans [SwfOptions](https://reference.aspose.com/slides/net/aspose.slides.export/saveoptions/) afin d'éviter un repli non intentionnel.