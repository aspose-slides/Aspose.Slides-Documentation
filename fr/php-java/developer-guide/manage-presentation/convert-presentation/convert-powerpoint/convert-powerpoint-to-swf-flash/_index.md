---
title: Convertir les présentations PowerPoint en SWF Flash en PHP
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
- enregistrer PPT en SWF
- enregistrer PPTX en SWF
- exporter PPT en SWF
- exporter PPTX en SWF
- PowerPoint
- présentation
- PHP
- Aspose.Slides
description: "Convertir PowerPoint (PPT/PPTX) en SWF Flash en PHP avec Aspose.Slides. Exemples de code étape par étape, sortie rapide et de qualité, sans automatisation PowerPoint."
---

## **Convertir des présentations en Flash**
La méthode [Save](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation#save-java.lang.String-int-com.aspose.slides.ISaveOptions-) exposée par la classe [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation) peut être utilisée pour convertir l'intégralité de la présentation en document **SWF**. L'exemple suivant montre comment convertir une présentation en document **SWF** en utilisant les options fournies par la classe [**SWFOptions**](https://reference.aspose.com/slides/php-java/aspose.slides/SwfOptions). Vous pouvez également inclure des commentaires dans le SWF généré en utilisant la classe [**ISWFOptions**](https://reference.aspose.com/slides/php-java/aspose.slides/ISwfOptions) et l'interface [**INotesCommentsLayoutingOptions**](https://reference.aspose.com/slides/php-java/aspose.slides/INotesCommentsLayoutingOptions).
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

**Puis-je inclure des diapositives cachées dans le SWF ?**

Oui. Activez les diapositives cachées en utilisant la méthode [setShowHiddenSlides](https://reference.aspose.com/slides/php-java/aspose.slides/swfoptions/setshowhiddenslides/) dans [SwfOptions](https://reference.aspose.com/slides/php-java/aspose.slides/swfoptions/). Par défaut, les diapositives cachées ne sont pas exportées.

**Comment puis-je contrôler la compression et la taille finale du SWF ?**

Utilisez la méthode [setCompressed](https://reference.aspose.com/slides/php-java/aspose.slides/swfoptions/setcompressed/) et [adjust JPEG quality](https://reference.aspose.com/slides/php-java/aspose.slides/swfoptions/setjpegquality/) pour équilibrer la taille du fichier et la fidélité de l'image.

**À quoi sert 'setViewerIncluded' et quand dois-je le désactiver ?**

[setViewerIncluded](https://reference.aspose.com/slides/php-java/aspose.slides/swfoptions/setviewerincluded/) ajoute une interface de lecteur intégrée (contrôles de navigation, panneaux, recherche). Désactivez-la si vous prévoyez d'utiliser votre propre lecteur ou si vous avez besoin d'un cadre SWF dépourvu d'interface.

**Que se passe-t-il si une police source est absente sur la machine d'exportation ?**

Aspose.Slides remplacera la police que vous spécifiez via [setDefaultRegularFont](https://reference.aspose.com/slides/php-java/aspose.slides/saveoptions/#setDefaultRegularFont) dans [SwfOptions](https://reference.aspose.com/slides/php-java/aspose.slides/swfoptions/) afin d'éviter un recours non souhaité.