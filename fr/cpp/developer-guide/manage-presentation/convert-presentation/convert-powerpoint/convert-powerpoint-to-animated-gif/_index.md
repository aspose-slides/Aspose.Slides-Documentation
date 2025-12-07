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
description: "Convertissez facilement les présentations PowerPoint (PPT, PPTX) en GIF animés avec Aspose.Slides pour C++. Rapide, résultats de haute qualité."
---

## **Convertir des présentations en GIF animé avec les paramètres par défaut**

Ce code d’exemple en C++ montre comment convertir une présentation en GIF animé en utilisant les paramètres standard :
``` cpp
auto pres = System::MakeObject<Presentation>(u"pres.pptx");
pres->Save(u"pres.gif", SaveFormat::Gif);
```


Le GIF animé sera créé avec les paramètres par défaut. 

{{%  alert  title="TIP"  color="primary"  %}} 

Si vous préférez personnaliser les paramètres du GIF, vous pouvez utiliser la classe [GifOptions](https://reference.aspose.com/slides/cpp/class/aspose.slides.export.gif_options). Consultez le code d’exemple ci‑dessous. 

{{% /alert %}} 

## **Convertir des présentations en GIF animé avec des paramètres personnalisés**

Ce code d’exemple montre comment convertir une présentation en GIF animé en utilisant des paramètres personnalisés en C++ :
``` cpp
auto gifOptions = System::MakeObject<GifOptions>();
// la taille du GIF résultant 
gifOptions->set_FrameSize(Size(960, 720));
// la durée d'affichage de chaque diapositive avant le passage à la suivante
gifOptions->set_DefaultDelay(2000);
// augmenter les FPS pour améliorer la qualité des animations de transition
gifOptions->set_TransitionFps(35);

auto pres = System::MakeObject<Presentation>(u"pres.pptx");
pres->Save(u"pres.gif", SaveFormat::Gif, gifOptions);
```


{{% alert title="Info" color="info" %}}

Vous pourriez être intéressé par un convertisseur GRATUIT [Text to GIF](https://products.aspose.app/slides/text-to-gif) développé par Aspose. 

{{% /alert %}}

## **FAQ**

**Et si les polices utilisées dans la présentation ne sont pas installées sur le système ?**

Installez les polices manquantes ou [configure fallback fonts](/slides/fr/cpp/powerpoint-fonts/). Aspose.Slides les remplacera, mais l’apparence peut différer. Pour le branding, assurez‑vous toujours que les polices requises sont explicitement disponibles.

**Puis‑je superposer un filigrane sur les images du GIF ?**

Oui. [Add a semi-transparent object/logo](/slides/fr/cpp/watermark/) sur la diapositive maître ou sur les diapositives individuelles avant l’exportation — le filigrane apparaîtra sur chaque image.