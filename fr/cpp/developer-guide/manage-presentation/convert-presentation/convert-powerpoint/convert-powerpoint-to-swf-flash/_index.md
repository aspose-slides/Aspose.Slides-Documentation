---
title: Convertir les présentations PowerPoint en SWF Flash en C++
linktitle: PowerPoint vers SWF
type: docs
weight: 80
url: /fr/cpp/convert-powerpoint-to-swf-flash/
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
- enregistrer PPT en SWF
- enregistrer PPTX en SWF
- exporter PPT vers SWF
- exporter PPTX vers SWF
- PowerPoint
- présentation
- C++
- Aspose.Slides
description: "Convertir PowerPoint (PPT/PPTX) en SWF Flash en C++ avec Aspose.Slides. Exemples de code étape par étape, sortie de haute qualité, sans automatisation PowerPoint."
---

## **Convertir les présentations en Flash**

La méthode [Save](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation#afcd59ec697bf05c10f78c3869de2ec9e) exposée par la classe [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation) peut être utilisée pour convertir l'intégralité de la présentation en document SWF. Vous pouvez également inclure des commentaires dans le SWF généré en utilisant la classe [SWFOptions](https://reference.aspose.com/slides/cpp/class/aspose.slides.export.swf_options) et l'interface [INotesCommentsLayoutingOptions](https://reference.aspose.com/slides/cpp/class/aspose.slides.export.i_notes_comments_layouting_options). L'exemple suivant montre comment convertir une présentation en document SWF en utilisant les options fournies par la classe SWFOptions.
``` cpp
// Le chemin vers le répertoire des documents.
    System::String dataDir = GetDataPath();

    // Instancier un objet Presentation qui représente un fichier de présentation
    auto presentation = System::MakeObject<Presentation>(dataDir + u"HelloWorld.pptx");

    auto swfOptions = System::MakeObject<SwfOptions>();
    swfOptions->set_ViewerIncluded(false);

    auto notesOptions = swfOptions->get_NotesCommentsLayouting();
    notesOptions->set_NotesPosition(NotesPositions::BottomFull);

    // Enregistrement de la présentation et des pages de notes
    presentation->Save(dataDir + u"SaveAsSwf_out.swf", SaveFormat::Swf, swfOptions);
    swfOptions->set_ViewerIncluded(true);
    presentation->Save(dataDir + u"SaveNotes_out.swf", SaveFormat::Swf, swfOptions);
```


## **FAQ**

**Puis-je inclure des diapositives masquées dans le SWF ?**

Oui. Utilisez la méthode [set_ShowHiddenSlides](https://reference.aspose.com/slides/cpp/aspose.slides.export/swfoptions/set_showhiddenslides/) dans [SwfOptions](https://reference.aspose.com/slides/cpp/aspose.slides.export/swfoptions/). Par défaut, les diapositives masquées ne sont pas exportées.

**Comment puis-je contrôler la compression et la taille finale du SWF ?**

Utilisez la méthode [set_Compressed](https://reference.aspose.com/slides/cpp/aspose.slides.export/swfoptions/set_compressed/) et ajustez la [JPEG quality](https://reference.aspose.com/slides/cpp/aspose.slides.export/swfoptions/set_jpegquality/) pour équilibrer la taille du fichier et la fidélité de l'image.

**À quoi sert 'set_ViewerIncluded' et quand faut‑il l’utiliser ?**

[set_ViewerIncluded](https://reference.aspose.com/slides/cpp/aspose.slides.export/swfoptions/set_viewerincluded/) ajoute une interface utilisateur de lecteur intégré (contrôles de navigation, panneaux, recherche). Désactivez‑la si vous prévoyez d’utiliser votre propre lecteur ou si vous avez besoin d’un cadre SWF minimal sans UI.

**Que se passe‑t‑il si une police source est manquante sur la machine d’exportation ?**

Aspose.Slides remplacera la police que vous spécifiez via [set_DefaultRegularFont](https://reference.aspose.com/slides/cpp/aspose.slides.export/saveoptions/set_defaultregularfont/) dans [SwfOptions](https://reference.aspose.com/slides/cpp/aspose.slides.export/swfoptions/) afin d’éviter un repli non souhaité.