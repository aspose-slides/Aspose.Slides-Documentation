---
title: Compresser les présentations
description: Réduire la taille de la présentation en compressant les images et en supprimant le contenu inutilisé.
type: docs
url: /fr/features/compress-presentations/
weight: 250
feature_id: compress-presentations
feature_group: operations
translationKey: slides-feature-compress-presentations
feature_catalogue_version: 3
feature_guides:
- /slides/net/low-code-presentation-operations/
- /slides/net/image/
---
## **Vue d'ensemble**

Compressez les images, supprimez les zones recadrées lorsqu'elles ne sont plus nécessaires, et choisissez les paramètres de compression de la présentation avant l'enregistrement. Cela est utile pour les présentations contenant de grandes photographies ou des médias répétés. La quantité économisée dépend du contenu et des paramètres que vous choisissez.

## **Exemple d'utilisation**

Cet exemple C# charge `input.pptx`, compresse la présentation et l'enregistre sous `compressed.pptx`.

Utilisez Aspose.Slides for .NET 26.11 ou une version ultérieure. Pour la configuration, consultez [Installer Aspose.Slides for .NET](/slides/fr/net/installation/).

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.LowCode;

using var presentation = new Presentation("input.pptx");
Compress.CompressPresentation(presentation);
presentation.Save("compressed.pptx", SaveFormat.Pptx);
```


<!-- visual-explanation:compress-presentations:start -->
[![Rendus d'images à l'échelle identique avant et après compression, suivis de barres de taille de fichier PPTX mesurées et des dimensions d'image stockées.](visual-compress-presentations-1adbf86268a5.svg)](visual-compress-presentations-1adbf86268a5.svg)

*Mesuré sur un seul dispositif synthétique de grille de détails : 584 030 → 128 323 octets. Les deux rendus utilisent la même échelle et un cadre de 252 × 336 points. La compression supprime les marges recadrées et réduit l'image stockée à 525 × 700 pixels ; les économies de taille dépendent de l'entrée.*
<!-- visual-explanation:compress-presentations:end -->

## **FAQ**

### **S'agit-il d'un commutateur d'optimisation de fichier complet unique ?**

Aspose.Slides for .NET 26.11 ajoute [Compress.CompressPresentation](https://reference.aspose.com/slides/net/aspose.slides.lowcode/compress/compresspresentation/), qui combine la suppression des mises en page/maîtres inutilisés, le sous‑ensemble de polices intégrées et la compression d'images à 150 DPI. Il supprime définitivement les zones d'images recadrées. Pour le traitement uniquement d'images, utilisez [Compress.CompressImages](https://reference.aspose.com/slides/net/aspose.slides.lowcode/compress/compressimages/); pour un contrôle plus fin, consultez l'[exemple de compression d'image individuelle](/slides/fr/net/examples/optimization-batch/compression/). Depuis la version 26.11, le même appel de compression de présentation complète est également disponible en Java, Node.js via Java, Python via .NET et C++. L'exemple et les liens sur cette page concernent .NET.

### **La compression d'image modifie-t-elle le texte ou les graphiques modifiables ?**

La compression d'image cible les données d'image, pas le texte modifiable ou les données de graphiques. Examinez les images car le redimensionnement ou la recompression peut en réduire les détails.

### **Comment choisir une résolution pour les images d'une présentation ?**

Choisissez une cible en fonction de la taille d'affichage de l'image et de l'utilisation prévue à l'écran ou à l'impression. Conservez une résolution supérieure pour les grands écrans, l'impression et les schémas détaillés, et comparez le rendu avant de supprimer l'original.

## **Guides**

- [Compresser la présentation complète en .NET](/slides/fr/net/low-code-presentation-operations/#compress-the-whole-presentation)
- [Optimiser la gestion des images dans les présentations en .NET](/slides/fr/net/image/)

Related feature: [Supprimer les maîtres, mises en page et médias inutilisés](/slides/fr/features/remove-unused-content/).

## **Exemples .NET exécutables**

- [Réduire la taille de la présentation](/slides/fr/net/examples/optimization-batch/compression/)