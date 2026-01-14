---
title: Convertir des présentations PowerPoint en SWF Flash avec PHP
linktitle: PowerPoint en SWF
type: docs
weight: 80
url: /fr/php-java/convert-powerpoint-to-swf-flash/
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
- enregistrer PPT en tant que SWF
- enregistrer PPTX en tant que SWF
- exporter PPT vers SWF
- exporter PPTX vers SWF
- PowerPoint
- présentation
- PHP
- Aspose.Slides
description: "Convertir PowerPoint (PPT/PPTX) en SWF Flash avec PHP et Aspose.Slides. Exemples de code pas à pas, sortie rapide de haute qualité, sans automatisation PowerPoint."
---

## **Convertir des présentations en Flash**

La méthode [save](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/save/) exposée par la classe [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) peut être utilisée pour convertir l'ensemble de la présentation en document **SWF**. L'exemple suivant montre comment convertir une présentation en document **SWF** en utilisant les options fournies par la classe [SWFOptions](https://reference.aspose.com/slides/php-java/aspose.slides/swfoptions/). Vous pouvez également inclure des commentaires dans le SWF généré en utilisant la classe [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/php-java/aspose.slides/notescommentslayoutingoptions/).
```php
  $pres = new Presentation("Sample.pptx");
  try {
    $swfOptions = new SwfOptions();
    $swfOptions->setViewerIncluded(false);
    $swfOptions->getNotesCommentsLayouting()->setNotesPosition(NotesPositions::BottomFull);
    # Enregistrement de la présentation
    $pres->save("Sample.swf", SaveFormat::Swf, $swfOptions);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **FAQ**

**Puis-je inclure des diapositives masquées dans le SWF ?**

Oui. Activez les diapositives masquées en utilisant la méthode [setShowHiddenSlides](https://reference.aspose.com/slides/php-java/aspose.slides/swfoptions/setshowhiddenslides/) dans [SwfOptions](https://reference.aspose.com/slides/php-java/aspose.slides/swfoptions/). Par défaut, les diapositives masquées ne sont pas exportées.

**Comment puis-je contrôler la compression et la taille finale du SWF ?**

Utilisez la méthode [setCompressed](https://reference.aspose.com/slides/php-java/aspose.slides/swfoptions/setcompressed/) et [adjust JPEG quality](https://reference.aspose.com/slides/php-java/aspose.slides/swfoptions/setjpegquality/) pour équilibrer la taille du fichier et la fidélité de l'image.

**À quoi sert 'setViewerIncluded' et quand devrais-je le désactiver ?**

[setViewerIncluded](https://reference.aspose.com/slides/php-java/aspose.slides/swfoptions/setviewerincluded/) ajoute une interface de lecteur intégrée (contrôles de navigation, panneaux, recherche). Désactivez-le si vous prévoyez d'utiliser votre propre lecteur ou si vous avez besoin d'une trame SWF dépouillée sans interface.

**Que se passe-t-il si une police source est manquante sur la machine d'exportation ?**

Aspose.Slides remplacera la police que vous spécifiez via [setDefaultRegularFont](https://reference.aspose.com/slides/php-java/aspose.slides/saveoptions/#setDefaultRegularFont) dans [SwfOptions](https://reference.aspose.com/slides/php-java/aspose.slides/swfoptions/) pour éviter un retour en fallback non intentionnel.