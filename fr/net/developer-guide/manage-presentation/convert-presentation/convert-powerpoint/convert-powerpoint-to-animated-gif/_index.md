---
title: Convertir PowerPoint en GIF animé
type: docs
weight: 65
url: /net/convert-powerpoint-to-animated-gif/
keywords: "Convertir PowerPoint, PPT, PPTX, GIF animé, PPT en GIF animé, PPTX en GIF animé C#, Csharp, .NET, paramètres par défaut, paramètres personnalisés"
description: "Convertir une présentation PowerPoint en GIF animé : PPT en GIF, PPTX en GIF en C# ou .NET"
---

## Conversion des présentations en GIF animé avec les paramètres par défaut ##

Ce code d'exemple en C# montre comment convertir une présentation en GIF animé en utilisant des paramètres standard :

``` csharp
using (Presentation pres = new Presentation("pres.pptx"))
{
    pres.Save("pres.gif", SaveFormat.Gif);
}
```

Le GIF animé sera créé avec des paramètres par défaut.

{{%  alert  title="ASTUCE"  color="primary"  %}} 

Si vous préférez personnaliser les paramètres pour le GIF, vous pouvez utiliser la classe [GifOptions](https://reference.aspose.com/slides/net/aspose.slides.export/gifoptions). Voir le code d'exemple ci-dessous.

{{% /alert %}} 

## Conversion des présentations en GIF animé avec des paramètres personnalisés ##
Ce code d'exemple montre comment convertir une présentation en GIF animé en utilisant des paramètres personnalisés en C# :

``` csharp
using (Presentation pres = new Presentation("pres.pptx"))
{
    pres.Save("pres.gif", SaveFormat.Gif, new GifOptions
    {
        FrameSize = new Size(960, 720), // la taille du GIF résultant  
        DefaultDelay = 2000, // combien de temps chaque diapositive sera affichée avant de passer à la suivante
        TransitionFps = 35 // augmenter les FPS pour une meilleure qualité d'animation de transition
    });
}
```

{{% alert title="Info" color="info" %}}

Vous pouvez également consulter un convertisseur GRATUIT [Text to GIF](https://products.aspose.app/slides/text-to-gif) développé par Aspose.

{{% /alert %}}