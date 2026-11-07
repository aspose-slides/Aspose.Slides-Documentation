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
## **Aperçu**

Compressez les images, supprimez les zones recadrées lorsqu'elles ne sont plus nécessaires et choisissez les paramètres de compression de la présentation avant d'enregistrer. Ceci est utile pour les présentations contenant de grandes photographies ou des médias répétés. Le gain dépend du contenu et des paramètres que vous choisissez.

## **Exemple d'utilisation**

Cet exemple C# charge `input.pptx`, compresse la présentation et l'enregistre sous `compressed.pptx`.

Utilisez Aspose.Slides for .NET 26.11 ou version ultérieure. Pour la configuration, consultez [Installer Aspose.Slides for .NET](/slides/fr/net/installation/).

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.LowCode;

using var presentation = new Presentation("input.pptx");
Compress.CompressPresentation(presentation);
presentation.Save("compressed.pptx", SaveFormat.Pptx);
```

## **FAQ**

### **S'agit-il d'un commutateur d'optimisation unique pour le fichier entier ?**

Aspose.Slides for .NET 26.11 ajoute [Compress.CompressPresentation](https://reference.aspose.com/slides/net/aspose.slides.lowcode/compress/compresspresentation/), qui combine la suppression des mises en page/master inutilisés, le sous-ensemble de polices incorporées et la compression d'images à 150 DPI. Il supprime définitivement les zones recadrées des images. Pour un traitement uniquement des images, utilisez [Compress.CompressImages](https://reference.aspose.com/slides/net/aspose.slides.lowcode/compress/compressimages/); pour un contrôle plus fin, consultez l'[exemple de compression d'image individuelle](/slides/fr/net/examples/optimization-batch/compression/). Ces nouveaux assistants sont spécifiques à la version .NET indiquée ; consultez le guide correspondant pour les autres SDK.

### **La compression d'images modifie-t-elle le texte ou les graphiques modifiables ?**

La compression d'images cible les données d'image, pas le texte modifiable ni les données des graphiques. Examinez les images, car le redimensionnement ou la recompression peut réduire leur niveau de détail.

### **Comment choisir une résolution pour les images d'une présentation ?**

Choisissez une cible en fonction de la taille affichée de l'image et de l'utilisation prévue à l'écran ou à l'impression. Conservez davantage de résolution pour les grands écrans, l'impression et les diagrammes détaillés, et comparez le rendu avant de supprimer l'original.

## **Guides**

- [Compresser l'ensemble de la présentation en .NET](/slides/fr/net/low-code-presentation-operations/#compress-the-whole-presentation)
- [Optimiser la gestion des images dans les présentations en .NET](/slides/fr/net/image/)

Fonctionnalité liée : [Supprimer les masters, mises en page et médias inutilisés](/slides/fr/features/remove-unused-content/).

## Exemples .NET exécutables

- [Réduire la taille de la présentation](/slides/fr/net/examples/optimization-batch/compression/)