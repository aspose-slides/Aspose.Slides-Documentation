---
title: Convertir les présentations PowerPoint en SWF Flash sous .NET
linktitle: PowerPoint en SWF
type: docs
weight: 80
url: /fr/net/convert-powerpoint-to-swf-flash/
keywords:
- convertir PowerPoint
- convertir présentation
- convertir diapositive
- convertir PPT
- convertir PPTX
- PowerPoint en SWF
- présentation en SWF
- diapositive en SWF
- PPT en SWF
- PPTX en SWF
- PowerPoint en Flash
- présentation en Flash
- diapositive en Flash
- PPT en Flash
- PPTX en Flash
- enregistrer PPT en SWF
- enregistrer PPTX en SWF
- exporter PPT en SWF
- exporter PPTX en SWF
- PowerPoint
- présentation
- .NET
- C#
- Aspose.Slides
description: "Convertir PowerPoint (PPT/PPTX) en SWF Flash sous .NET avec Aspose.Slides. Exemples de code C# pas à pas, sortie rapide et de qualité, sans automatisation PowerPoint."
---

## **Convertir les présentations en Flash**

La méthode [Save](https://reference.aspose.com/slides/net/aspose.slides/presentation/methods/save/index) exposee par la classe [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) peut etre utilisee pour convertir la presentation entiere en document SWF. Vous pouvez egalement inclure des commentaires dans le SWF genere en utilisant la classe [SWFOptions](https://reference.aspose.com/slides/net/aspose.slides.export/swfoptions) et l'interface [INotesCommentsLayoutingOptions](https://reference.aspose.com/slides/net/aspose.slides.export/inotescommentslayoutingoptions). L'exemple suivant montre comment convertir une presentation en document SWF en utilisant les options fournissees par la classe SWFOptions.
```c#
// Instancier un objet Presentation qui représente un fichier de présentation
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

**Puis-je inclure les diapositives masquées dans le SWF?**

Oui. Activez l'option [ShowHiddenSlides](https://reference.aspose.com/slides/net/aspose.slides.export/swfoptions/showhiddenslides/) dans [SwfOptions](https://reference.aspose.com/slides/net/aspose.slides.export/swfoptions/). Par défaut, les diapositives masquées ne sont pas exportees.

**Comment puis-je contrôler la compression et la taille finale du SWF?**

Utilisez le drapeau [Compressed](https://reference.aspose.com/slides/net/aspose.slides.export/swfoptions/compressed/) (active en défaut) et ajustez [JpegQuality](https://reference.aspose.com/slides/net/aspose.slides.export/swfoptions/jpegquality/) pour equilibrer la taille du fichier et la fidélité de l'image.

**À quoi sert 'ViewerIncluded' et quand faut-il le désactiver?**

[ViewerIncluded](https://reference.aspose.com/slides/net/aspose.slides.export/swfoptions/viewerincluded/) ajoute une interface de lecteur intégré (controle de navigation, panneaux, recherche). Désactivez-le si vous prevoyez d'utiliser votre propre lecteur ou si vous avez besoin d'un cadre SWF depourvu d'interface.

**Que se passe-t-il si une police source est manquante sur la machine d'export?**

Aspose.Slides remplacera la police que vous specifiez via [DefaultRegularFont](https://reference.aspose.com/slides/net/aspose.slides.export/saveoptions/defaultregularfont/) dans [SwfOptions](https://reference.aspose.com/slides/net/aspose.slides.export/saveoptions/) afin d'éviter un repli inattendu.