---
title: Convertir des présentations PowerPoint en GIF animés en C++
linktitle: PowerPoint en GIF
type: docs
weight: 65
url: /fr/cpp/convert-powerpoint-to-animated-gif/
keywords:
- GIF animé
- convertir PowerPoint
- convertir présentation
- convertir diapositive
- convertir PPT
- convertir PPTX
- PowerPoint en GIF
- présentation en GIF
- diapositive en GIF
- PPT en GIF
- PPTX en GIF
- enregistrer PPT en GIF
- enregistrer PPTX en GIF
- exporter PPT en GIF
- exporter PPTX en GIF
- paramètres par défaut
- paramètres personnalisés
- PowerPoint
- présentation
- C++
- Aspose.Slides
description: "Convertissez facilement des présentations PowerPoint (PPT, PPTX) en GIF animés avec Aspose.Slides pour C++. Résultats rapides et de haute qualité."
---
## **Vue d'ensemble**

Aspose.Slides vous permet de convertir des présentations PowerPoint en fichiers GIF animés en quelques lignes de code seulement. Cela est utile lorsque vous devez partager le contenu des diapositives dans un format animé léger, largement pris en charge, pouvant être intégré aux pages Web, aux messageries ou à la documentation. Cet article explique comment exporter une présentation au format GIF avec les paramètres par défaut et comment personnaliser le résultat en configurant des options telles que la taille des images, le délai entre les diapositives et le taux de rafraîchissement des transitions via [GifOptions](https://reference.aspose.com/slides/fr/cpp/aspose.slides.export/gifoptions/).

## **Convertir les présentations en GIF animé avec les paramètres par défaut**

Ce code d'exemple en C++ vous montre comment convertir une présentation en GIF animé en utilisant les paramètres standards :

``` cpp
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto pres = System::MakeObject<Presentation>(u"pres.pptx");
pres->Save(u"pres.gif", SaveFormat::Gif);
```

Le GIF animé sera créé avec les paramètres par défaut. 

{{%  alert  title="ASTUCE"  color="info"  %}} 
Si vous préférez personnaliser les paramètres du GIF, vous pouvez utiliser la classe [GifOptions](https://reference.aspose.com/slides/fr/cpp/class/aspose.slides.export.gif_options). Voir le code d'exemple ci-dessous. 
{{% /alert %}} 

## **Convertir les présentations en GIF animé avec des paramètres personnalisés**

Ce code d'exemple vous montre comment convertir une présentation en GIF animé en utilisant des paramètres personnalisés en C++ :

``` cpp
#include <DOM/Presentation.h>
#include <Export/GifOptions.h>
#include <Export/SaveFormat.h>
#include <drawing/size.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto gifOptions = System::MakeObject<GifOptions>();
// la taille du GIF résultant
gifOptions->set_FrameSize(System::Drawing::Size(960, 720));
// durée d'affichage de chaque diapositive avant de passer à la suivante
gifOptions->set_DefaultDelay(2000);
// augmenter le FPS pour améliorer la qualité de l'animation de transition
gifOptions->set_TransitionFps(35);

auto pres = System::MakeObject<Presentation>(u"pres.pptx");
pres->Save(u"pres.gif", SaveFormat::Gif, gifOptions);
```

{{% alert title="Info" color="info" %}}
Vous pourriez être intéressé par un convertisseur GRATUIT [Text to GIF](https://products.aspose.app/slides/fr/text-to-gif) développé par Aspose. 
{{% /alert %}}

## **FAQ**

### Que faire si les polices utilisées dans la présentation ne sont pas installées sur le système ?

Installez les polices manquantes ou [configurer les polices de secours](/slides/fr/cpp/powerpoint-fonts/). Aspose.Slides les remplacera, mais l'apparence peut différer. Pour le branding, veillez toujours à ce que les polices requises soient explicitement disponibles.

### Puis‑je superposer un filigrane sur les images du GIF ?

Oui. [Ajouter un objet/logo semi-translucide](/slides/fr/cpp/watermark/) à la diapositive maîtresse ou aux diapositives individuelles avant l'exportation — le filigrane apparaîtra sur chaque image.