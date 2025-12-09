---
title: Convertir les présentations PowerPoint en SWF Flash sous .NET
linktitle: PowerPoint vers SWF
type: docs
weight: 80
url: /fr/net/convert-powerpoint-to-swf-flash/
keywords:
- convertir PowerPoint
- convertir présentation
- convertir diapositive
- convertir PPT
- convertir PPTX
- PowerPoint vers SWF
- présentation vers SWF
- diapositive vers SWF
- PPT vers SWF
- PPTX vers SWF
- PowerPoint vers Flash
- présentation vers Flash
- diapositive vers Flash
- PPT vers Flash
- PPTX vers Flash
- PowerPoint
- présentation
- .NET
- C#
- Aspose.Slides
description: "Convertir PowerPoint (PPT/PPTX) en SWF Flash sous .NET avec Aspose.Slides. Exemples de code C# étape par étape, sortie rapide et de haute qualité, sans automatisation PowerPoint."
---

## **Convertir les présentations en Flash**

La méthode [Save](https://reference.aspose.com/slides/net/aspose.slides/presentation/methods/save/index) exposée par la classe [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) peut être utilisée pour convertir l'intégralité de la présentation en document SWF. Vous pouvez également inclure des commentaires dans le SWF généré en utilisant la classe [SWFOptions](https://reference.aspose.com/slides/net/aspose.slides.export/swfoptions) et l'interface [INotesCommentsLayoutingOptions](https://reference.aspose.com/slides/net/aspose.slides.export/inotescommentslayoutingoptions). L'exemple suivant montre comment convertir une présentation en document SWF en utilisant les options fournies par la classe SWFOptions.
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

**Puis-je inclure les diapositives masquées dans le SWF ?**

Oui. Activez l'option [ShowHiddenSlides](https://reference.aspose.com/slides/net/aspose.slides.export/swfoptions/showhiddenslides/) dans [SwfOptions](https://reference.aspose.com/slides/net/aspose.slides.export/swfoptions/). Par défaut, les diapositives masquées ne sont pas exportées.

**Comment puis‑je contrôler la compression et la taille finale du SWF ?**

Utilisez le drapeau [Compressed](https://reference.aspose.com/slides/net/aspose.slides.export/swfoptions/compressed/) (activé par défaut) et ajustez [JpegQuality](https://reference.aspose.com/slides/net/aspose.slides.export/swfoptions/jpegquality/) pour équilibrer la taille du fichier et la fidélité de l'image.

**À quoi sert 'ViewerIncluded' et quand dois‑je le désactiver ?**

[ViewerIncluded](https://reference.aspose.com/slides/net/aspose.slides.export/swfoptions/viewerincluded/) ajoute une interface de lecteur intégrée (contrôles de navigation, panneaux, recherche). Désactivez‑la si vous prévoyez d'utiliser votre propre lecteur ou si vous avez besoin d'un cadre SWF dépouillé d'interface.

**Que se passe‑t‑il si une police source est manquante sur la machine d'exportation ?**

Aspose.Slides substituera la police que vous spécifiez via [DefaultRegularFont](https://reference.aspose.com/slides/net/aspose.slides.export/saveoptions/defaultregularfont/) dans [SwfOptions](https://reference.aspose.com/slides/net/aspose.slides.export/saveoptions/) afin d'éviter un repli imprévu.