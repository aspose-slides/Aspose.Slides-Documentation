---
title: Convertir les présentations PowerPoint en SWF Flash dans .NET
linktitle: PowerPoint en SWF
type: docs
weight: 80
url: /fr/net/convert-powerpoint-to-swf-flash/
keywords:
- conversion PowerPoint
- conversion présentation
- conversion diapositive
- conversion PPT
- conversion PPTX
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
- PowerPoint
- présentation
- .NET
- C#
- Aspose.Slides
description: "Convertir PowerPoint (PPT/PPTX) en SWF Flash dans .NET avec Aspose.Slides. Exemples de code C# étape par étape, sortie de haute qualité rapide, aucune automatisation PowerPoint."
---

## **Convertir les présentations en Flash**

La méthode [Save](https://reference.aspose.com/slides/net/aspose.slides/presentation/methods/save/index) exposée par la classe [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) peut être utilisée pour convertir toute la présentation en document SWF. Vous pouvez également inclure des commentaires dans le SWF généré en utilisant la classe [SWFOptions](https://reference.aspose.com/slides/net/aspose.slides.export/swfoptions) et l'interface [INotesCommentsLayoutingOptions](https://reference.aspose.com/slides/net/aspose.slides.export/inotescommentslayoutingoptions). L'exemple suivant montre comment convertir une présentation en document SWF en utilisant les options fournies par la classe SWFOptions.
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

**Comment contrôler la compression et la taille finale du SWF ?**

Utilisez le drapeau [Compressed](https://reference.aspose.com/slides/net/aspose.slides.export/swfoptions/compressed/) (activé par défaut) et ajustez [JpegQuality](https://reference.aspose.com/slides/net/aspose.slides.export/swfoptions/jpegquality/) pour équilibrer la taille du fichier et la fidélité de l'image.

**À quoi sert 'ViewerIncluded' et quand devrais-je le désactiver ?**

[ViewerIncluded](https://reference.aspose.com/slides/net/aspose.slides.export/swfoptions/viewerincluded/) ajoute une interface de lecteur intégrée (contrôles de navigation, panneaux, recherche). Désactivez-le si vous prévoyez d'utiliser votre propre lecteur ou si vous avez besoin d'un cadre SWF dépouillé sans UI.

**Que se passe-t-il si une police source est manquante sur la machine d'exportation ?**

Aspose.Slides substituera la police que vous spécifiez via [DefaultRegularFont](https://reference.aspose.com/slides/net/aspose.slides.export/saveoptions/defaultregularfont/) dans [SwfOptions](https://reference.aspose.com/slides/net/aspose.slides.export/saveoptions/) pour éviter un repli inattendu.