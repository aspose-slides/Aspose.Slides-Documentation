---
title: Convertir des présentations PowerPoint en GIF animés avec .NET
linktitle: PowerPoint en GIF
type: docs
weight: 65
url: /fr/net/convert-powerpoint-to-animated-gif/
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
- .NET
- C#
- Aspose.Slides
description: "Convertissez facilement les présentations PowerPoint (PPT, PPTX) en GIF animés avec Aspose.Slides pour .NET. Résultats rapides et de haute qualité."
---

## **Convertir des présentations en GIF animé avec les paramètres par défaut**

Ce code d'exemple en C# montre comment convertir une présentation en GIF animé en utilisant les paramètres standard :
``` csharp
using (Presentation pres = new Presentation("pres.pptx"))
{
    pres.Save("pres.gif", SaveFormat.Gif);
}
```


Le GIF animé sera créé avec les paramètres par défaut. 

{{%  alert  title="ASTUCE"  color="primary" %}} 
Si vous préférez personnaliser les paramètres du GIF, vous pouvez utiliser la classe [GifOptions](https://reference.aspose.com/slides/net/aspose.slides.export/gifoptions). Voir le code d'exemple ci‑dessous. 
{{% /alert %}} 

## **Convertir des présentations en GIF animé avec des paramètres personnalisés**

Ce code d'exemple montre comment convertir une présentation en GIF animé en utilisant des paramètres personnalisés en C# :
``` csharp
using (Presentation pres = new Presentation("pres.pptx"))
{
    pres.Save("pres.gif", SaveFormat.Gif, new GifOptions
    {
        FrameSize = new Size(960, 720), // la taille du GIF résultant  
        DefaultDelay = 2000, // durée pendant laquelle chaque diapositive sera affichée avant de passer à la suivante
        TransitionFps = 35 // augmenter les FPS pour améliorer la qualité de l'animation de transition
    });
}
```


{{% alert title="Info" color="info" %}}
Vous pouvez consulter un convertisseur GRATUIT [Text to GIF](https://products.aspose.app/slides/text-to-gif) développé par Aspose. 
{{% /alert %}}

## **FAQ**

**Que faire si les polices utilisées dans la présentation ne sont pas installées sur le système ?**

Installez les polices manquantes ou [configurez des polices de secours](/slides/fr/net/powerpoint-fonts/). Aspose.Slides les remplacera, mais l’apparence peut différer. Pour l’image de marque, assurez‑vous toujours que les polices requises sont explicitement disponibles.

**Puis‑je superposer un filigrane sur les images du GIF ?**

Oui. [Ajoutez un objet/logo semi‑transparent](/slides/fr/net/watermark/) à la diapositive maîtresse ou aux diapositives individuelles avant l’exportation — le filigrane apparaîtra sur chaque image.