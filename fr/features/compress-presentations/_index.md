---
title: Compresser les présentations
description: Réduire la taille de la présentation avec la compression d'images et enregistrer les paramètres.
type: docs
url: /fr/features/compress-presentations/
weight: 250
feature_id: compress-presentations
feature_group: operations
translationKey: slides-feature-compress-presentations
feature_catalogue_version: 3
feature_guides:
- /slides/net/image/
---
## **Vue d'ensemble**

Compressez les images, supprimez les zones recadrées lorsqu'elles ne sont plus nécessaires et choisissez les paramètres de compression de la présentation avant l'enregistrement. Cela est utile pour les présentations contenant de grandes photographies ou des médias répétés. Le gain dépend du contenu et des paramètres que vous choisissez.

## **Exemple d'utilisation**

Cet exemple C# utilise Aspose.Slides for .NET. Il génère visiblement un PNG en dégradé de 1600 × 900 pixels, l’insère dans un petit cadre d’image et enregistre *before.pptx*. Il compresse ensuite cette image à une résolution cible de 96 DPI et enregistre *compressed.pptx*. Comparez les deux tailles de fichier et les aperçus : les économies dépendent de l'image d'origine et de la taille affichée.

Pour la configuration, voir [Installer Aspose.Slides for .NET](/slides/fr/net/installation/).

```csharp
using System;
using System.Drawing;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

using (var bitmap = new Bitmap(1600, 900))
{
    for (var y = 0; y < bitmap.Height; y++)
        for (var x = 0; x < bitmap.Width; x++)
            bitmap.SetPixel(x, y, Color.FromArgb(x % 256, y % 256, (x + y) % 256));
    bitmap.Save("large.png", System.Drawing.Imaging.ImageFormat.Png);
}
using var presentation = new Presentation();
var title = presentation.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle, 40, 20, 500, 60);
title.TextFrame.Text = "Photo";
var bytes = File.ReadAllBytes("large.png");
var image = presentation.Images.AddImage(bytes);
var picture = presentation.Slides[0].Shapes.AddPictureFrame(ShapeType.Rectangle, 40, 120, 240, 135, image);
presentation.Save("before.pptx", SaveFormat.Pptx);
var compressed = picture.PictureFormat.CompressImage(true, 96f);
Console.WriteLine($"Picture compressed: {compressed}");
presentation.Save("compressed.pptx", SaveFormat.Pptx);
using var preview = presentation.Slides[0].GetImage(1f, 1f);
preview.Save("compressed.png", ImageFormat.Png);
```

## **FAQ**

### **S'agit-il d'un commutateur d'optimisation du fichier complet ?**

Aspose.Slides for .NET 26.11 ajoute [Compress.CompressPresentation](/slides/fr/net/low-code-presentation-operations/#compress-the-whole-presentation), qui combine la suppression des mises en page/maîtres inutilisés, le sous‑ensemble de polices intégrées et la compression d'images à 150 DPI. Il supprime de façon permanente les zones recadrées des images. Pour un traitement uniquement d'images, utilisez Compress.CompressImages ; pour un contrôle plus fin, conservez le flux de travail par image décrit ci‑dessus. Ces nouveaux assistants sont spécifiques à la version .NET indiquée ; consultez le guide correspondant pour les autres SDK.

### **La compression d'image modifie-t-elle le texte ou les graphiques modifiables ?**

La compression d'image cible les données d'image, pas le texte modifiable ni les données de graphiques. Examinez les images, car le redimensionnement ou la recompression peut en réduire les détails.

### **Comment choisir une résolution pour les images de la présentation ?**

Choisissez une résolution cible en fonction de la taille affichée de l'image et de l'usage prévu à l'écran ou à l'impression. Conservez une résolution plus élevée pour les grands écrans, l'impression et les diagrammes détaillés, et comparez le rendu avant de supprimer l'original.

## **Guides**

- [Optimiser la gestion des images dans les présentations en .NET](/slides/fr/net/image/)

Fonctionnalité associée : [Supprimer les maîtres, mises en page et médias inutilisés](/slides/fr/features/remove-unused-content/).

## Exemples .NET exécutables

- [Réduire la taille de la présentation](/slides/fr/net/examples/optimization-batch/compression/)