---
title: Convertir PowerPoint en GIF animé
type: docs
weight: 65
url: /fr/cpp/convert-powerpoint-to-animated-gif/
keywords: "Convertir PowerPoint en GIF animé, "
description: "Convertir PowerPoint en GIF animé : PPT en GIF, PPTX en GIF, avec l'API Aspose.Slides."
---

## Conversion des présentations en GIF animé en utilisant les paramètres par défaut ##

Ce code d'exemple en C++ montre comment convertir une présentation en GIF animé en utilisant les paramètres standards :

``` cpp
auto pres = System::MakeObject<Presentation>(u"pres.pptx");
pres->Save(u"pres.gif", SaveFormat::Gif);
```

Le GIF animé sera créé avec des paramètres par défaut. 

{{%  alert  title="ASTUCE"  color="primary"  %}} 

Si vous préférez personnaliser les paramètres pour le GIF, vous pouvez utiliser la classe [GifOptions](https://reference.aspose.com/slides/cpp/class/aspose.slides.export.gif_options). Voir le code d'exemple ci-dessous. 

{{% /alert %}} 

## Conversion des présentations en GIF animé en utilisant des paramètres personnalisés ##
Ce code d'exemple montre comment convertir une présentation en GIF animé en utilisant des paramètres personnalisés en C++ :

``` cpp
auto gifOptions = System::MakeObject<GifOptions>();
// la taille du GIF résultant 
gifOptions->set_FrameSize(Size(960, 720));
// combien de temps chaque diapositive sera affichée avant de passer à la suivante
gifOptions->set_DefaultDelay(2000);
// augmenter les FPS pour une meilleure qualité de transition d'animation
gifOptions->set_TransitionFps(35);

auto pres = System::MakeObject<Presentation>(u"pres.pptx");
pres->Save(u"pres.gif", SaveFormat::Gif, gifOptions);
```

{{% alert title="Info" color="info" %}}

Vous pouvez consulter un convertisseur GRATUIT [Text to GIF](https://products.aspose.app/slides/text-to-gif) développé par Aspose. 

{{% /alert %}}