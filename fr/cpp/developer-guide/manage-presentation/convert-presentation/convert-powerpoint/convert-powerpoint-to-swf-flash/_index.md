---
title: Convertir les présentations PowerPoint en SWF Flash en C++
linktitle: PowerPoint en SWF
type: docs
weight: 80
url: /fr/cpp/convert-powerpoint-to-swf-flash/
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
- enregistrer PPT au format SWF
- enregistrer PPTX au format SWF
- exporter PPT en SWF
- exporter PPTX en SWF
- PowerPoint
- présentation
- C++
- Aspose.Slides
description: "Convertir PowerPoint (PPT/PPTX) en SWF Flash en C++ avec Aspose.Slides. Exemples de code étape par étape, sortie rapide de haute qualité, sans automatisation PowerPoint."
---

## **Convertir les présentations en Flash**

La méthode [Save](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation#afcd59ec697bf05c10f78c3869de2ec9e) exposée par la classe [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation) peut être utilisée pour convertir l'intégralité de la présentation en document SWF. Vous pouvez également inclure des commentaires dans le SWF généré en utilisant la classe [SWFOptions](https://reference.aspose.com/slides/cpp/class/aspose.slides.export.swf_options) et l'interface [INotesCommentsLayoutingOptions](https://reference.aspose.com/slides/cpp/class/aspose.slides.export.i_notes_comments_layouting_options). L'exemple suivant montre comment convertir une présentation en document SWF en utilisant les options fournies par la classe SWFOptions.
``` cpp
// Le chemin du répertoire des documents.
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

**Puis-je inclure les diapositives masquées dans le SWF ?**

Oui. Utilisez la méthode [set_ShowHiddenSlides](https://reference.aspose.com/slides/cpp/aspose.slides.export/swfoptions/set_showhiddenslides/) dans [SwfOptions](https://reference.aspose.com/slides/cpp/aspose.slides.export/swfoptions/). Par défaut, les diapositives masquées ne sont pas exportées.

**Comment puis-je contrôler la compression et la taille finale du SWF ?**

Utilisez la méthode [set_Compressed](https://reference.aspose.com/slides/cpp/aspose.slides.export/swfoptions/set_compressed/) et ajustez la [qualité JPEG](https://reference.aspose.com/slides/cpp/aspose.slides.export/swfoptions/set_jpegquality/) pour équilibrer la taille du fichier et la fidélité de l’image.

**À quoi sert 'set_ViewerIncluded' et quand dois-je l’utiliser ?**

[set_ViewerIncluded](https://reference.aspose.com/slides/cpp/aspose.slides.export/swfoptions/set_viewerincluded/) ajoute une interface utilisateur de lecteur intégré (contrôles de navigation, panneaux, recherche). Désactivez‑la si vous prévoyez d’utiliser votre propre lecteur ou si vous avez besoin d’un cadre SWF minimal sans interface.

**Que se passe-t-il si une police source est manquante sur la machine d’exportation ?**

Aspose.Slides remplacera la police que vous spécifiez via [set_DefaultRegularFont](https://reference.aspose.com/slides/cpp/aspose.slides.export/saveoptions/set_defaultregularfont/) dans [SwfOptions](https://reference.aspose.com/slides/cpp/aspose.slides.export/swfoptions/) afin d’éviter un remplacement inattendu.